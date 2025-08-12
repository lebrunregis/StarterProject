using CitrioN.Common;
using System.ComponentModel;
using UnityEngine;

namespace CitrioN.SettingsMenuCreator.SRP
{
  [MenuOrder(810)]
  [ExcludeFromMenuSelection]
  [MenuPath("Post Processing/Channel Mixer")]
  public abstract class Setting_ChannelMixer<T> : Setting_Generic_VolumeProfile_Extended<T,
#if UNITY_URP
    UnityEngine.Rendering.Universal.ChannelMixer
#elif UNITY_HDRP
    UnityEngine.Rendering.HighDefinition.ChannelMixer
#else
    ScriptableObject
#endif
    >
  {
    public override string RuntimeName => GetType().Name.Replace("Setting_", "").Replace("_", "").SplitCamelCase();
    public override string EditorNamePrefix => "[PP]";
  }

  [DisplayName("Channel Mixer Active (URP & HDRP)")]
  public class Setting_ChannelMixer_Active : Setting_ChannelMixer<bool>
  {
    public override string EditorName => "Channel Mixer Active (URP & HDRP)";

    public override string FieldName => "active";

    public Setting_ChannelMixer_Active()
    {
      defaultValue = true;
    }
  }

  #region Red Output Channel
  [DisplayName("Channel Mixer Red Output Red (URP & HDRP)")]
  public class Setting_ChannelMixer_RedOutput_Red : Setting_ChannelMixer<float>
  {
    public override string EditorName => "Channel Mixer Red Output Red (URP & HDRP)";

    public override string FieldName => "redOutRedIn";

    public Setting_ChannelMixer_RedOutput_Red()
    {
      options.AddMinMaxRangeValues("-200", "200");
      options.AddStepSize("2");
      defaultValue = 100;
    }
  }

  [DisplayName("Channel Mixer Red Output Green (URP & HDRP)")]
  public class Setting_ChannelMixer_RedOutput_Green : Setting_ChannelMixer<float>
  {
    public override string EditorName => "Channel Mixer Red Output Green (URP & HDRP)";

    public override string FieldName => "redOutGreenIn";

    public Setting_ChannelMixer_RedOutput_Green()
    {
      options.AddMinMaxRangeValues("-200", "200");
      options.AddStepSize("2");
      defaultValue = 0;
    }
  }

  [DisplayName("Channel Mixer Red Output Blue (URP & HDRP)")]
  public class Setting_ChannelMixer_RedOutput_Blue : Setting_ChannelMixer<float>
  {
    public override string EditorName => "Channel Mixer Red Output Blue (URP & HDRP)";

    public override string FieldName => "redOutBlueIn";

    public Setting_ChannelMixer_RedOutput_Blue()
    {
      options.AddMinMaxRangeValues("-200", "200");
      options.AddStepSize("2");
      defaultValue = 0;
    }
  }
  #endregion

  #region Green Output Channel
  [DisplayName("Channel Mixer Green Output Red (URP & HDRP)")]
  public class Setting_ChannelMixer_GreenOutput_Red : Setting_ChannelMixer<float>
  {
    public override string EditorName => "Channel Mixer Green Output Red (URP & HDRP)";

    public override string FieldName => "greenOutRedIn";

    public Setting_ChannelMixer_GreenOutput_Red()
    {
      options.AddMinMaxRangeValues("-200", "200");
      options.AddStepSize("2");
      defaultValue = 0;
    }
  }

  [DisplayName("Channel Mixer Green Output Green (URP & HDRP)")]
  public class Setting_ChannelMixer_GreenOutput_Green : Setting_ChannelMixer<float>
  {
    public override string EditorName => "Channel Mixer Green Output Green (URP & HDRP)";

    public override string FieldName => "greenOutGreenIn";

    public Setting_ChannelMixer_GreenOutput_Green()
    {
      options.AddMinMaxRangeValues("-200", "200");
      options.AddStepSize("2");
      defaultValue = 100;
    }
  }

  [DisplayName("Channel Mixer Green Output Blue (URP & HDRP)")]
  public class Setting_ChannelMixer_GreenOutput_Blue : Setting_ChannelMixer<float>
  {
    public override string EditorName => "Channel Mixer Green Output Blue (URP & HDRP)";

    public override string FieldName => "greenOutBlueIn";

    public Setting_ChannelMixer_GreenOutput_Blue()
    {
      options.AddMinMaxRangeValues("-200", "200");
      options.AddStepSize("2");
      defaultValue = 0;
    }
  }
  #endregion

  #region Blue Output Channel
  [DisplayName("Channel Mixer Blue Output Red (URP & HDRP)")]
  public class Setting_ChannelMixer_BlueOutput_Red : Setting_ChannelMixer<float>
  {
    public override string EditorName => "Channel Mixer Blue Output Red (URP & HDRP)";

    public override string FieldName => "blueOutRedIn";

    public Setting_ChannelMixer_BlueOutput_Red()
    {
      options.AddMinMaxRangeValues("-200", "200");
      options.AddStepSize("2");
      defaultValue = 0;
    }
  }

  [DisplayName("Channel Mixer Blue Output Green (URP & HDRP)")]
  public class Setting_ChannelMixer_BlueOutput_Green : Setting_ChannelMixer<float>
  {
    public override string EditorName => "Channel Mixer Blue Output Green (URP & HDRP)";

    public override string FieldName => "blueOutGreenIn";

    public Setting_ChannelMixer_BlueOutput_Green()
    {
      options.AddMinMaxRangeValues("-200", "200");
      options.AddStepSize("2");
      defaultValue = 0;
    }
  }

  [DisplayName("Channel Mixer Blue Output Blue (URP & HDRP)")]
  public class Setting_ChannelMixer_BlueOutput_Blue : Setting_ChannelMixer<float>
  {
    public override string EditorName => "Channel Mixer Blue Output Blue (URP & HDRP)";

    public override string FieldName => "blueOutBlueIn";

    public Setting_ChannelMixer_BlueOutput_Blue()
    {
      options.AddMinMaxRangeValues("-200", "200");
      options.AddStepSize("2");
      defaultValue = 100;
    }
  }
  #endregion
}