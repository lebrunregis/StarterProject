using CitrioN.Common;
using System.ComponentModel;
using UnityEngine;

namespace CitrioN.SettingsMenuCreator.SRP
{
  [MenuOrder(810)]
  [ExcludeFromMenuSelection]
  [MenuPath("Post Processing/Tonemapping")]
  public abstract class Setting_Tonemapping<T> : Setting_Generic_VolumeProfile_Extended<T,
#if UNITY_URP
    UnityEngine.Rendering.Universal.Tonemapping
#elif UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.Tonemapping
#else
    ScriptableObject
#endif
    >
  {
    public override string RuntimeName => GetType().Name.Replace("Setting_", "").Replace("_", "").SplitCamelCase();
    public override string EditorNamePrefix => "[PP]";
  }

  [DisplayName("Tonemapping Active (URP & HDRP)")]
  public class Setting_Tonemapping_Active : Setting_Tonemapping<bool>
  {
    public override string EditorName => "Tonemapping Active (URP & HDRP)";

    public override string FieldName => "active";

    public Setting_Tonemapping_Active()
    {
      defaultValue = true;
    }
  }

  [DisplayName("Tonemapping Mode (URP)")]
  public class Setting_Tonemapping_Mode_URP : Setting_Tonemapping<
#if UNITY_URP
    UnityEngine.Rendering.Universal.TonemappingMode
#else
    int
#endif
    >
  {
    public override string RuntimeName => "Tonemapping Mode (URP)";

    public override string EditorName => "Tonemapping Mode (URP)";

    public override string FieldName => "mode";

    public Setting_Tonemapping_Mode_URP()
    {
#if UNITY_URP
      defaultValue = UnityEngine.Rendering.Universal.TonemappingMode.None;
#endif
    }
  } 

  [DisplayName("Tonemapping Mode (HDRP)")]
  public class Setting_Tonemapping_Mode : Setting_Tonemapping<
#if UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.TonemappingMode
#else
    int
#endif
    >
  {
    public override string RuntimeName => "Tonemapping Mode (HDRP)";

    public override string EditorName => "Tonemapping Mode (HDRP)";

    public override string FieldName => "mode";

    public Setting_Tonemapping_Mode()
    {
#if UNITY_HDRP
      defaultValue = UnityEngine.Rendering.HighDefinition.TonemappingMode.None;
#endif
    }
  } 

  [DisplayName("Tonemapping Toe Strength (HDRP)")]
  public class Setting_Tonemapping_ToeStrength : Setting_Tonemapping<float>
  {
    public override string EditorName => "Tonemapping Toe Strength (HDRP)";

    public override string FieldName => "toeStrength";

    public Setting_Tonemapping_ToeStrength()
    {
      options.AddMinMaxRangeValues("0", "1");
      options.AddStepSize("0.01");
      options.AddOneHundredMultiplierAndPercent();

      defaultValue = 0.0f;
    }
  }

  [DisplayName("Tonemapping Toe Length (HDRP)")]
  public class Setting_Tonemapping_ToeLength : Setting_Tonemapping<float>
  {
    public override string EditorName => "Tonemapping Toe Length (HDRP)";

    public override string FieldName => "toeLength";

    public Setting_Tonemapping_ToeLength()
    {
      options.AddMinMaxRangeValues("0", "1");
      options.AddStepSize("0.01");

      defaultValue = 0.5f;
    }
  }

  [DisplayName("Tonemapping Shoulder Strength (HDRP)")]
  public class Setting_Tonemapping_ShoulderStrength : Setting_Tonemapping<float>
  {
    public override string EditorName => "Tonemapping Shoulder Strength (HDRP)";

    public override string FieldName => "shoulderStrength";

    public Setting_Tonemapping_ShoulderStrength()
    {
      options.AddMinMaxRangeValues("0", "1");
      options.AddStepSize("0.01");
      options.AddOneHundredMultiplierAndPercent();

      defaultValue = 0.0f;
    }
  }

  [DisplayName("Tonemapping Shoulder Length (HDRP)")]
  public class Setting_Tonemapping_ShoulderLength : Setting_Tonemapping<float>
  {
    public override string EditorName => "Tonemapping Shoulder Length (HDRP)";

    public override string FieldName => "shoulderLength";

    public Setting_Tonemapping_ShoulderLength()
    {
      options.AddMinMaxRangeValues("0", "5");
      options.AddStepSize("0.1");

      defaultValue = 0.5f;
    }
  }

  [DisplayName("Tonemapping Shoulder Angle (HDRP)")]
  public class Setting_Tonemapping_ShoulderAngle : Setting_Tonemapping<float>
  {
    public override string EditorName => "Tonemapping Shoulder Angle (HDRP)";

    public override string FieldName => "shoulderAngle";

    public Setting_Tonemapping_ShoulderAngle()
    {
      options.AddMinMaxRangeValues("0", "1");
      options.AddStepSize("0.01");

      defaultValue = 0.0f;
    }
  }

  [DisplayName("Tonemapping Gamma (HDRP)")]
  public class Setting_Tonemapping_Gamma : Setting_Tonemapping<float>
  {
    public override string EditorName => "Tonemapping Gamma (HDRP)";

    public override string FieldName => "gamma";

    public Setting_Tonemapping_Gamma()
    {
      options.AddMinMaxRangeValues("0.01", "3");
      options.AddStepSize("0.01");

      defaultValue = 1f;
    }
  }

  //[DisplayName("Tonemapping Lookup Texture")]
  //public class Setting_Tonemapping_LookupTexture : Setting_Tonemapping<UnityEngine.Texture3D>
  //{
  //  public override string FieldName => nameof(Tonemapping.lutTexture);

  //  public Setting_Tonemapping_LookupTexture()
  //  {

  //  }
  //}

  [DisplayName("Tonemapping Lookup Texture Contribution (HDRP)")]
  public class Setting_Tonemapping_LookupTexture_Contribution : Setting_Tonemapping<float>
  {
    public override string EditorName => "Tonemapping Lookup Texture Contribution (HDRP)";

    public override string FieldName => "lutContribution";

    public Setting_Tonemapping_LookupTexture_Contribution()
    {
      options.AddMinMaxRangeValues("0", "1");
      options.AddStepSize("0.01");
      options.AddOneHundredMultiplierAndPercent();

      defaultValue = 1f;
    }
  }
}