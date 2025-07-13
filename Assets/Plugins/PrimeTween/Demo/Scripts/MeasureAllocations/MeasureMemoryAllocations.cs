using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR && UNITY_2019_1_OR_NEWER
using System.Linq;
using UnityEditor;
using UnityEditor.Profiling;
using UnityEditorInternal;
using UnityEngine.Profiling;
#endif

namespace PrimeTweenDemo
{
    public class MeasureMemoryAllocations : MonoBehaviour
    {
#pragma warning disable 0414
        [SerializeField] private bool logAllocations;
        [SerializeField] private bool logFiltered;
        [SerializeField] private bool logIgnored;
        [SerializeField] private List<string> filterAllocations = new();
        [SerializeField] private List<string> ignoreAllocations = new();
#pragma warning restore 0414
#if UNITY_EDITOR && UNITY_2019_1_OR_NEWER
        public int? gcAllocTotal { get; private set; }
        private readonly Stack<int> stack = new();
        private readonly List<int> childrenBuffer = new();
        private readonly List<int> fullIdPathBuffer = new();
        private readonly List<int[]> ignoredPaths = new();
        private readonly List<int[]> filteredPaths = new();
        private int lastProcessedFrame = -1;

        private void Awake()
        {
            filterAllocations.Add("PrimeTween.Runtime");
            filterAllocations.Add("PrimeTweenDemo");
        }

        private void OnEnable()
        {
            ProfilerDriver.ClearAllFrames();
        }

        private void Update()
        {
            if (!Profiler.enabled)
            {
                return;
            }
            var startFrame = Mathf.Max(lastProcessedFrame + 1, ProfilerDriver.firstFrameIndex);
            for (int i = startFrame; i <= ProfilerDriver.lastFrameIndex; i++)
            {
                var gcAlloc = calcGCAllocInFrame(i);
                if (!gcAlloc.HasValue)
                {
                    break;
                }
                lastProcessedFrame = i;
                if (gcAllocTotal.HasValue)
                {
                    gcAllocTotal += gcAlloc.Value;
                }
                else
                {
                    gcAllocTotal = gcAlloc.Value;
                }
            }
        }

        private int? calcGCAllocInFrame(int frameIndex)
        {
            int result = 0;
            const HierarchyFrameDataView.ViewModes viewMode = HierarchyFrameDataView.ViewModes.MergeSamplesWithTheSameName | HierarchyFrameDataView.ViewModes.HideEditorOnlySamples;
            using (var data = ProfilerDriver.GetHierarchyFrameDataView(frameIndex, 0, viewMode, HierarchyFrameDataView.columnGcMemory, false))
            {
                if (!data.valid)
                {
                    return null;
                }
                stack.Clear();
                stack.Push(data.GetRootItemID());
                while (stack.Count > 0)
                {
                    var current = stack.Pop();
                    UnityEngine.Assertions.Assert.IsTrue(data.HasItemChildren(current));
                    data.GetItemChildren(current, childrenBuffer);
                    foreach (var childId in childrenBuffer)
                    {
                        var gcAlloc = (int)data.GetItemColumnDataAsSingle(childId, HierarchyFrameDataView.columnGcMemory);
                        if (gcAlloc == 0)
                        {
                            continue;
                        }
                        if (data.HasItemChildren(childId))
                        {
                            stack.Push(childId);
                            continue;
                        }
                        data.GetItemMarkerIDPath(childId, fullIdPathBuffer);
                        if (ContainsSequence(ignoredPaths, fullIdPathBuffer))
                        {
                            continue;
                        }
                        if (!ContainsSequence(filteredPaths, fullIdPathBuffer))
                        {
                            if (shouldFilter())
                            {
                                filteredPaths.Add(fullIdPathBuffer.ToArray());
                            }
                            else
                            {
                                ignoredPaths.Add(fullIdPathBuffer.ToArray());
                                continue;
                            }
                            bool shouldFilter()
                            {
                                if (filterAllocations.Count == 0)
                                {
                                    return true;
                                }
                                var itemPath = data.GetItemPath(childId);
                                foreach (var filter in filterAllocations)
                                {
                                    if (itemPath.Contains(filter) && !ignoreAllocations.Any(itemPath.Contains))
                                    {
                                        if (logFiltered)
                                        {
                                            print($"FILTER   {itemPath}");
                                        }
                                        return true;
                                    }
                                }
                                if (logIgnored)
                                {
                                    print($"IGNORE   {itemPath}");
                                }
                                return false;
                            }
                        }
                        if (logAllocations)
                        {
                            print($"GC Alloc in frame {frameIndex}: {EditorUtility.FormatBytes(gcAlloc)}\n" +
                                  $"Path: {data.GetItemPath(childId)}\n");
                        }
                        result += gcAlloc;
                    }
                }
            }
            return result;
        }

        private static bool ContainsSequence(List<int[]> arrays, List<int> list)
        {
            foreach (var arr in arrays)
            {
                if (SequenceEqual(arr, list))
                {
                    return true;
                }
            }
            return false;

            // Unity 2019.4.40 doesn't support static local methods
            // ReSharper disable once LocalFunctionCanBeMadeStatic
            bool SequenceEqual(int[] arr, List<int> _list)
            {
                if (arr.Length != _list.Count)
                {
                    return false;
                }
                for (var i = 0; i < arr.Length; i++)
                {
                    if (arr[i] != _list[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
#else
        void Awake() {
            if (Application.isEditor) {
                Debug.LogWarning($"{nameof(MeasureMemoryAllocations)} is only supported in Unity 2019.1 or newer.", this);
            } else {
                gameObject.SetActive(false);
            }
        }
#endif
    }
}
