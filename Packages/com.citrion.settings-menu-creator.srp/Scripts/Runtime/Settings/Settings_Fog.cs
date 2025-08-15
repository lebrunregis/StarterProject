using CitrioN.Common;
using System.ComponentModel;

namespace CitrioN.SettingsMenuCreator.SRP
{
    [MenuOrder(810)]
    [ExcludeFromMenuSelection]
    [MenuPath("Post Processing/Fog")]
    public abstract class Setting_Fog<T> : Setting_Generic_VolumeProfile_Extended<T,
#if UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.Fog
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

    [DisplayName("Fog Active (HDRP)")]
    public class Setting_Fog_Active : Setting_Fog<bool>
    {
        public override string EditorName => "Fog Active (HDRP)";

        public override string FieldName => "active";

        public Setting_Fog_Active()
        {
            defaultValue = true;
        }
    }

    [DisplayName("Fog Enable (HDRP)")]
    public class Setting_Fog_Enable : Setting_Fog<bool>
    {
        public override string EditorName => "Fog Enable (HDRP)";

        public override string FieldName => "enabled";

        public Setting_Fog_Enable()
        {
            defaultValue = true;
        }
    }

    [DisplayName("Fog Base Height (HDRP)")]
    public class Setting_Fog_BaseHeight : Setting_Fog<float>
    {
        public override string EditorName => "Fog Base Height (HDRP)";

        public override string FieldName => "baseHeight";

        public Setting_Fog_BaseHeight()
        {
            options.AddMinMaxRangeValues("0", "1000");
            options.AddStepSize("1");

            defaultValue = 0f;
        }
    }

    [DisplayName("Fog Maximum Height (HDRP)")]
    public class Setting_Fog_MaximumHeight : Setting_Fog<float>
    {
        public override string EditorName => "Fog Maximum Height (HDRP)";

        public override string FieldName => "maximumHeight";

        public Setting_Fog_MaximumHeight()
        {
            options.AddMinMaxRangeValues("0", "5000");
            options.AddStepSize("10");

            defaultValue = 50f;
        }
    }

    [DisplayName("Fog Max Distance (HDRP)")]
    public class Setting_Fog_MaxFogDistance : Setting_Fog<float>
    {
        public override string EditorName => "Fog Max Distance (HDRP)";

        public override string FieldName => "maxFogDistance";

        public Setting_Fog_MaxFogDistance()
        {
            options.AddMinMaxRangeValues("0", "10000");
            options.AddStepSize("50");

            defaultValue = 5000f;
        }
    }

    [DisplayName("Fog Color Mode (HDRP)")]
    public class Setting_Fog_ColorMode : Setting_Fog<
#if UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.FogColorMode
#else
      int
#endif
      >
    {
        public override string EditorName => "Fog Color Mode (HDRP)";

        public override string FieldName => "colorMode";

        public Setting_Fog_ColorMode()
        {
#if UNITY_HDRP
      defaultValue = UnityEngine.Rendering.HighDefinition.FogColorMode.SkyColor;
#endif
        }
    }

    [DisplayName("Fog Enable Volumetric Fog (HDRP)")]
    public class Setting_Fog_EnableVolumetricFog : Setting_Fog<bool>
    {
        public override string EditorName => "Fog Enable Volumetric Fog (HDRP)";

        public override string FieldName => "enableVolumetricFog";

        public Setting_Fog_EnableVolumetricFog()
        {
            defaultValue = false;
        }
    }

    [DisplayName("Fog Global Light Probe Dimmer (HDRP)")]
    public class Setting_Fog_GlobalLightProbeDimmer : Setting_Fog<float>
    {
        public override string EditorName => "Fog Global Light Probe Dimmer (HDRP)";

        public override string FieldName => "globalLightProbeDimmer";

        public Setting_Fog_GlobalLightProbeDimmer()
        {
            options.AddMinMaxRangeValues("0", "1");
            options.AddStepSize("0.01");

            defaultValue = 1f;
        }
    }

    [DisplayName("Fog Denoising Mode (HDRP)")]
    public class Setting_Fog_DenoisingMode : Setting_Fog<
#if UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.FogDenoisingMode
#else
      int
#endif
      >
    {
        public override string EditorName => "Fog Denoising Mode (HDRP)";

        public override string FieldName => "denoisingMode";

        public Setting_Fog_DenoisingMode()
        {
#if UNITY_HDRP
      defaultValue = UnityEngine.Rendering.HighDefinition.FogDenoisingMode.Gaussian;
#endif
        }
    }

    [DisplayName("Fog Quality (HDRP)")]
    public class Setting_Fog_Quality : Setting_Fog<
#if UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.ScalableSettingLevelParameter.Level
#else
      int
#endif
      >
    {
        public override string EditorName => "Fog Quality (HDRP)";

        public override string FieldName => "quality";

        public Setting_Fog_Quality()
        {
#if UNITY_HDRP
      defaultValue = UnityEngine.Rendering.HighDefinition.ScalableSettingLevelParameter.Level.Medium;
#endif
        }
    }
}