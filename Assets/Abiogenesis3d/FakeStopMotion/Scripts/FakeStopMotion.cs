using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Abiogenesis3d
{
    [Serializable]
    public struct StoredTransform
    {
        public Transform original;

        // world
        // bool isGlobal;
        // public Vector3 position;
        // public Quaternion rotation;
        // local
        public Vector3 localPosition;
        public Quaternion localRotation;

        public Vector3 localScale;

        public StoredTransform(Transform t) // , bool isGlobal = true
        {
            original = t;

            // this.isGlobal = isGlobal;
            // position = t.position;
            // rotation = t.rotation;

            localPosition = t.localPosition;
            localRotation = t.localRotation;

            localScale = t.localScale;
        }

        public void Restore()
        {
            // if (isGlobal) original.SetPositionAndRotation(position, rotation); else
            original.SetLocalPositionAndRotation(localPosition, localRotation);
            original.localScale = localScale;
        }
    }

    public class FakeStopMotion : MonoBehaviour
    {
        [Range(1, 60)]
        public float framesPerSecond = 12;

        public Transform rootBone;
        [Header("Snap RootBone Rotation")]
        [Tooltip("Set values by dividing 360 degrees. Set 0 to disable")]
        [Range(0, 8)] public int divisions360 = 5;
        public Vector3 snapRotationAngles;

        [HideInInspector] public bool isPaused;
        [HideInInspector] public float lastTime;

        [HideInInspector] public List<Transform> transforms;
        [HideInInspector] public List<StoredTransform> originals;
        [HideInInspector] public List<StoredTransform> rendered;

        private void Start()
        {
            ResetTimer();
        }

        private void OnValidate()
        {
            if (divisions360 > 0) snapRotationAngles = Vector3.one * 360 / Mathf.Pow(2, divisions360);
            else snapRotationAngles = default;
        }

        private void OnEnable()
        {
            if (!rootBone)
            {
                var animator = GetComponent<Animator>();
                if (animator)
                {
                    if (animator.isHuman)
                    {
                        rootBone = animator.GetBoneTransform(HumanBodyBones.Hips);
                        if (!rootBone) Debug.Log("Root bone was not assigned.");
                    }
                    else Debug.Log("Rig is not humanoid, cannot auto find root Hips bone.");
                }
            }

            var ignored = new List<Transform>(
                GetComponentsInChildren<FakeStopMotionIgnore>()
                .Select(sm => sm.transform)
            );

            transforms = new List<Transform>();

            // NOTE: defined with null to be able to call itself
            Action<Transform> addWithCondition = null;
            addWithCondition = (t) =>
            {
                if (ignored.Contains(t)) return;

                transforms.Add(t);

                foreach (Transform child in t)
                    addWithCondition(child);
            };
            addWithCondition(rootBone);
        }

        public void PauseTimer() { isPaused = true; }
        public void UnpauseTimer() { isPaused = false; }

        [Tooltip("Use to update force current frame update.")]
        public void ResetTimer()
        {
            lastTime = Time.time;
        }

        private bool ShouldUpdate()
        {
            // initial update
            if (rendered.Count == 0) return true;
            if (isPaused) return false;

            var timePassed = Time.time - lastTime;

            var interval = 1 / framesPerSecond;
            var shouldUpdate = timePassed > interval;

            return shouldUpdate;
        }

        private void LateUpdate()
        {
            StoreTransforms(originals);

            if (ShouldUpdate())
            {
                lastTime = Time.time;
                StoreTransforms(rendered);
            }
            else
            {
                // override transforms with last stored
                RestoreTransforms(rendered);
            }

            // in case other code touches the transforms at end of frame, restore them last
            Utils.RunAtEndOfFrameOrdered(() =>
            {
                RestoreTransforms(originals);
            }, 10, this);

            // snap rotation of root bone
            if (snapRotationAngles != default)
            {
                rootBone.rotation = Quaternion.Euler(
                    Mathf.Round(rootBone.eulerAngles.x / snapRotationAngles.x) * snapRotationAngles.x,
                    Mathf.Round(rootBone.eulerAngles.y / snapRotationAngles.y) * snapRotationAngles.y,
                    Mathf.Round(rootBone.eulerAngles.z / snapRotationAngles.z) * snapRotationAngles.z
                );
            }
        }

        private void StoreTransforms(List<StoredTransform> ts)
        {
            // initialize list if empty
            if (ts.Count == 0)
                ts.AddRange(Enumerable.Repeat<StoredTransform>(default, transforms.Count));

            // store current transforms into given list
            for (int i = 0; i < transforms.Count; ++i)
                ts[i] = new StoredTransform(transforms[i]);
        }

        private void RestoreTransforms(List<StoredTransform> ts)
        {
            for (int i = 0; i < ts.Count; ++i)
                ts[i].Restore();
        }
    }
}
