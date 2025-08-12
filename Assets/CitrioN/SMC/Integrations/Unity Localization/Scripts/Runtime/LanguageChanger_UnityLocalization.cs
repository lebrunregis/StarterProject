using UnityEngine;

namespace CitrioN.SettingsMenuCreator.Integrations
{
  [AddComponentMenu("CitrioN/Localization/Language Changer (Unity Localization)")]
  public class LanguageChanger_UnityLocalization : LanguageChanger
  {
    public override void ChangeLanguage(string localeCode) 
      => UnityLocalizationUtilities.ChangeLanguage(localeCode);
  }
}