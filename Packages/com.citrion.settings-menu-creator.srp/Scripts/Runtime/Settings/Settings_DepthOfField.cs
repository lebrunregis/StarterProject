using CitrioN.Common;
using System.ComponentModel;

namespace CitrioN.SettingsMenuCreator.SRP
{
    [MenuOrder(810)]
    [ExcludeFromMenuSelection]
    [MenuPath("Post Processing/Depth Of Field")]
    public abstract class Setting_DepthOfField<T> : Setting_Generic_VolumeProfile_Extended<T,
#if UNITY_URP
      UnityEngine.Rendering.Universal.DepthOfField
#elif UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.DepthOfField
#else
    ScriptableObject
#endif
      >
    {
        public override string RuntimeName => GetType().Name.Replace("Setting_", "").Replace("_", "").SplitCamelCase();
        public override string EditorNamePrefix => "[PP]";
    }

    [DisplayName("Depth Of Field Active (URP & HDRP)")]
    public class Setting_DepthOfField_Active : Setting_DepthOfField<bool>
    {
        public override string EditorName => "Depth Of Field Active (URP & HDRP)";

        public override string FieldName => "active";

        public Setting_DepthOfField_Active()
        {
            defaultValue = true;
        }
    }

    [DisplayName("Depth Of Field Focus Mode (URP)")]
    public class Setting_DepthOfField_FocusMode_URP : Setting_DepthOfField<

#if UNITY_URP
      UnityEngine.Rendering.Universal.DepthOfFieldMode
#else
    int
#endif
      >
    {
        public override string RuntimeName => "Depth Of Field Focus Mode (URP)";

        public override string EditorName => "Depth Of Field Focus Mode (URP)";

        public override string FieldName => "mode";

        public Setting_DepthOfField_FocusMode_URP()
        {
#if UNITY_URP
            defaultValue = UnityEngine.Rendering.Universal.DepthOfFieldMode.Off;
#endif
        }
    }

    [DisplayName("Depth Of Field Focus Mode (HDRP)")]
    public class Setting_DepthOfField_FocusMode_HDRP : Setting_DepthOfField<

#if UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.DepthOfFieldMode
#else
    int
#endif
    >
    {
        public override string RuntimeName => "Depth Of Field Focus Mode (HDRP)";

        public override string EditorName => "Depth Of Field Focus Mode (HDRP)";

        public override string FieldName => "focusMode";

        public Setting_DepthOfField_FocusMode_HDRP()
        {
#if UNITY_HDRP
      defaultValue = UnityEngine.Rendering.HighDefinition.DepthOfFieldMode.Off;
#endif
        }
    }


    [DisplayName("Depth Of Field Focus Distance Mode (HDRP)")]
    public class Setting_DepthOfField_FocusDistanceMode : Setting_DepthOfField<
#if UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.FocusDistanceMode
#else
      int
#endif
      >
    {
        public override string EditorName => "Depth Of Field Focus Distance Mode (HDRP)";

        public override string FieldName => "focusDistanceMode";

        public Setting_DepthOfField_FocusDistanceMode()
        {
#if UNITY_HDRP
      defaultValue = UnityEngine.Rendering.HighDefinition.FocusDistanceMode.Volume;
#endif
        }
    }

    [DisplayName("Depth Of Field Focus Distance (URP & HDRP)")]
    public class Setting_DepthOfField_FocusDistance : Setting_DepthOfField<float>
    {
        public override string EditorName => "Depth Of Field Focus Distance (URP & HDRP)";

        public override string FieldName => "focusDistance";

        public Setting_DepthOfField_FocusDistance()
        {
            options.AddMinMaxRangeValues("0.1", "20");
            options.AddStepSize("0.1");

            defaultValue = 10;
        }
    }

    [DisplayName("Depth Of Field Quality (HDRP)")]
    public class Setting_DepthOfField_Quality : Setting_DepthOfField<
#if UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.ScalableSettingLevelParameter.Level
#else
      int
#endif
      >
    {
        public override string EditorName => "Depth Of Field Quality (HDRP)";

        public override string FieldName => "quality";

        public Setting_DepthOfField_Quality()
        {
#if UNITY_HDRP
      defaultValue = UnityEngine.Rendering.HighDefinition.ScalableSettingLevelParameter.Level.Medium;
#endif
        }
    }

    [DisplayName("Depth Of Field Near Focus Start (HDRP)")]
    public class Setting_DepthOfField_NearFocusStart : Setting_DepthOfField<float>
    {
        public override string EditorName => "Depth Of Field Near Focus Start (HDRP)";

        public override string FieldName => "nearFocusStart";

        public Setting_DepthOfField_NearFocusStart()
        {
            options.AddMinMaxRangeValues("0", "100");
            options.AddStepSize("0.1");

            defaultValue = 0f;
        }
    }

    [DisplayName("Depth Of Field Near Focus End (HDRP)")]
    public class Setting_DepthOfField_NearFocusEnd : Setting_DepthOfField<float>
    {
        public override string EditorName => "Depth Of Field Near Focus End (HDRP)";

        public override string FieldName => "nearFocusEnd";

        public Setting_DepthOfField_NearFocusEnd()
        {
            options.AddMinMaxRangeValues("0", "100");
            options.AddStepSize("0.1");

            defaultValue = 10f;
        }
    }

    [DisplayName("Depth Of Field Far Focus Start (HDRP)")]
    public class Setting_DepthOfField_FarFocusStart : Setting_DepthOfField<float>
    {
        public override string EditorName => "Depth Of Field Far Focus Start (HDRP)";

        public override string FieldName => "farFocusStart";

        public Setting_DepthOfField_FarFocusStart()
        {
            options.AddMinMaxRangeValues("0", "100");
            options.AddStepSize("0.1");

            defaultValue = 10f;
        }
    }

    [DisplayName("Depth Of Field Far Focus End (HDRP)")]
    public class Setting_DepthOfField_FarFocusEnd : Setting_DepthOfField<float>
    {
        public override string EditorName => "Depth Of Field Far Focus End (HDRP)";

        public override string FieldName => "farFocusEnd";

        public Setting_DepthOfField_FarFocusEnd()
        {
            options.AddMinMaxRangeValues("0", "100");
            options.AddStepSize("0.1");

            defaultValue = 100f;
        }
    }

    // TODO Enable once custom quality support is available
    //[DisplayName("Depth Of Field Near Max Blur")]
    //public class Setting_DepthOfField_NearMaxBlur : Setting_DepthOfField<float>
    //{
    //  public override string FieldName => nameof(DepthOfField.nearMaxBlur);

    //  public Setting_DepthOfField_NearMaxBlur()
    //  {
    //    options.AddMinMaxRangeValues("0", "1");
    //    options.AddStepSize("0.01");

    //    defaultValue = 0.5f;
    //  }
    //}

    // TODO Enable once custom quality support is available
    //[DisplayName("Depth Of Field Far Max Blur")]
    //public class Setting_DepthOfField_FarMaxBlur : Setting_DepthOfField<float>
    //{
    //  public override string FieldName => nameof(DepthOfField.farMaxBlur);

    //  public Setting_DepthOfField_FarMaxBlur()
    //  {
    //    options.AddMinMaxRangeValues("0", "1");
    //    options.AddStepSize("0.01");

    //    defaultValue = 0.5f;
    //  }
    //}

    // TODO Enable once custom quality support is available
    //[DisplayName("Depth Of Field Near Sample Count")]
    //public class Setting_DepthOfField_NearSampleCount : Setting_DepthOfField<int>
    //{
    //  public override string FieldName => nameof(DepthOfField.nearSampleCount);

    //  public Setting_DepthOfField_NearSampleCount()
    //  {
    //    options.AddMinMaxRangeValues("1", "16");
    //    options.AddStepSize("1");

    //    defaultValue = 8;
    //  }
    //}

    // TODO Enable once custom quality support is available
    //[DisplayName("Depth Of Field Far Sample Count")]
    //public class Setting_DepthOfField_FarSampleCount : Setting_DepthOfField<int>
    //{
    //  public override string FieldName => nameof(DepthOfField.farSampleCount);

    //  public Setting_DepthOfField_FarSampleCount()
    //  {
    //    options.AddMinMaxRangeValues("1", "16");
    //    options.AddStepSize("1");

    //    defaultValue = 8;
    //  }
    //}
}