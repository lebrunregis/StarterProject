using CitrioN.Common;
using System.ComponentModel;
using UnityEngine;

namespace CitrioN.SettingsMenuCreator.SRP
{
  [MenuOrder(1100)]
  [MenuPath("Quality/Shadow/")]
  [DisplayName("Shadow Cascades (HDRP)")]
  public class Setting_ShadowCascades_HDRP : Setting_Generic_VolumeProfile_Extended<int,
#if UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.HDShadowSettings
#elif UNITY_URP
    UnityEngine.Rendering.VolumeComponent
#else
    ScriptableObject
#endif
    >
  {
    public override string EditorNamePrefix => "[Shadow]";

    public override string EditorName => "Shadow Cascades (HDRP)";

    public override string FieldName => "cascadeShadowSplitCount";

    public Setting_ShadowCascades_HDRP()
    {
      options.AddMinMaxRangeValues("1", "4");
      options.AddStepSize("1");

      defaultValue = 4;
    }
  }

  [MenuOrder(1100)]
  [MenuPath("Quality/Shadow/")]
  [DisplayName("Shadow Cascades Transmission Multiplier (HDRP)")]
  public class Setting_ShadowCascades_HDRP_TransmissionMultiplier : Setting_Generic_VolumeProfile_Extended<float,
#if UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.HDShadowSettings
#elif UNITY_URP
    UnityEngine.Rendering.VolumeComponent
#else
    ScriptableObject
#endif
    >
  {
    public override string EditorNamePrefix => "[Shadow]";

    public override string EditorName => "Shadow Cascades Transmission Multiplier (HDRP)";

    public override string FieldName => "directionalTransmissionMultiplier";

    public Setting_ShadowCascades_HDRP_TransmissionMultiplier()
    {
      options.AddMinMaxRangeValues("0", "1");
      options.AddStepSize("0.01");

      defaultValue = 1;
    }
  } 
}