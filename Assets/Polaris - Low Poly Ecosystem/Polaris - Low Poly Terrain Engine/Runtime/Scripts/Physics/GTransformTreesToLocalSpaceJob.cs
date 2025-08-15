#if GRIFFIN
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Pinwheel.Griffin.Physic
{
#if GRIFFIN_BURST
    [BurstCompile(CompileSynchronously = false)]
#endif
    public struct GTransformTreesToLocalSpaceJob : IJobParallelFor
    {
        public NativeArray<GTreeInstance> instances;
        public Vector3 terrainSize;

        public void Execute(int index)
        {
            GTreeInstance tree = instances[index];
            Vector3 pos = new(
                tree.position.x * terrainSize.x,
                tree.position.y * terrainSize.y,
                tree.position.z * terrainSize.z);
            tree.position = pos;
            instances[index] = tree;
        }
    }
}
#endif
