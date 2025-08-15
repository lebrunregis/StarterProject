#if GRIFFIN
using UnityEngine;

namespace Pinwheel.Griffin.Rendering
{
    public interface IGGrassMaterialConfigurator
    {
        void Configure(GStylizedTerrain terrain, int prototypeIndex, MaterialPropertyBlock propertyBlock);
    }
}
#endif
