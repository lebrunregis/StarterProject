#if GRIFFIN
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Pinwheel.Griffin
{
#if GRIFFIN_BURST
    [BurstCompile(CompileSynchronously = false)]
#endif
    public struct GSampleInstanceJob : IJobParallelFor
    {
        [WriteOnly]
        public NativeArray<bool> cullResult;
        [WriteOnly]
        public NativeArray<GPrototypeInstanceInfo> instanceInfo;

        [ReadOnly]
        public GTextureNativeDataDescriptor<Color32> mask;
        [ReadOnly]
        public NativeArray<int> selectedPrototypeIndices;

        public float minRotation;
        public float maxRotation;

        public Vector3 minScale;
        public Vector3 maxScale;

        public int seed;

        public void Execute(int index)
        {

            Unity.Mathematics.Random rand = Unity.Mathematics.Random.CreateFromIndex((uint)(index ^ seed));
            Vector2 uv = new(rand.NextFloat(), rand.NextFloat());
            float maskValue = GJobCommon.GetColorBilinear(mask, uv).r;
            if (rand.NextFloat() > maskValue)
            {
                cullResult[index] = false;
            }
            else
            {
                cullResult[index] = true;
                GPrototypeInstanceInfo info = new();
                info.prototypeIndex = selectedPrototypeIndices[rand.NextInt(0, selectedPrototypeIndices.Length)];
                info.position = new Vector3(uv.x, 0, uv.y);
                info.rotation = Quaternion.Euler(0, rand.NextFloat(minRotation, maxRotation), 0);
                info.scale = Vector3.Lerp(minScale, maxScale, rand.NextFloat());
                instanceInfo[index] = info;
            }
        }
    }
}
#endif
