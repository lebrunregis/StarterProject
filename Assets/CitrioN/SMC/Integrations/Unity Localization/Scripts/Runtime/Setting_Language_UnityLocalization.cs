using CitrioN.Common;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Localization.Settings;

namespace CitrioN.SettingsMenuCreator.Integrations
{
  [MenuOrder(100)]
  [MenuPath("Integrations/Localization")]
  [DisplayName("Language (Unity Localization)")]
  public class Setting_Language_UnityLocalization : Setting
  {
    public override string EditorNamePrefix => "[Localization]";

    public override string EditorName => "Language (Unity Localization)";

    public override string RuntimeName => "Language";

    public override List<string> ParameterTypes => new List<string>() { typeof(string).AssemblyQualifiedName };

    public override bool StoreValueInternally => true;

    public override List<StringToStringRelation> Options
    {
      get
      {
        List<StringToStringRelation> options = new List<StringToStringRelation>();

        foreach (var locale in LocalizationSettings.AvailableLocales.Locales)
        {
          options.Add(new StringToStringRelation(locale.Identifier.Code, locale.Identifier.Code));
        }

        return options;
      }
    }

    public override List<object> GetCurrentValues(SettingsCollection settings)
    {
      return new List<object>() { UnityLocalizationUtilities.ActiveLanguage() };
    }

    public override object ApplySettingChange(SettingsCollection settings, params object[] args)
    {
      if (args?.Length > 0)
      {
        if (args[0] is string stringValue)
        {
          base.ApplySettingChange(settings, stringValue);

          if (Time.time > 0)
          {
            UnityLocalizationUtilities.ChangeLanguage(stringValue);
            return UnityLocalizationUtilities.ActiveLanguage();
          }
          else
          {
            // We need to invoke the language change one frame later so
            // Unity's Localization system has time to get initialized.
            ScheduleUtility.InvokeDelayedByFrames(() 
              => UnityLocalizationUtilities.ChangeLanguage(stringValue));
            return stringValue;
          }
        }
      }
      base.ApplySettingChange(settings, null);
      return null;
    }

    public override object GetDefaultValue(SettingsCollection settings)
    {
      return UnityLocalizationUtilities.DefaultLanguage();
    }
  }
}