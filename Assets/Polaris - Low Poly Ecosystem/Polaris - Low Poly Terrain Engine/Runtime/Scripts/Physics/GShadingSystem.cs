#if GRIFFIN
namespace Pinwheel.Griffin
{
    public enum GShadingSystem
    {
        Polaris,
#if __MICROSPLAT_POLARIS__
        MicroSplat
#endif
    }
}
#endif
