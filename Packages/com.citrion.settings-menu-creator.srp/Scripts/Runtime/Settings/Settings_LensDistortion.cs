using CitrioN.Common;
using System.ComponentModel;

namespace CitrioN.SettingsMenuCreator.SRP
{
    [MenuOrder(810)]
    [ExcludeFromMenuSelection]
    [MenuPath("Post Processing/Lens Distortion")]
    public abstract class Setting_LensDistortion<T> : Setting_Generic_VolumeProfile_Extended<T,
#if UNITY_URP
      UnityEngine.Rendering.Universal.LensDistortion
#elif UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.LensDistortion
#else
    ScriptableObject
#endif
      >
    {
        public override string RuntimeName => GetType().Name.Replace("Setting_", "").Replace("_", "").SplitCamelCase();
        public override string EditorNamePrefix => "[PP]";
    }

    [DisplayName("Lens Distortion Active (URP & HDRP)")]
    public class Setting_LensDistortion_Active : Setting_LensDistortion<bool>
    {
        public override string EditorName => "Lens Distortion Active (URP & HDRP)";

        public override string FieldName => "active";

        public Setting_LensDistortion_Active()
        {
            defaultValue = true;
        }
    }

    [DisplayName("Lens Distortion Intensity (URP & HDRP)")]
    public class Setting_LensDistortion_Intensity : Setting_LensDistortion<float>
    {
        public override string EditorName => "Lens Distortion Intensity (URP & HDRP)";

        public override string FieldName => "intensity";

        public Setting_LensDistortion_Intensity()
        {
            options.AddMinMaxRangeValues("-1", "1");
            options.AddStepSize("0.01");

            defaultValue = 0;
        }
    }

    [DisplayName("Lens Distortion X Multiplier (URP & HDRP)")]
    public class Setting_LensDistortion_XMultiplier : Setting_LensDistortion<float>
    {
        public override string EditorName => "Lens Distortion X Multiplier (URP & HDRP)";

        public override string FieldName => "xMultiplier";

        public Setting_LensDistortion_XMultiplier()
        {
            options.AddMinMaxRangeValues("0", "1");
            options.AddStepSize("0.01");

            defaultValue = 1;
        }
    }

    [DisplayName("Lens Distortion Y Multiplier (URP & HDRP)")]
    public class Setting_LensDistortion_YMultiplier : Setting_LensDistortion<float>
    {
        public override string EditorName => "Lens Distortion Y Multiplier (URP & HDRP)";

        public override string FieldName => "yMultiplier";

        public Setting_LensDistortion_YMultiplier()
        {
            options.AddMinMaxRangeValues("0", "1");
            options.AddStepSize("0.01");

            defaultValue = 1;
        }
    }

    // TODO Enable once Vector2 support has been added
    //[DisplayName("Lens Distortion Center")]
    //public class Setting_LensDistortion_Center : Setting_LensDistortion<UnityEngine.Vector2>
    //{
    //  public override string FieldName => nameof(LensDistortion.center);

    //  public Setting_LensDistortion_Center()
    //  {
    //    defaultValue = new UnityEngine.Vector2(0.5f, 0.5f);
    //  }
    //}

    [DisplayName("Lens Distortion Scale (URP & HDRP)")]
    public class Setting_LensDistortion_Scale : Setting_LensDistortion<float>
    {
        public override string EditorName => "Lens Distortion Scale (URP & HDRP)";

        public override string FieldName => "scale";

        public Setting_LensDistortion_Scale()
        {
            options.AddMinMaxRangeValues("0.01", "5");
            options.AddStepSize("0.01");

            defaultValue = 1;
        }
    }
}