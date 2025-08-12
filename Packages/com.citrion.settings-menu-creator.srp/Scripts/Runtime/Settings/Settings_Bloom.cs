using CitrioN.Common;
using System.ComponentModel;
using UnityEngine;

namespace CitrioN.SettingsMenuCreator.SRP
{
  [MenuOrder(810)]
  [ExcludeFromMenuSelection]
  [MenuPath("Post Processing/Bloom")]
  public abstract class Setting_Bloom<T> : Setting_Generic_VolumeProfile_Extended<T,
#if UNITY_URP
    UnityEngine.Rendering.Universal.Bloom
#elif UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.Bloom
#else
    ScriptableObject
#endif
    >
  {
    public override string RuntimeName => GetType().Name.Replace("Setting_", "").Replace("_", "").SplitCamelCase();

    public override string EditorNamePrefix => "[PP]";
  }

  [DisplayName("Bloom Active (URP & HDRP)")]
  public class Setting_Bloom_Active : Setting_Bloom<bool>
  {
    public override string EditorName => "Bloom Active (URP & HDRP)";

    public override string FieldName => "active";

    public Setting_Bloom_Active()
    {
      defaultValue = true;
    }
  }

  [DisplayName("Bloom Quality (HDRP)")]
  public class Setting_Bloom_Quality : Setting_Bloom<
#if UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.ScalableSettingLevelParameter.Level
#else
    int
#endif
    >
  {
    public override string EditorName => "Bloom Quality (HDRP)";

    public override string FieldName => "quality";

    public Setting_Bloom_Quality()
    {
#if UNITY_HDRP
      defaultValue = UnityEngine.Rendering.HighDefinition.ScalableSettingLevelParameter.Level.Medium;
#endif
    }
  }

  [DisplayName("Bloom Threshold (URP & HDRP)")]
  public class Setting_Bloom_Threshold : Setting_Bloom<float>
  {
    public override string EditorName => "Bloom Threshold (URP & HDRP)";

    public override string FieldName => "threshold";

    public Setting_Bloom_Threshold()
    {
      options.AddMinMaxRangeValues("0", "100");
      options.AddStepSize("0.5");

      defaultValue = 0;
    }
  }

  [DisplayName("Bloom Intensity (URP & HDRP)")]
  public class Setting_Bloom_Intensity : Setting_Bloom<float>
  {
    public override string EditorName => "Bloom Intensity (URP & HDRP)";

    public override string FieldName => "intensity";

    public Setting_Bloom_Intensity()
    {
      options.AddMinMaxRangeValues("0", "1");
      options.AddStepSize("0.01");
      options.AddOneHundredMultiplierAndPercent();

      defaultValue = 0.25f;
    }
  }

  [DisplayName("Bloom Scatter (URP & HDRP)")]
  public class Setting_Bloom_Scatter : Setting_Bloom<float>
  {
    public override string EditorName => "Bloom Scatter (URP & HDRP)";

    public override string FieldName => "scatter";

    public Setting_Bloom_Scatter()
    {
      options.AddMinMaxRangeValues("0", "1");
      options.AddStepSize("0.01");

      defaultValue = 0.7f;
    }
  }

  // TODO Enable once color support has been added
  //[DisplayName("Bloom Tint")]
  //public class Setting_Bloom_Tint : Setting_Bloom<UnityEngine.Color>
  //{
  //  public override string FieldName => "tint";

  //  public Setting_Bloom_Tint()
  //  {
  //    defaultValue = UnityEngine.Color.white;
  //  }
  //}

  // TODO Enable once Texture2D support has been added
  //[DisplayName("Bloom Lens Dirt Texture")]
  //public class Setting_Bloom_LensDirt_Texture : Setting_Bloom<UnityEngine.Texture2D>
  //{
  //  public override string FieldName => "dirtTexture";

  //  public Setting_Bloom_LensDirt_Texture()
  //  {
  //  }
  //}

  [DisplayName("Bloom Lens Dirt Intensity (URP & HDRP)")]
  public class Setting_Bloom_LensDirt_Intensity : Setting_Bloom<float>
  {
    public override string EditorName => "Bloom Lens Dirt Intensity (URP & HDRP)";

    public override string FieldName => "dirtIntensity";

    public Setting_Bloom_LensDirt_Intensity()
    {
      options.AddMinMaxRangeValues("0", "10");
      options.AddStepSize("0.1");

      defaultValue = 0;
    }
  }
}