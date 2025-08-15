using CitrioN.Common;
using System.ComponentModel;

namespace CitrioN.SettingsMenuCreator.SRP
{
    [MenuOrder(810)]
    [ExcludeFromMenuSelection]
    [MenuPath("Post Processing/Chromatic Aberration")]
    public abstract class Setting_ChromaticAberration<T> : Setting_Generic_VolumeProfile_Extended<T,
#if UNITY_URP
      UnityEngine.Rendering.Universal.ChromaticAberration
#elif UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.ChromaticAberration
#else
    ScriptableObject
#endif
      >
    {
        public override string RuntimeName => GetType().Name.Replace("Setting_", "").Replace("_", "").SplitCamelCase();

        public override string EditorNamePrefix => "[PP]";
    }

    [DisplayName("Chromatic Aberration Active (URP & HDRP)")]
    public class Setting_ChromaticAberration_Active : Setting_ChromaticAberration<bool>
    {
        public override string EditorName => "Chromatic Aberration Active (URP & HDRP)";

        public override string FieldName => "active";

        public Setting_ChromaticAberration_Active()
        {
            defaultValue = true;
        }
    }

    // TODO Enable once Texture2D support has been added
    //[DisplayName("Chromatic Aberration Spectral LUT")]
    //public class Setting_ChromaticAberration_SpectralLut : Setting_ChromaticAberration<UnityEngine.Texture2D>
    //{
    //  public override string FieldName => nameof(ChromaticAberration.spectralLut);

    //  public Setting_ChromaticAberration_SpectralLut()
    //  {
    //  }
    //}

    [DisplayName("Chromatic Aberration Intensity (URP & HDRP)")]
    public class Setting_ChromaticAberration_Intensity : Setting_ChromaticAberration<float>
    {
        public override string EditorName => "Chromatic Aberration Intensity (URP & HDRP)";

        public override string FieldName => "intensity";

        public Setting_ChromaticAberration_Intensity()
        {
            options.AddMinMaxRangeValues("0", "1");
            options.AddStepSize("0.01");
            options.AddOneHundredMultiplierAndPercent();

            defaultValue = 0;
        }
    }

    [DisplayName("Chromatic Aberration Quality (HDRP)")]
    public class Setting_ChromaticAberration_Quality : Setting_ChromaticAberration<
#if UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.ScalableSettingLevelParameter.Level
#else
      int
#endif
      >
    {
        public override string EditorName => "Chromatic Aberration Quality (HDRP)";

        public override string FieldName => "quality";

        public Setting_ChromaticAberration_Quality()
        {
#if UNITY_HDRP
      defaultValue = UnityEngine.Rendering.HighDefinition.ScalableSettingLevelParameter.Level.Medium;
#endif
        }
    }

    // TODO Enable once custom quality support is available
    //[DisplayName("Chromatic Aberration Max Samples")]
    //public class Setting_ChromaticAberration_MaxSamples : Setting_ChromaticAberration<int>
    //{
    //  public override string FieldName => nameof(ChromaticAberration.maxSamples);

    //  public Setting_ChromaticAberration_MaxSamples()
    //  {
    //    options.AddMinMaxRangeValues("3", "24");
    //    options.AddStepSize("1");

    //    defaultValue = 6;
    //  }
    //}
}