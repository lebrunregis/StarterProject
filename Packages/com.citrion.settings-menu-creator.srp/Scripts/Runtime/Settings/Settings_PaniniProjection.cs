using CitrioN.Common;
using System.ComponentModel;
using UnityEngine;

namespace CitrioN.SettingsMenuCreator.SRP
{
  [MenuOrder(810)]
  [ExcludeFromMenuSelection]
  [MenuPath("Post Processing/Panini Projection")]
  public abstract class Setting_PaniniProjection<T> : Setting_Generic_VolumeProfile_Extended<T,
#if UNITY_URP
    UnityEngine.Rendering.Universal.PaniniProjection
#elif UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.PaniniProjection
#else
    ScriptableObject
#endif
    >
  {
    public override string RuntimeName => GetType().Name.Replace("Setting_", "").Replace("_", "").SplitCamelCase();
    public override string EditorNamePrefix => "[PP]";
  }

  [DisplayName("Panini Projection Active (URP & HDRP)")]
  public class Setting_PaniniProjection_Active : Setting_PaniniProjection<bool>
  {
    public override string EditorName => "Panini Projection Active (URP & HDRP)";

    public override string FieldName => "active";

    public Setting_PaniniProjection_Active()
    {
      defaultValue = true;
    }
  }

  [DisplayName("Panini Projection Distance (URP & HDRP)")]
  public class Setting_PaniniProjection_Distance : Setting_PaniniProjection<float>
  {
    public override string EditorName => "Panini Projection Distance (URP & HDRP)";

    public override string FieldName => "distance";

    public Setting_PaniniProjection_Distance()
    {
      options.AddMinMaxRangeValues("0", "1");
      options.AddStepSize("0.01");

      defaultValue = 0.0f;
    }
  }

  [DisplayName("Panini Projection Crop To Fit (URP & HDRP)")]
  public class Setting_PaniniProjection_CropToFit : Setting_PaniniProjection<float>
  {
    public override string EditorName => "Panini Projection Crop To Fit (URP & HDRP)";

    public override string FieldName => "cropToFit";

    public Setting_PaniniProjection_CropToFit()
    {
      options.AddMinMaxRangeValues("0", "1");
      options.AddStepSize("0.01");

      defaultValue = 1f;
    }
  }
}