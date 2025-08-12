using CitrioN.Common;
using UnityEngine;
using UnityEngine.Rendering;
#if UNITY_HDRP
using UnityEngine.Rendering.HighDefinition;
#endif

namespace CitrioN.SettingsMenuCreator.SRP
{
  [MenuOrder(600)]
  [ExcludeFromMenuSelection]
  [MenuPath("Render Pipeline/Dynamic Resolution")]
  public abstract class Setting_HDPR_DynamicResolutionSettings<T1> : Setting_Generic_Unity<T1>
  {
#if UNITY_HDRP
    [SerializeField]
    [Tooltip("The HDRP Asset to apply the setting to.\n" +
         "If no asset is referenced the currently active one will be used.")]
    protected HDRenderPipelineAsset renderPipelineAssetOverride; 
#endif

    public override bool StoreValueInternally => true;

#if UNITY_HDRP
    public HDRenderPipelineAsset HDRP
    {
      get
      {
        if (renderPipelineAssetOverride != null)
        {
          return renderPipelineAssetOverride;
        }
        if (RenderPipelineUtility.GetCurrentRenderPipelineAsset<HDRenderPipelineAsset>(out var hdrp))
        {
          return hdrp;
        }
        return null;
      }
    } 

    public GlobalDynamicResolutionSettings ResolutionSettings
    {
      get
      {
        HDRenderPipelineAsset hdrp = HDRP;
        if (hdrp == null) { return default; }
        return hdrp.currentPlatformRenderPipelineSettings.dynamicResolutionSettings;
      }
    }
#endif
  }
}
