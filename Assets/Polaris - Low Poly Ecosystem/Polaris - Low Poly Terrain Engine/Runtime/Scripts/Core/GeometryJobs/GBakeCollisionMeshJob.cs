using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Pinwheel.Griffin
{
    public struct GBakeCollisionMeshJob : IJobParallelFor
    {
        [ReadOnly]
        public NativeArray<int> instanceIds;

        public void Execute(int index)
        {
            Physics.BakeMesh(instanceIds[index], false);
        }
    }
}
