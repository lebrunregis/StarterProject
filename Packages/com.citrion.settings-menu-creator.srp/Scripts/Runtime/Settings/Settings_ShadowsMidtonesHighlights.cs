using CitrioN.Common;
using System.ComponentModel;

namespace CitrioN.SettingsMenuCreator.SRP
{
    [MenuOrder(810)]
    [ExcludeFromMenuSelection]
    [MenuPath("Post Processing/Shadows Midtones Highlights")]
    public abstract class Setting_ShadowsMidtonesHighlights<T> : Setting_Generic_VolumeProfile_Extended<T,
#if UNITY_URP
      UnityEngine.Rendering.Universal.ShadowsMidtonesHighlights
#elif UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.ShadowsMidtonesHighlights
#else
    ScriptableObject
#endif
      >
    {
        public override string RuntimeName => GetType().Name.Replace("Setting_", "").Replace("_", "").SplitCamelCase();
        public override string EditorNamePrefix => "[PP]";
    }

    [DisplayName("Shadows Midtones Highlights Active (URP & HDRP)")]
    public class Setting_ShadowsMidtonesHighlights_Active : Setting_ShadowsMidtonesHighlights<bool>
    {
        public override string EditorName => "Shadows Midtones Highlights Active (URP & HDRP)";

        public override string FieldName => "active";

        public Setting_ShadowsMidtonesHighlights_Active()
        {
            defaultValue = true;
        }
    }

    // TODO Enable once Vector4 support has been added
    //[DisplayName("Shadows Midtones Highlights - Shadows")]
    //public class Setting_ShadowsMidtonesHighlights_Shadows : Setting_ShadowsMidtonesHighlights<UnityEngine.Vector4>
    //{
    //  public override string FieldName => nameof(ShadowsMidtonesHighlights.shadows);

    //  public Setting_ShadowsMidtonesHighlights_Shadows()
    //  {
    //    defaultValue = new UnityEngine.Vector4(0, 0, 0, 100);
    //  }
    //}

    // TODO Enable once Vector4 support has been added
    //[DisplayName("Shadows Midtones Highlights - Midtones")]
    //public class Setting_ShadowsMidtonesHighlights_Midtones : Setting_ShadowsMidtonesHighlights<UnityEngine.Vector4>
    //{
    //  public override string FieldName => nameof(ShadowsMidtonesHighlights.midtones);

    //  public Setting_ShadowsMidtonesHighlights_Midtones()
    //  {
    //    defaultValue = new UnityEngine.Vector4(0, 0, 0, 100);
    //  }
    //}

    // TODO Enable once Vector4 support has been added
    //[DisplayName("Shadows Midtones Highlights - Highlights")]
    //public class Setting_ShadowsMidtonesHighlights_Highlights : Setting_ShadowsMidtonesHighlights<UnityEngine.Vector4>
    //{
    //  public override string FieldName => nameof(ShadowsMidtonesHighlights.highlights);

    //  public Setting_ShadowsMidtonesHighlights_Highlights()
    //  {
    //    defaultValue = new UnityEngine.Vector4(0, 0, 0, 100);
    //  }
    //}

    // TODO Enable once min max support is added?
    //[DisplayName("Shadows Midtones Highlights - Shadows Start")]
    //public class Setting_ShadowsMidtonesHighlights_ShadowsStart : Setting_ShadowsMidtonesHighlights<float>
    //{
    //  public override string FieldName => nameof(ShadowsMidtonesHighlights.shadowsStart);

    //  public Setting_ShadowsMidtonesHighlights_ShadowsStart()
    //  {
    //    options.AddMinMaxRangeValues("0", "5");
    //    options.AddStepSize("0.01");
    //    defaultValue = 0f;
    //  }
    //}

    // TODO Enable once min max support is added?
    //[DisplayName("Shadows Midtones Highlights - Shadows End")]
    //public class Setting_ShadowsMidtonesHighlights_ShadowsEnd : Setting_ShadowsMidtonesHighlights<float>
    //{
    //  public override string FieldName => nameof(ShadowsMidtonesHighlights.shadowsEnd);

    //  public Setting_ShadowsMidtonesHighlights_ShadowsEnd()
    //  {
    //    options.AddMinMaxRangeValues("0", "5");
    //    options.AddStepSize("0.01");
    //    defaultValue = 0.3f;
    //  }
    //}

    // TODO Enable once min max support is added?
    //[DisplayName("Shadows Midtones Highlights - Highlights Start")]
    //public class Setting_ShadowsMidtonesHighlights_HighlightsStart : Setting_ShadowsMidtonesHighlights<float>
    //{
    //  public override string FieldName => nameof(ShadowsMidtonesHighlights.highlightsStart);

    //  public Setting_ShadowsMidtonesHighlights_HighlightsStart()
    //  {
    //    options.AddMinMaxRangeValues("0", "5");
    //    options.AddStepSize("0.01");
    //    defaultValue = 0.55f;
    //  }
    //}

    // TODO Enable once min max support is added?
    //[DisplayName("Shadows Midtones Highlights - Highlights End")]
    //public class Setting_ShadowsMidtonesHighlights_HighlightsEnd : Setting_ShadowsMidtonesHighlights<float>
    //{
    //  public override string FieldName => nameof(ShadowsMidtonesHighlights.highlightsEnd);

    //  public Setting_ShadowsMidtonesHighlights_HighlightsEnd()
    //  {
    //    options.AddMinMaxRangeValues("0", "5");
    //    options.AddStepSize("0.01");
    //    defaultValue = 1f;
    //  }
    //}
}