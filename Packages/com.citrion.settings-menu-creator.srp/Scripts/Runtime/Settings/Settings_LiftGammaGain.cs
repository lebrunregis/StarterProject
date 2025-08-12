using CitrioN.Common;
using System.ComponentModel;
using UnityEngine;

namespace CitrioN.SettingsMenuCreator.SRP
{
  [MenuOrder(810)]
  [ExcludeFromMenuSelection]
  [MenuPath("Post Processing/Lift Gamma Gain")]
  public abstract class Setting_LiftGammaGain<T> : Setting_Generic_VolumeProfile_Extended<T,
#if UNITY_URP
    UnityEngine.Rendering.Universal.LiftGammaGain
#elif UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.LiftGammaGain
#else
    ScriptableObject
#endif
    >
  {
    public override string RuntimeName => GetType().Name.Replace("Setting_", "").Replace("_", "").SplitCamelCase();
    public override string EditorNamePrefix => "[PP]";
  }

  [DisplayName("Lift Gamma Gain Active (URP & HDRP)")]
  public class Setting_LiftGammaGain_Active : Setting_LiftGammaGain<bool>
  {
    public override string EditorName => "Lift Gamma Gain Active (URP & HDRP)";

    public override string FieldName => "active";

    public Setting_LiftGammaGain_Active()
    {
      defaultValue = true;
    }
  }

  // TODO Enable once Vector4 support has been added
  //[DisplayName("Lift Gamma Gain - Lift")]
  //public class Setting_LiftGammaGain_Lift : Setting_LiftGammaGain<UnityEngine.Vector4>
  //{
  //  public override string FieldName => nameof(LiftGammaGain.lift);

  //  public Setting_LiftGammaGain_Lift()
  //  {
  //    defaultValue = new UnityEngine.Vector4(0, 0, 0, 100);
  //  }
  //}

  // TODO Enable once Vector4 support has been added
  //[DisplayName("Lift Gamma Gain - Gamma")]
  //public class Setting_LiftGammaGain_Gamma : Setting_LiftGammaGain<UnityEngine.Vector4>
  //{
  //  public override string FieldName => nameof(LiftGammaGain.gamma);

  //  public Setting_LiftGammaGain_Gamma()
  //  {
  //    defaultValue = new UnityEngine.Vector4(0, 0, 0, 100);
  //  }
  //}

  // TODO Enable once Vector4 support has been added
  //[DisplayName("Lift Gamma Gain - Gain")]
  //public class Setting_LiftGammaGain_Gain : Setting_LiftGammaGain<UnityEngine.Vector4>
  //{
  //  public override string FieldName => nameof(LiftGammaGain.gain);

  //  public Setting_LiftGammaGain_Gain()
  //  {
  //    defaultValue = new UnityEngine.Vector4(0, 0, 0, 100);
  //  }
  //}
}