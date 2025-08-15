using CitrioN.Common;
using System.ComponentModel;

namespace CitrioN.SettingsMenuCreator.SRP
{
    [MenuOrder(810)]
    [ExcludeFromMenuSelection]
    [MenuPath("Post Processing/Ambient Occlusion")]
    public abstract class Setting_AmbientOcclusion<T> : Setting_Generic_VolumeProfile_Extended<T,
#if UNITY_HDRP && !UNITY_2022_3_OR_NEWER
    UnityEngine.Rendering.HighDefinition.AmbientOcclusion
#elif UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.ScreenSpaceAmbientOcclusion
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

    [DisplayName("Ambient Occlusion Active (HDRP)")]
    public class Setting_AmbientOcclusion_Active : Setting_AmbientOcclusion<bool>
    {
        public override string EditorName => "Ambient Occlusion Active (HDRP)";

        public override string FieldName => "active";

        public Setting_AmbientOcclusion_Active()
        {
            defaultValue = true;
        }
    }

    [DisplayName("Ambient Occlusion Intensity (HDRP)")]
    public class Setting_AmbientOcclusion_Intensity : Setting_AmbientOcclusion<float>
    {
        public override string EditorName => "Ambient Occlusion Intensity (HDRP)";

        public override string FieldName => "intensity";

        public Setting_AmbientOcclusion_Intensity()
        {
            options.AddMinMaxRangeValues("0", "4");
            options.AddStepSize("0.1");

            defaultValue = 1f;
        }
    }

    [DisplayName("Ambient Occlusion Direct Lighting Strength (HDRP)")]
    public class Setting_AmbientOcclusion_DirectLightingStrength : Setting_AmbientOcclusion<float>
    {
        public override string EditorName => "Ambient Occlusion Direct Lighting Strength (HDRP)";

        public override string FieldName => "directLightingStrength";

        public Setting_AmbientOcclusion_DirectLightingStrength()
        {
            options.AddMinMaxRangeValues("0", "1");
            options.AddStepSize("0.01");
            options.AddOneHundredMultiplierAndPercent();

            defaultValue = 0.5f;
        }
    }

    [DisplayName("Ambient Occlusion Radius (HDRP)")]
    public class Setting_AmbientOcclusion_Radius : Setting_AmbientOcclusion<float>
    {
        public override string EditorName => "Ambient Occlusion Radius (HDRP)";

        public override string FieldName => "radius";

        public Setting_AmbientOcclusion_Radius()
        {
            options.AddMinMaxRangeValues("0.25", "5");
            options.AddStepSize("0.05");

            defaultValue = 2f;
        }
    }

    [DisplayName("Ambient Occlusion Quality (HDRP)")]
    public class Setting_AmbientOcclusion_Quality : Setting_AmbientOcclusion<
#if UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.ScalableSettingLevelParameter.Level
#else
      int
#endif
      >
    {
        public override string EditorName => "Ambient Occlusion Quality (HDRP)";

        public override string FieldName => "quality";

        public Setting_AmbientOcclusion_Quality()
        {
#if UNITY_HDRP
      defaultValue = UnityEngine.Rendering.HighDefinition.ScalableSettingLevelParameter.Level.Medium;
#endif
        }
    }

    // TODO Enable once custom quality support is available
    //[DisplayName("Ambient Occlusion Maximum Radius in Pixels")]
    //public class Setting_AmbientOcclusion_MaximumRadiusInPixels : Setting_AmbientOcclusion<int>
    //{
    //  public override string FieldName => "maximumRadiusInPixels";

    //  public Setting_AmbientOcclusion_MaximumRadiusInPixels()
    //  {
    //    options.AddMinMaxRangeValues("16", "256");
    //    options.AddStepSize("1");

    //    defaultValue = 40;
    //  }
    //}

    // TODO Enable once custom quality support is available
    //[DisplayName("Ambient Occlusion Full Resolution")]
    //public class Setting_AmbientOcclusion_FullResolution : Setting_AmbientOcclusion<bool>
    //{
    //  public override string FieldName => "fullResolution";

    //  public Setting_AmbientOcclusion_FullResolution()
    //  {
    //    defaultValue = false;
    //  }
    //}

    // TODO Enable once custom quality support is available
    //[DisplayName("Ambient Occlusion Step Count")]
    //public class Setting_AmbientOcclusion_StepCount : Setting_AmbientOcclusion<int>
    //{
    //  public override string FieldName => "stepCount";

    //  public Setting_AmbientOcclusion_StepCount()
    //  {
    //    options.AddMinMaxRangeValues("2", "32");
    //    options.AddStepSize("1");

    //    defaultValue = 6;
    //  }
    //}

    [DisplayName("Ambient Occlusion Temporal Accumulation (HDRP)")]
    public class Setting_AmbientOcclusion_TemporalAccumulation : Setting_AmbientOcclusion<bool>
    {
        public override string EditorName => "Ambient Occlusion Temporal Accumulation (HDRP)";

        public override string FieldName => "temporalAccumulation";

        public Setting_AmbientOcclusion_TemporalAccumulation()
        {
            defaultValue = true;
        }
    }

    [DisplayName("Ambient Occlusion Bilateral Aggressiveness (HDRP)")]
    public class Setting_AmbientOcclusion_BilateralAggressiveness : Setting_AmbientOcclusion<float>
    {
        public override string EditorName => "Ambient Occlusion Bilateral Aggressiveness (HDRP)";

        public override string FieldName => "spatialBilateralAggressiveness";

        public Setting_AmbientOcclusion_BilateralAggressiveness()
        {
            options.AddMinMaxRangeValues("0", "1");
            options.AddStepSize("0.01");
            options.AddOneHundredMultiplierAndPercent();

            defaultValue = 0.15f;
        }
    }

    [DisplayName("Ambient Occlusion Ghosting Reduction (HDRP)")]
    public class Setting_AmbientOcclusion_GhostingReduction : Setting_AmbientOcclusion<float>
    {
        public override string EditorName => "Ambient Occlusion Ghosting Reduction (HDRP)";

        public override string FieldName => "ghostingReduction";

        public Setting_AmbientOcclusion_GhostingReduction()
        {
            options.AddMinMaxRangeValues("0", "1");
            options.AddStepSize("0.01");
            options.AddOneHundredMultiplierAndPercent();

            defaultValue = 0.5f;
        }
    }
}