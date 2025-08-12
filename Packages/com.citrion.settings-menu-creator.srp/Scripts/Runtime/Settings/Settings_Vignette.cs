using CitrioN.Common;
using System.ComponentModel;
using UnityEngine;

namespace CitrioN.SettingsMenuCreator.SRP
{
  [MenuOrder(810)]
  [ExcludeFromMenuSelection]
  [MenuPath("Post Processing/Vignette")]
  public abstract class Setting_Vignette<T> : Setting_Generic_VolumeProfile_Extended<T,
#if UNITY_URP
    UnityEngine.Rendering.Universal.Vignette
#elif UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.Vignette
#else
    ScriptableObject
#endif
    >
  {
    public override string RuntimeName => GetType().Name.Replace("Setting_", "").Replace("_", "").SplitCamelCase();
    public override string EditorNamePrefix => "[PP]";
  }

  [DisplayName("Vignette Active (URP & HDRP)")]
  public class Setting_Vignette_Active : Setting_Vignette<bool>
  {
    public override string EditorName => "Vignette Active (URP & HDRP)";

    public override string FieldName => "active";

    public Setting_Vignette_Active()
    {
      defaultValue = true;
    }
  }

  [DisplayName("Vignette Mode (HDRP)")]
  public class Setting_Vignette_Mode : Setting_Vignette<
#if UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.VignetteMode
#else
    int
#endif
    >
  {
    public override string EditorName => "Vignette Mode (HDRP)";

    public override string FieldName => "mode";

    public Setting_Vignette_Mode()
    {
#if UNITY_HDRP
      defaultValue = UnityEngine.Rendering.HighDefinition.VignetteMode.Procedural;
#endif
    }
  } 

  // TODO Enable once color support has been added
  //[DisplayName("Vignette Color")]
  //public class Setting_Vignette_Color : Setting_Vignette<UnityEngine.Color>
  //{
  //  public override string FieldName => nameof(Vignette.color);

  //  public Setting_Vignette_Color()
  //  {
  //    defaultValue = UnityEngine.Color.black;
  //  }
  //}

  // TODO Enable once Vector2 support has been added
  //[DisplayName("Vignette Center")]
  //public class Setting_Vignette_Center : Setting_Vignette<UnityEngine.Vector2>
  //{
  //  public override string FieldName => nameof(Vignette.center);

  //  public Setting_Vignette_Center()
  //  {
  //    defaultValue = new UnityEngine.Vector2(0.5f, 0.5f);
  //  }
  //}

  [DisplayName("Vignette Intensity (URP & HDRP)")]
  public class Setting_Vignette_Intensity : Setting_Vignette<float>
  {
    public override string EditorName => "Vignette Intensity (URP & HDRP)";

    public override string FieldName => "intensity";

    public Setting_Vignette_Intensity()
    {
      options.AddMinMaxRangeValues("0", "1");
      options.AddStepSize("0.01");
      options.AddOneHundredMultiplierAndPercent();

      defaultValue = 0.0f;
    }
  }

  [DisplayName("Vignette Smoothness (URP & HDRP)")]
  public class Setting_Vignette_Smoothness : Setting_Vignette<float>
  {
    public override string EditorName => "Vignette Smoothness (URP & HDRP)";

    public override string FieldName => "smoothness";

    public Setting_Vignette_Smoothness()
    {
      options.AddMinMaxRangeValues("0.01", "1");
      options.AddStepSize("0.01");
      options.AddOneHundredMultiplierAndPercent();

      defaultValue = 0.2f;
    }
  }

  [DisplayName("Vignette Roundness (HDRP)")]
  public class Setting_Vignette_Roundness : Setting_Vignette<float>
  {
    public override string EditorName => "Vignette Roundness (HDRP)";

    public override string FieldName => "roundness";

    public Setting_Vignette_Roundness()
    {
      options.AddMinMaxRangeValues("0", "1");
      options.AddStepSize("0.01");
      options.AddOneHundredMultiplierAndPercent();

      defaultValue = 1f;
    }
  }

  [DisplayName("Vignette Rounded (URP & HDRP)")]
  public class Setting_Vignette_Rounded : Setting_Vignette<bool>
  {
    public override string EditorName => "Vignette Rounded (URP & HDRP)";

    public override string FieldName => "rounded";

    public Setting_Vignette_Rounded()
    {
      defaultValue = false;
    }
  }

  //[DisplayName("Vignette Opacity")]
  //public class Setting_Vignette_Opacity : Setting_Vignette<float>
  //{
  //  public override string FieldName => nameof(Vignette.opacity);

  //  public Setting_Vignette_Opacity()
  //  {
  //    options.AddMinMaxRangeValues("0", "1");
  //    options.AddStepSize("0.01");
  //    defaultValue = 1f;
  //  }
  //}
}