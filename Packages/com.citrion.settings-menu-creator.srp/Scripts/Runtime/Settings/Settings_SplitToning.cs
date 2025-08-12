using CitrioN.Common;
using System.ComponentModel;
using UnityEngine;

namespace CitrioN.SettingsMenuCreator.SRP
{
  [MenuOrder(810)]
  [ExcludeFromMenuSelection]
  [MenuPath("Post Processing/Split Toning")]
  public abstract class Setting_SplitToning<T> : Setting_Generic_VolumeProfile_Extended<T,
#if UNITY_URP
    UnityEngine.Rendering.Universal.SplitToning
#elif UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.SplitToning
#else
    ScriptableObject
#endif
    >
  {
    public override string RuntimeName => GetType().Name.Replace("Setting_", "").Replace("_", "").SplitCamelCase();
    public override string EditorNamePrefix => "[PP]";
  }

  [DisplayName("Split Toning Active (URP & HDRP)")]
  public class Setting_SplitToning_Active : Setting_SplitToning<bool>
  {
    public override string EditorName => "Split Toning Active (URP & HDRP)";

    public override string FieldName => "active";

    public Setting_SplitToning_Active()
    {
      defaultValue = true;
    }
  }

  // TODO Enable once color support has been added
  //[DisplayName("Split Toning Shadows")]
  //public class Setting_SplitToning_Shadows : Setting_SplitToning<UnityEngine.Color>
  //{
  //  public override string FieldName => nameof(SplitToning.shadows);

  //  public Setting_SplitToning_Shadows()
  //  {
  //    defaultValue = UnityEngine.Color.grey;
  //  }
  //}

  // TODO Enable once color support has been added
  //[DisplayName("Split Toning Highlights")]
  //public class Setting_SplitToning_Highlights : Setting_SplitToning<UnityEngine.Color>
  //{
  //  public override string FieldName => nameof(SplitToning.highlights);

  //  public Setting_SplitToning_Highlights()
  //  {
  //    defaultValue = UnityEngine.Color.grey;
  //  }
  //}

  [DisplayName("Split Toning Balance (URP & HDRP)")]
  public class Setting_SplitToning_Balance : Setting_SplitToning<float>
  {
    public override string EditorName => "Split Toning Balance (URP & HDRP)";

    public override string FieldName => "balance";

    public Setting_SplitToning_Balance()
    {
      options.AddMinMaxRangeValues("-100", "100");
      options.AddStepSize("1");

      defaultValue = 0f;
    }
  }
}