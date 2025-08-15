using CitrioN.Common;
using System.ComponentModel;

namespace CitrioN.SettingsMenuCreator.SRP
{
    [MenuOrder(810)]
    [ExcludeFromMenuSelection]
    [MenuPath("Post Processing/Contact Shadows")]
    public abstract class Setting_ContactShadows<T> : Setting_Generic_VolumeProfile_Extended<T,
#if UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.ContactShadows
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

    [DisplayName("Contact Shadows Active (HDRP)")]
    public class Setting_ContactShadows_Active : Setting_ContactShadows<bool>
    {
        public override string EditorName => "Contact Shadows Active (HDRP)";

        public override string FieldName => "active";

        public Setting_ContactShadows_Active()
        {
            defaultValue = true;
        }
    }

    [DisplayName("Contact Shadows Enable (HDRP)")]
    public class Setting_ContactShadows_Enable : Setting_ContactShadows<bool>
    {
        public override string EditorName => "Contact Shadows Enable (HDRP)";

        public override string FieldName => "enable";

        public Setting_ContactShadows_Enable()
        {
            defaultValue = true;
        }
    }

    [DisplayName("Contact Shadows Length (HDRP)")]
    public class Setting_ContactShadows_Length : Setting_ContactShadows<float>
    {
        public override string EditorName => "Contact Shadows Length (HDRP)";

        public override string FieldName => "length";

        public Setting_ContactShadows_Length()
        {
            options.AddMinMaxRangeValues("0", "1");
            options.AddStepSize("0.01");

            defaultValue = 0.15f;
        }
    }

    [DisplayName("Contact Shadows Opacity (HDRP)")]
    public class Setting_ContactShadows_Opacity : Setting_ContactShadows<float>
    {
        public override string EditorName => "Contact Shadows Opacity (HDRP)";

        public override string FieldName => "opacity";

        public Setting_ContactShadows_Opacity()
        {
            options.AddMinMaxRangeValues("0", "1");
            options.AddStepSize("0.01");
            options.AddOneHundredMultiplierAndPercent();

            defaultValue = 1f;
        }
    }

    [DisplayName("Contact Shadows Distance Scale Factor (HDRP)")]
    public class Setting_ContactShadows_DistanceScaleFactor : Setting_ContactShadows<float>
    {
        public override string EditorName => "Contact Shadows Distance Scale Factor (HDRP)";

        public override string FieldName => "distanceScaleFactor";

        public Setting_ContactShadows_DistanceScaleFactor()
        {
            options.AddMinMaxRangeValues("0", "1");
            options.AddStepSize("0.01");
            options.AddOneHundredMultiplierAndPercent();

            defaultValue = 0.5f;
        }
    }

    [DisplayName("Contact Shadows Min Distance (HDRP)")]
    public class Setting_ContactShadows_MinDistance : Setting_ContactShadows<float>
    {
        public override string EditorName => "Contact Shadows Min Distance (HDRP)";

        public override string FieldName => "minDistance";

        public Setting_ContactShadows_MinDistance()
        {
            options.AddMinMaxRangeValues("0", "100");
            options.AddStepSize("1");

            defaultValue = 0f;
        }
    }

    [DisplayName("Contact Shadows Max Distance (HDRP)")]
    public class Setting_ContactShadows_MaxDistance : Setting_ContactShadows<float>
    {
        public override string EditorName => "Contact Shadows Max Distance (HDRP)";

        public override string FieldName => "maxDistance";

        public Setting_ContactShadows_MaxDistance()
        {
            options.AddMinMaxRangeValues("0", "1000");
            options.AddStepSize("10");

            defaultValue = 50f;
        }
    }

    [DisplayName("Contact Shadows Fade Distance (HDRP)")]
    public class Setting_ContactShadows_FadeDistance : Setting_ContactShadows<float>
    {
        public override string EditorName => "Contact Shadows Fade Distance (HDRP)";

        public override string FieldName => "fadeDistance";

        public Setting_ContactShadows_FadeDistance()
        {
            options.AddMinMaxRangeValues("0", "500");
            options.AddStepSize("5");

            defaultValue = 5f;
        }
    }

    [DisplayName("Contact Shadows Fade In Distance (HDRP)")]
    public class Setting_ContactShadows_FadeInDistance : Setting_ContactShadows<float>
    {
        public override string EditorName => "Contact Shadows Fade In Distance (HDRP)";

        public override string FieldName => "fadeInDistance";

        public Setting_ContactShadows_FadeInDistance()
        {
            options.AddMinMaxRangeValues("0", "5");
            options.AddStepSize("0.1");

            defaultValue = 0f;
        }
    }

    [DisplayName("Contact Shadows Ray Bias (HDRP)")]
    public class Setting_ContactShadows_RayBias : Setting_ContactShadows<float>
    {
        public override string EditorName => "Contact Shadows Ray Bias (HDRP)";

        public override string FieldName => "rayBias";

        public Setting_ContactShadows_RayBias()
        {
            options.AddMinMaxRangeValues("0", "1");
            options.AddStepSize("0.01");

            defaultValue = 0.2f;
        }
    }

    [DisplayName("Contact Shadows Thickness Scale (HDRP)")]
    public class Setting_ContactShadows_ThicknessScale : Setting_ContactShadows<float>
    {
        public override string EditorName => "Contact Shadows Thickness Scale (HDRP)";

        public override string FieldName => "thicknessScale";

        public Setting_ContactShadows_ThicknessScale()
        {
            options.AddMinMaxRangeValues("0.02", "1");
            options.AddStepSize("0.01");

            defaultValue = 0.15f;
        }
    }

    [DisplayName("Contact Shadows Quality (HDRP)")]
    public class Setting_ContactShadows_Quality : Setting_ContactShadows<
#if UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.ScalableSettingLevelParameter.Level
#else
      int
#endif
      >
    {
        public override string EditorName => "Contact Shadows Quality (HDRP)";

        public override string FieldName => "quality";

        public Setting_ContactShadows_Quality()
        {
#if UNITY_HDRP
      defaultValue = UnityEngine.Rendering.HighDefinition.ScalableSettingLevelParameter.Level.Medium;
#endif
        }
    }

    // TODO Enable once custom quality support is available
    //[DisplayName("Contact Shadows Sample Count")]
    //public class Setting_ContactShadows_SampleCount : Setting_ContactShadows<int>
    //{
    //  public override string FieldName => nameof(ContactShadows.sampleCount);

    //  public Setting_ContactShadows_SampleCount()
    //  {
    //    options.AddMinMaxRangeValues("4", "64");
    //    options.AddStepSize("1");

    //    defaultValue = 10;
    //  }
    //}  
}