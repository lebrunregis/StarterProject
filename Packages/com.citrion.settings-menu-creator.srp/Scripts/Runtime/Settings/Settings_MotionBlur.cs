using CitrioN.Common;
using System.ComponentModel;
using UnityEngine;

namespace CitrioN.SettingsMenuCreator.SRP
{
  [MenuOrder(810)]
  [ExcludeFromMenuSelection]
  [MenuPath("Post Processing/Motion Blur")]
  public abstract class Setting_MotionBlur<T> : Setting_Generic_VolumeProfile_Extended<T,
#if UNITY_URP
    UnityEngine.Rendering.Universal.MotionBlur
#elif UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.MotionBlur
#else
    ScriptableObject
#endif
    >
  {
    public override string RuntimeName => GetType().Name.Replace("Setting_", "").Replace("_", "").SplitCamelCase();
    public override string EditorNamePrefix => "[PP]";
  }

  [DisplayName("Motion Blur Active (URP & HDRP)")]
  public class Setting_MotionBlur_Active : Setting_MotionBlur<bool>
  {
    public override string EditorName => "Motion Blur Active (URP & HDRP)";

    public override string FieldName => "active";

    public Setting_MotionBlur_Active()
    {
      defaultValue = true;
    }
  }

  [DisplayName("Motion Blur Intensity (URP & HDRP)")]
  public class Setting_MotionBlur_Intensity : Setting_MotionBlur<float>
  {
    public override string EditorName => "Motion Blur Intensity (URP & HDRP)";

    public override string FieldName => "intensity";

    public Setting_MotionBlur_Intensity()
    {
      options.AddMinMaxRangeValues("0", "2");
      options.AddStepSize("0.01");
      defaultValue = 0.0f;
    }
  }

  [DisplayName("Motion Blur Quality (URP)")]
  public class Setting_MotionBlur_Quality_URP : Setting_MotionBlur<
#if UNITY_URP
    UnityEngine.Rendering.Universal.MotionBlurQuality
#else
    int
#endif
    >
  {
    public override string RuntimeName => "Motion Blur Quality (URP)";

    public override string EditorName => "Motion Blur Quality (URP)";

    public override string FieldName => "quality";

    public Setting_MotionBlur_Quality_URP()
    {
#if UNITY_URP
      defaultValue = UnityEngine.Rendering.Universal.MotionBlurQuality.Medium;
#endif
    }
  }

  [DisplayName("Motion Blur Quality (HDRP)")]
  public class Setting_MotionBlur_Quality_HDRP : Setting_MotionBlur<
#if UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.ScalableSettingLevelParameter.Level
#else
    int
#endif
    >
  {
    public override string RuntimeName => "Motion Blur Quality (HDRP)";

    public override string EditorName => "Motion Blur Quality (HDRP)";

    public override string FieldName => "quality";

    public Setting_MotionBlur_Quality_HDRP()
    {
#if UNITY_HDRP
      defaultValue = UnityEngine.Rendering.HighDefinition.ScalableSettingLevelParameter.Level.Medium;
#endif
    }
  } 

  // TODO Enable once custom quality support is available
  //[DisplayName("Motion Blur Sample Count")]
  //public class Setting_MotionBlur_SampleCount : Setting_MotionBlur<int>
  //{
  //  public override string FieldName => nameof(MotionBlur.sampleCount);

  //  public Setting_MotionBlur_SampleCount()
  //  {
  //    options.AddMinMaxRangeValues("2", "64");
  //    options.AddStepSize("1");

  //    defaultValue = 8;
  //  }
  //}

  [DisplayName("Motion Blur Maximum Velocity (HDRP)")]
  public class Setting_MotionBlur_MaximumVelocity : Setting_MotionBlur<float>
  {
    public override string EditorName => "Motion Blur Maximum Velocity (HDRP)";

    public override string FieldName => "maximumVelocity";

    public Setting_MotionBlur_MaximumVelocity()
    {
      options.AddMinMaxRangeValues("0", "1500");
      options.AddStepSize("10");

      defaultValue = 200;
    }
  }

  [DisplayName("Motion Blur Minimum Velocity (HDRP)")]
  public class Setting_MotionBlur_MinimumVelocity : Setting_MotionBlur<float>
  {
    public override string EditorName => "Motion Blur Minimum Velocity (HDRP)";

    public override string FieldName => "minimumVelocity";

    public Setting_MotionBlur_MinimumVelocity()
    {
      options.AddMinMaxRangeValues("0", "64");
      options.AddStepSize("1");

      defaultValue = 2;
    }
  }
}