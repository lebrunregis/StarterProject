using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;

namespace CitrioN.SettingsMenuCreator.Integrations
{
  public static class UnityLocalizationUtilities
  {
    public static string Localize(string tableName, string key)
    {
      var table = LocalizationSettings.StringDatabase.GetTable(tableName);
      return Localize(table, key);
    }

    public static string Localize(StringTable table, string key)
    {
      if (table == null) { return key; }

      var entry = table.GetEntry(key);
      if (entry == null) { return key; }

      return entry.GetLocalizedString();
    }

    public static void ChangeLanguage(string localeCode)
    {
      Locale locale = LocalizationSettings.AvailableLocales.GetLocale(localeCode);
      if (locale == null) { return; }
      LocalizationSettings.SelectedLocale = locale;
    }

    public static string ActiveLanguage()
    {
      var currentLocale = LocalizationSettings.SelectedLocale;
      return currentLocale ? currentLocale.Identifier.Code : string.Empty;
    }

    public static string DefaultLanguage()
    {
      var defaultLocale = LocalizationSettings.ProjectLocale;
      return defaultLocale ? defaultLocale.Identifier.Code : string.Empty;
    }
  } 
}