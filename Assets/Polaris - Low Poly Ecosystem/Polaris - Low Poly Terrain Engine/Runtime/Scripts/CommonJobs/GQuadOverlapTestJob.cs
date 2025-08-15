#if GRIFFIN
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace Pinwheel.Griffin
{
    public struct GQuadOverlapTestJob : IJobParallelFor
    {
        [ReadOnly]
        public NativeArray<Rect> rectsToTest;
        public GQuad2D quad;

        [WriteOnly]
        public NativeArray<bool> result;

        public void Execute(int index)
        {
            Rect r = rectsToTest[index];
            result[index] = GJobCommon.IsOverlap(r, quad);
        }
    }
}
#endif
