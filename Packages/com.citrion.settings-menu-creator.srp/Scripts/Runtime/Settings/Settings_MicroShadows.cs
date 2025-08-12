using CitrioN.Common;
using System.ComponentModel;
using UnityEngine;

namespace CitrioN.SettingsMenuCreator.SRP
{
  [MenuOrder(810)]
  [ExcludeFromMenuSelection]
  [MenuPath("Post Processing/Micro Shadows")]
  public abstract class Setting_MicroShadows<T> : Setting_Generic_VolumeProfile_Extended<T,
#if UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.MicroShadowing
#elif UNITY_URP
    UnityEngine.Rendering.VolumeComponent
#else
    ScriptableObject
#endif
    >
  {
    public override string RuntimeName => GetType().Name.Replace("Setting_", "").Replace("_", "").SplitCamelCase();
    public override string EditorNamePrefix => "[PP]";
  }

  [DisplayName("Micro Shadows Active (HDRP)")]
  public class Setting_MicroShadows_Active : Setting_MicroShadows<bool>
  {
    public override string EditorName => "Micro Shadows Active (HDRP)";

    public override string FieldName => "active";

    public Setting_MicroShadows_Active()
    {
      defaultValue = true;
    }
  }

  [DisplayName("Micro Shadows Enable (HDRP)")]
  public class Setting_MicroShadows_Enable : Setting_MicroShadows<bool>
  {
    public override string EditorName => "Micro Shadows Enable (HDRP)";

    public override string FieldName => "enable";

    public Setting_MicroShadows_Enable()
    {
      defaultValue = true;
    }
  }

  [DisplayName("Micro Shadows Opacity (HDRP)")]
  public class Setting_MicroShadows_Opacity : Setting_MicroShadows<float>
  {
    public override string EditorName => "Micro Shadows Opacity (HDRP)";

    public override string FieldName => "opacity";

    public Setting_MicroShadows_Opacity()
    {
      options.AddMinMaxRangeValues("0", "1");
      options.AddStepSize("0.01");
      options.AddOneHundredMultiplierAndPercent();

      defaultValue = 1f;
    }
  }
}