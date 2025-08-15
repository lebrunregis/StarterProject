using System.ComponentModel;
#if AMD
using UnityEngine.AMD;
#endif

namespace CitrioN.SettingsMenuCreator.SRP
{
    #region General
    [DisplayName("Dynamic Resolution Enabled (HDRP) [Unity]")]
    public class Setting_DynamicResolution_Enabled : Setting_HDPR_DynamicResolutionSettings<bool>
    {
        public override string RuntimeName => "Dynamic Resolution";

        public override string EditorName => $"{RuntimeName} Enabled (HDRP) [Unity]";

        public Setting_DynamicResolution_Enabled()
        {
            defaultValue = false;
        }

#if UNITY_HDRP
    protected override object ApplySettingChangeWithValue(SettingsCollection settings, bool value)
    {
      var hdrp = HDRP;
      if (hdrp == null) { return null; }

      var currentPlatformSettings = hdrp.currentPlatformRenderPipelineSettings;
      currentPlatformSettings.dynamicResolutionSettings.enabled = value;
      hdrp.currentPlatformRenderPipelineSettings = currentPlatformSettings;

      return currentPlatformSettings.dynamicResolutionSettings.enabled;
    }

    public override List<object> GetCurrentValues(SettingsCollection settings)
    {
      return new List<object>() { ResolutionSettings.enabled };
    }
#endif
    }

#if UNITY_HDRP
  [DisplayName("Dynamic Resolution Type (HDRP) [Unity]")]
  public class Setting_DynamicResolutionType : Setting_HDPR_DynamicResolutionSettings<DynamicResolutionType>
  {
    public override string RuntimeName => "Dynamic Resolution Type";

    public override string EditorName => $"{RuntimeName} (HDRP) [Unity]";

    protected override object ApplySettingChangeWithValue(SettingsCollection settings, DynamicResolutionType value)
    {
      var hdrp = HDRP;
      if (hdrp == null) { return null; }

      var currentPlatformSettings = hdrp.currentPlatformRenderPipelineSettings;
      currentPlatformSettings.dynamicResolutionSettings.dynResType = value;
      hdrp.currentPlatformRenderPipelineSettings = currentPlatformSettings;

      return currentPlatformSettings.dynamicResolutionSettings.dynResType;
    }

    public override List<object> GetCurrentValues(SettingsCollection settings)
    {
      return new List<object>() { ResolutionSettings.dynResType };
    }
  }
#endif

#if UNITY_HDRP
  [DisplayName("Fallback Upscale Filter (HDRP) [Unity]")]
  public class Setting_FallbackUpscaleFilter : Setting_HDPR_DynamicResolutionSettings<DynamicResUpscaleFilter>
  {
    public override string RuntimeName => "Fallback Upscale Filter";

    public override string EditorName => $"{RuntimeName} (HDRP) [Unity]";

    public Setting_FallbackUpscaleFilter()
    {
      options.Clear();
      options.Add(new Common.StringToStringRelation("CatmullRom", "Catmull Rom"));
      options.Add(new Common.StringToStringRelation("ContrastAdaptiveSharpen", "Contrast Adaptive Sharpen"));
      options.Add(new Common.StringToStringRelation("EdgeAdaptiveScalingUpres", "FSR"));
      options.Add(new Common.StringToStringRelation("TAAU", "TAA Upscale"));

      defaultValue = DynamicResUpscaleFilter.CatmullRom;
    }

    protected override object ApplySettingChangeWithValue(SettingsCollection settings, DynamicResUpscaleFilter value)
    {
      var hdrp = HDRP;
      if (hdrp == null) { return null; }

      var currentPlatformSettings = hdrp.currentPlatformRenderPipelineSettings;
      currentPlatformSettings.dynamicResolutionSettings.upsampleFilter = value;
      hdrp.currentPlatformRenderPipelineSettings = currentPlatformSettings;

      return currentPlatformSettings.dynamicResolutionSettings.upsampleFilter;
    }

    public override List<object> GetCurrentValues(SettingsCollection settings)
    {
      return new List<object>() { ResolutionSettings.upsampleFilter };
    }
  }
#endif

    [DisplayName("Use Mip Bias (HDRP) [Unity]")]
    public class Setting_UseMipBias : Setting_HDPR_DynamicResolutionSettings<bool>
    {
        public override string RuntimeName => "Use Mip Bias";

        public override string EditorName => $"{RuntimeName} (HDRP) [Unity]";

        public Setting_UseMipBias()
        {
            defaultValue = false;
        }

#if UNITY_HDRP
    protected override object ApplySettingChangeWithValue(SettingsCollection settings, bool value)
    {
      var hdrp = HDRP;
      if (hdrp == null) { return null; }

      var currentPlatformSettings = hdrp.currentPlatformRenderPipelineSettings;
      currentPlatformSettings.dynamicResolutionSettings.useMipBias = value;
      hdrp.currentPlatformRenderPipelineSettings = currentPlatformSettings;

      return currentPlatformSettings.dynamicResolutionSettings.useMipBias;
    }

    public override List<object> GetCurrentValues(SettingsCollection settings)
    {
      return new List<object>() { ResolutionSettings.useMipBias };
    }
#endif
    }

    [DisplayName("Min Screen Percentage (HDRP) [Unity]")]
    public class Setting_MinScreenPercentage : Setting_HDPR_DynamicResolutionSettings<float>
    {
        public override string RuntimeName => "Min Screen Percentage";

        public override string EditorName => $"{RuntimeName} (HDRP) [Unity]";

        public Setting_MinScreenPercentage()
        {
            options.AddMinMaxRangeValues("50", "100");
            options.AddStepSize("0.5");
            options.AddValueSuffix(" %");

            defaultValue = 100f;
        }

#if UNITY_HDRP
    protected override object ApplySettingChangeWithValue(SettingsCollection settings, float value)
    {
      var hdrp = HDRP;
      if (hdrp == null) { return null; }

      var currentPlatformSettings = hdrp.currentPlatformRenderPipelineSettings;
      currentPlatformSettings.dynamicResolutionSettings.minPercentage = value;
      hdrp.currentPlatformRenderPipelineSettings = currentPlatformSettings;

      return currentPlatformSettings.dynamicResolutionSettings.minPercentage;
    }

    public override List<object> GetCurrentValues(SettingsCollection settings)
    {
      return new List<object>() { ResolutionSettings.minPercentage };
    }
#endif
    }

    [DisplayName("Max Screen Percentage (HDRP) [Unity]")]
    public class Setting_MaxScreenPercentage : Setting_HDPR_DynamicResolutionSettings<float>
    {
        public override string RuntimeName => "Max Screen Percentage";

        public override string EditorName => $"{RuntimeName} (HDRP) [Unity]";

        public Setting_MaxScreenPercentage()
        {
            options.AddMinMaxRangeValues("50", "100");
            options.AddStepSize("0.5");
            options.AddValueSuffix(" %");

            defaultValue = 100f;
        }

#if UNITY_HDRP
    protected override object ApplySettingChangeWithValue(SettingsCollection settings, float value)
    {
      var hdrp = HDRP;
      if (hdrp == null) { return null; }

      var currentPlatformSettings = hdrp.currentPlatformRenderPipelineSettings;
      currentPlatformSettings.dynamicResolutionSettings.maxPercentage = value;
      hdrp.currentPlatformRenderPipelineSettings = currentPlatformSettings;

      return currentPlatformSettings.dynamicResolutionSettings.maxPercentage;
    }

    public override List<object> GetCurrentValues(SettingsCollection settings)
    {
      return new List<object>() { ResolutionSettings.maxPercentage };
    }
#endif
    }
    #endregion

    #region DLSS
#if NVIDIA
  [DisplayName("DLSS Enabled (HDRP) [Unity 2021/2022]")]
  public class Setting_DLSS_Unity_Enabled : Setting_HDPR_DynamicResolutionSettings<bool>
  {
    public override string RuntimeName => "DLSS Enabled";

    public override string EditorName => $"{RuntimeName} (HDRP) [Unity 2021/2022]";

    public Setting_DLSS_Unity_Enabled()
    {
      defaultValue = false;
    }

#if UNITY_HDRP
    protected override object ApplySettingChangeWithValue(SettingsCollection settings, bool value)
    {
      var hdrp = HDRP;
      if (hdrp == null) { return null; }

      var currentPlatformSettings = hdrp.currentPlatformRenderPipelineSettings;
#pragma warning disable CS0618
      currentPlatformSettings.dynamicResolutionSettings.enableDLSS = value;
      hdrp.currentPlatformRenderPipelineSettings = currentPlatformSettings;

      return currentPlatformSettings.dynamicResolutionSettings.enableDLSS;
    }

    public override List<object> GetCurrentValues(SettingsCollection settings)
    {
      return new List<object>() { ResolutionSettings.enableDLSS };
#pragma warning restore CS0618
    }
#endif
  }

  [DisplayName("DLSS Use Optimal Settings (HDRP) [Unity]")]
  public class Setting_DLSS_Unity_UseOptimalSettings : Setting_HDPR_DynamicResolutionSettings<bool>
  {
    public override string RuntimeName => "DLSS Use Optimal Settings";

    public override string EditorName => $"{RuntimeName} (HDRP) [Unity]";

    public Setting_DLSS_Unity_UseOptimalSettings()
    {
      defaultValue = false;
    }

#if UNITY_HDRP
    protected override object ApplySettingChangeWithValue(SettingsCollection settings, bool value)
    {
      var hdrp = HDRP;
      if (hdrp == null) { return null; }

      var currentPlatformSettings = hdrp.currentPlatformRenderPipelineSettings;
      currentPlatformSettings.dynamicResolutionSettings.DLSSUseOptimalSettings = value;
      hdrp.currentPlatformRenderPipelineSettings = currentPlatformSettings;

      return currentPlatformSettings.dynamicResolutionSettings.DLSSUseOptimalSettings;
    }

    public override List<object> GetCurrentValues(SettingsCollection settings)
    {
      return new List<object>() { ResolutionSettings.DLSSUseOptimalSettings };
    }
#endif
  }

  [DisplayName("DLSS Sharpness (HDRP) [Unity]")]
  public class Setting_DLSS_Unity_Sharpness : Setting_HDPR_DynamicResolutionSettings<float>
  {
    public override string RuntimeName => "DLSS Sharpness";

    public override string EditorName => $"{RuntimeName} (HDRP) [Unity]";

    public Setting_DLSS_Unity_Sharpness()
    {
      options.AddMinMaxRangeValues("0.0", "1");
      options.AddStepSize("0.001");
      options.AddOneHundredMultiplierAndPercent();

      defaultValue = 0;
    }

#if UNITY_HDRP
    protected override object ApplySettingChangeWithValue(SettingsCollection settings, float value)
    {
      var hdrp = HDRP;
      if (hdrp == null) { return null; }

      var currentPlatformSettings = hdrp.currentPlatformRenderPipelineSettings;
      currentPlatformSettings.dynamicResolutionSettings.DLSSSharpness = value;
      hdrp.currentPlatformRenderPipelineSettings = currentPlatformSettings;

      return currentPlatformSettings.dynamicResolutionSettings.DLSSSharpness;
    }

    public override List<object> GetCurrentValues(SettingsCollection settings)
    {
      return new List<object>() { ResolutionSettings.DLSSSharpness };
    }
#endif
  }


  [DisplayName("DLSS Quality (HDRP) [Unity]")]
  public class Setting_DLSS_Unity_Quality : Setting_HDPR_DynamicResolutionSettings<UnityEngine.NVIDIA.DLSSQuality>
  {
    public override string RuntimeName => "DLSS Quality";

    public override string EditorName => $"{RuntimeName} (HDRP) [Unity]";

#if UNITY_HDRP
    protected override object ApplySettingChangeWithValue(SettingsCollection settings, UnityEngine.NVIDIA.DLSSQuality value)
    {
      var hdrp = HDRP;
      if (hdrp == null) { return null; }

      var currentPlatformSettings = hdrp.currentPlatformRenderPipelineSettings;
      currentPlatformSettings.dynamicResolutionSettings.DLSSPerfQualitySetting = Convert.ToUInt32(value);
      hdrp.currentPlatformRenderPipelineSettings = currentPlatformSettings;

      return (UnityEngine.NVIDIA.DLSSQuality)currentPlatformSettings.dynamicResolutionSettings.DLSSPerfQualitySetting;
    }

    public override List<object> GetCurrentValues(SettingsCollection settings)
    {
      return new List<object>() { ResolutionSettings.DLSSPerfQualitySetting };
    }
#endif
  }
#endif
    #endregion

    #region FSR 2
#if AMD
  [DisplayName("FSR 2 Sharpness Enabled (HDRP) [Unity]")]
  public class Setting_FSR2_Unity_Sharpness_Enabled : Setting_HDPR_DynamicResolutionSettings<bool>
  {
    public override string RuntimeName => "FSR 2 Sharpness Enabled";

    public override string EditorName => $"{RuntimeName} (HDRP) [Unity]";

    public Setting_FSR2_Unity_Sharpness_Enabled()
    {
      defaultValue = false;
    }

#if UNITY_HDRP
    protected override object ApplySettingChangeWithValue(SettingsCollection settings, bool value)
    {
      var hdrp = HDRP;
      if (hdrp == null) { return null; }

      var currentPlatformSettings = hdrp.currentPlatformRenderPipelineSettings;
      currentPlatformSettings.dynamicResolutionSettings.FSR2EnableSharpness = value;
      hdrp.currentPlatformRenderPipelineSettings = currentPlatformSettings;

      return currentPlatformSettings.dynamicResolutionSettings.FSR2EnableSharpness;
    }

    public override List<object> GetCurrentValues(SettingsCollection settings)
    {
      return new List<object>() { ResolutionSettings.FSR2EnableSharpness };
    }
#endif
  }

  [DisplayName("FSR 2 Sharpness (HDRP) [Unity]")]
  public class Setting_FSR2_Unity_Sharpness : Setting_HDPR_DynamicResolutionSettings<float>
  {
    public override string RuntimeName => "FSR 2 Sharpness";

    public override string EditorName => $"{RuntimeName} (HDRP) [Unity]";

    public Setting_FSR2_Unity_Sharpness()
    {
      options.AddMinMaxRangeValues("0.0", "1");
      options.AddStepSize("0.001");
      options.AddOneHundredMultiplierAndPercent();

      defaultValue = 0;
    }

#if UNITY_HDRP
    protected override object ApplySettingChangeWithValue(SettingsCollection settings, float value)
    {
      var hdrp = HDRP;
      if (hdrp == null) { return null; }

      var currentPlatformSettings = hdrp.currentPlatformRenderPipelineSettings;
      currentPlatformSettings.dynamicResolutionSettings.FSR2Sharpness = value;
      hdrp.currentPlatformRenderPipelineSettings = currentPlatformSettings;

      return currentPlatformSettings.dynamicResolutionSettings.FSR2Sharpness;
    }

    public override List<object> GetCurrentValues(SettingsCollection settings)
    {
      return new List<object>() { ResolutionSettings.FSR2Sharpness };
    }
#endif
  }

  [DisplayName("FSR 2 Use Optimal Settings (HDRP) [Unity]")]
  public class Setting_FSR2_Unity_UseOptimalSettings : Setting_HDPR_DynamicResolutionSettings<bool>
  {
    public override string RuntimeName => "FSR 2 Use Optimal Settings";

    public override string EditorName => $"{RuntimeName} (HDRP) [Unity]";

    public Setting_FSR2_Unity_UseOptimalSettings()
    {
      defaultValue = false;
    }

#if UNITY_HDRP
    protected override object ApplySettingChangeWithValue(SettingsCollection settings, bool value)
    {
      var hdrp = HDRP;
      if (hdrp == null) { return null; }

      var currentPlatformSettings = hdrp.currentPlatformRenderPipelineSettings;
      currentPlatformSettings.dynamicResolutionSettings.FSR2UseOptimalSettings = value;
      hdrp.currentPlatformRenderPipelineSettings = currentPlatformSettings;

      return currentPlatformSettings.dynamicResolutionSettings.FSR2UseOptimalSettings;
    }

    public override List<object> GetCurrentValues(SettingsCollection settings)
    {
      return new List<object>() { ResolutionSettings.FSR2UseOptimalSettings };
    }
#endif
  }

  [DisplayName("FSR 2 Quality (HDRP) [Unity]")]
  public class Setting_FSR2_Unity_Quality : Setting_HDPR_DynamicResolutionSettings<FSR2Quality>
  {
    public override string RuntimeName => "FSR 2 Quality";

    public override string EditorName => $"{RuntimeName} (HDRP) [Unity]";

    public Setting_FSR2_Unity_Quality()
    {
      defaultValue = FSR2Quality.Balanced;
    }

#if UNITY_HDRP
    protected override object ApplySettingChangeWithValue(SettingsCollection settings, FSR2Quality value)
    {
      var hdrp = HDRP;
      if (hdrp == null) { return null; }

      var currentPlatformSettings = hdrp.currentPlatformRenderPipelineSettings;
      currentPlatformSettings.dynamicResolutionSettings.FSR2QualitySetting = Convert.ToUInt32(value);
      hdrp.currentPlatformRenderPipelineSettings = currentPlatformSettings;

      return (FSR2Quality)currentPlatformSettings.dynamicResolutionSettings.FSR2QualitySetting;
    }

    public override List<object> GetCurrentValues(SettingsCollection settings)
    {
      return new List<object>() { ResolutionSettings.FSR2QualitySetting };
    }
#endif
  }
#endif
    #endregion
}
