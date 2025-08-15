#if GRIFFIN
using Unity.Mathematics;

namespace Pinwheel.Griffin
{
    public static class GMath
    {
        public static float Float2Cross(float2 lhs, float2 rhs)
        {
            return lhs.y * rhs.x - lhs.x * rhs.y;
        }
    }
}
#endif
