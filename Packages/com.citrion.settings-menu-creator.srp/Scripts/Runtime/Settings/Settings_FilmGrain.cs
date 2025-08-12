using CitrioN.Common;
using System.ComponentModel;
using UnityEngine;

namespace CitrioN.SettingsMenuCreator.SRP
{
  [MenuOrder(810)]
  [ExcludeFromMenuSelection]
  [MenuPath("Post Processing/Film Grain")]
  public abstract class Setting_FilmGrain<T> : Setting_Generic_VolumeProfile_Extended<T,
#if UNITY_URP
    UnityEngine.Rendering.Universal.FilmGrain
#elif UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.FilmGrain
#else
    ScriptableObject
#endif
    >
  {
    public override string RuntimeName => GetType().Name.Replace("Setting_", "").Replace("_", "").SplitCamelCase();
    public override string EditorNamePrefix => "[PP]";
  }

  [DisplayName("Film Grain Active (URP & HDRP)")]
  public class Setting_FilmGrain_Active : Setting_FilmGrain<bool>
  {
    public override string EditorName => "Film Grain Active (URP & HDRP)";

    public override string FieldName => "active";

    public Setting_FilmGrain_Active()
    {
      defaultValue = true;
    }
  }

  [DisplayName("Film Grain Type (URP)")]
  public class Setting_FilmGrain_Type_URP : Setting_FilmGrain<

#if UNITY_URP
    UnityEngine.Rendering.Universal.FilmGrainLookup
#else
    int
#endif
    >
  {
    public override string RuntimeName => "Film Grain Type (URP)";

    public override string EditorName => "Film Grain Type (URP)";

    public override string FieldName => "type";

    public Setting_FilmGrain_Type_URP()
    {
#if UNITY_URP
      defaultValue = UnityEngine.Rendering.Universal.FilmGrainLookup.Thin1;
#endif
    }
  } 

  [DisplayName("Film Grain Type (HDRP)")]
  public class Setting_FilmGrain_Type_HDRP : Setting_FilmGrain<
#if UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.FilmGrainLookup
#else
    int
#endif
    >
  {
    public override string RuntimeName => "Film Grain Type (HDRP)";

    public override string EditorName => "Film Grain Type (HDRP)";

    public override string FieldName => "type";

    public Setting_FilmGrain_Type_HDRP()
    {
#if UNITY_HDRP
      defaultValue = UnityEngine.Rendering.HighDefinition.FilmGrainLookup.Thin1;
#endif
    }
  } 

  [DisplayName("Film Grain Intensity (URP & HDRP)")]
  public class Setting_FilmGrain_Intensity : Setting_FilmGrain<float>
  {
    public override string EditorName => "Film Grain Intensity (URP & HDRP)";

    public override string FieldName => "intensity";

    public Setting_FilmGrain_Intensity()
    {
      options.AddMinMaxRangeValues("0", "1");
      options.AddStepSize("0.01");
      options.AddOneHundredMultiplierAndPercent();

      defaultValue = 0.0f;
    }
  }

  [DisplayName("Film Grain Response (URP & HDRP)")]
  public class Setting_FilmGrain_Response : Setting_FilmGrain<float>
  {
    public override string EditorName => "Film Grain Response (URP & HDRP)";

    public override string FieldName => "response";

    public Setting_FilmGrain_Response()
    {
      options.AddMinMaxRangeValues("0", "1");
      options.AddStepSize("0.01");

      defaultValue = 0.8f;
    }
  }

  // TODO Enable once Texture2D support has been added
  //[DisplayName("Film Grain Texture")]
  //public class Setting_FilmGrain_Texture : Setting_FilmGrain<UnityEngine.Texture2D>
  //{
  //  public override string FieldName => nameof(FilmGrain.texture);

  //  public Setting_FilmGrain_Texture()
  //  {

  //  }
  //}
}