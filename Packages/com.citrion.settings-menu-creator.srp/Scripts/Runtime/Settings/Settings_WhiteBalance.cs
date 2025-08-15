using CitrioN.Common;
using System.ComponentModel;

namespace CitrioN.SettingsMenuCreator.SRP
{
    [MenuOrder(810)]
    [ExcludeFromMenuSelection]
    [MenuPath("Post Processing/White Balance")]
    public abstract class Setting_WhiteBalance<T> : Setting_Generic_VolumeProfile_Extended<T,
#if UNITY_URP
      UnityEngine.Rendering.Universal.WhiteBalance
#elif UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.WhiteBalance
#else
    ScriptableObject
#endif
      >
    {
        public override string RuntimeName => GetType().Name.Replace("Setting_", "").Replace("_", "").SplitCamelCase();
        public override string EditorNamePrefix => "[PP]";
    }

    [DisplayName("White Balance Active (URP & HDRP)")]
    public class Setting_WhiteBalance_Active : Setting_WhiteBalance<bool>
    {
        public override string EditorName => "White Balance Active (URP & HDRP)";

        public override string FieldName => "active";

        public Setting_WhiteBalance_Active()
        {
            defaultValue = true;
        }
    }

    [DisplayName("White Balance Temperature (URP & HDRP)")]
    public class Setting_WhiteBalance_Temperature : Setting_WhiteBalance<float>
    {
        public override string EditorName => "White Balance Temperature (URP & HDRP)";

        public override string FieldName => "temperature";

        public Setting_WhiteBalance_Temperature()
        {
            options.AddMinMaxRangeValues("-100", "100");
            options.AddStepSize("1");

            defaultValue = 0f;
        }
    }

    [DisplayName("White Balance Tint (URP & HDRP)")]
    public class Setting_WhiteBalance_Tint : Setting_WhiteBalance<float>
    {
        public override string EditorName => "White Balance Tint (URP & HDRP)";

        public override string FieldName => "tint";

        public Setting_WhiteBalance_Tint()
        {
            options.AddMinMaxRangeValues("-100", "100");
            options.AddStepSize("1");

            defaultValue = 0f;
        }
    }
}