using CitrioN.Common;
using System.ComponentModel;
using UnityEngine;

namespace CitrioN.SettingsMenuCreator.SRP
{
  [MenuOrder(810)]
  [ExcludeFromMenuSelection]
  [MenuPath("Post Processing/Color Adjustments")]
  public abstract class Setting_ColorAdjustments<T> : Setting_Generic_VolumeProfile_Extended<T,
#if UNITY_URP
    UnityEngine.Rendering.Universal.ColorAdjustments
#elif UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.ColorAdjustments
#else
    ScriptableObject
#endif
    >
  {
    public override string RuntimeName => GetType().Name.Replace("Setting_", "").Replace("_", "").SplitCamelCase();

    public override string EditorNamePrefix => "[PP]";
  }

  [DisplayName("Color Adjustments Active (URP & HDRP)")]
  public class Setting_ColorAdjustments_Active : Setting_ColorAdjustments<bool>
  {
    public override string EditorName => "Color Adjustments Active (URP & HDRP)";

    public override string FieldName => "active";

    public Setting_ColorAdjustments_Active()
    {
      defaultValue = true;
    }
  }

  [DisplayName("Color Adjustments Post-Exposure (URP & HDRP)")]
  public class Setting_ColorAdjustments_PostExposure : Setting_ColorAdjustments<float>
  {
    public override string EditorName => "Color Adjustments Post-Exposure (URP & HDRP)";

    public override string FieldName => "postExposure";

    public Setting_ColorAdjustments_PostExposure()
    {
      options.AddMinMaxRangeValues("-10", "10");
      options.AddStepSize("0.1");

      defaultValue = 0;
    }
  }

  [DisplayName("Color Adjustments Contrast (URP & HDRP)")]
  public class Setting_ColorAdjustments_Contrast : Setting_ColorAdjustments<float>
  {
    public override string EditorName => "Color Adjustments Contrast (URP & HDRP)";

    public override string FieldName => "contrast";

    public Setting_ColorAdjustments_Contrast()
    {
      options.AddMinMaxRangeValues("-100", "100");
      options.AddStepSize("1");

      defaultValue = 0;
    }
  }

  // TODO Enable once color support has been added
  //[DisplayName("Color Adjustments Color Filter")]
  //public class Setting_ColorAdjustments_ColorFilter : Setting_ColorAdjustments<UnityEngine.Color>
  //{
  //  public override string FieldName => nameof(ColorAdjustments.colorFilter);

  //  public Setting_ColorAdjustments_ColorFilter()
  //  {
  //    defaultValue = UnityEngine.Color.white;
  //  }
  //}

  [DisplayName("Color Adjustments Hue Shift (URP & HDRP)")]
  public class Setting_ColorAdjustments_HueShift : Setting_ColorAdjustments<float>
  {
    public override string EditorName => "Color Adjustments Hue Shift (URP & HDRP)";

    public override string FieldName => "hueShift";

    public Setting_ColorAdjustments_HueShift()
    {
      options.AddMinMaxRangeValues("-180", "180");
      options.AddStepSize("1");

      defaultValue = 0;
    }
  }

  [DisplayName("Color Adjustments Saturation (URP & HDRP)")]
  public class Setting_ColorAdjustments_Saturation : Setting_ColorAdjustments<float>
  {
    public override string EditorName => "Color Adjustments Saturation (URP & HDRP)";

    public override string FieldName => "saturation";

    public Setting_ColorAdjustments_Saturation()
    {
      options.AddMinMaxRangeValues("-100", "100");
      options.AddStepSize("1");

      defaultValue = 0;
    }
  }
}