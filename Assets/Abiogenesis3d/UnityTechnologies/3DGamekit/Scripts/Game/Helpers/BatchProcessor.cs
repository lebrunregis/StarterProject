using System.Collections.Generic;
using UnityEngine;

namespace Gamekit3D
{
    public class BatchProcessor : MonoBehaviour
    {
        public delegate void BatchProcessing();

        static protected BatchProcessor s_Instance;
        static protected List<BatchProcessing> s_ProcessList;

        static BatchProcessor()
        {
            s_ProcessList = new List<BatchProcessing>();
        }

        static public void RegisterBatchFunction(BatchProcessing function)
        {
            s_ProcessList.Add(function);
        }

        static public void UnregisterBatchFunction(BatchProcessing function)
        {
            s_ProcessList.Remove(function);
        }

        // Update is called once per frame
        private void Update()
        {
            for (int i = 0; i < s_ProcessList.Count; ++i)
            {
                s_ProcessList[i]();
            }
        }

        [RuntimeInitializeOnLoadMethod]
        private static void Init()
        {
            if (s_Instance != null)
                return;

            GameObject obj = new("BatchProcessor");
            DontDestroyOnLoad(obj);
            s_Instance = obj.AddComponent<BatchProcessor>();
        }
    }

}