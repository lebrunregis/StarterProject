using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace CitrioN.SettingsMenuCreator.Integrations
{
    [CreateAssetMenu(fileName = "Localization Provider (Unity)",
                     menuName = "CitrioN/Settings Menu Creator/Localization/Localization Provider (Unity)")]
    public class LocalizationProvider_UnityLocalization : LocalizationProvider
    {
        [SerializeField]
        protected string tableName;

        public override string Localize(string localizationKey)
        {
            return UnityLocalizationUtilities.Localize(tableName, localizationKey);
        }

        public override List<string> Localize(List<string> localizationKeys)
        {
            var list = new List<string>();
            if (localizationKeys == null || localizationKeys.Count < 1) { return list; }
            string localizedValue = null;
            foreach (var key in localizationKeys)
            {
                localizedValue = Localize(key);
                if (string.IsNullOrEmpty(localizedValue)) { localizedValue = key; }
                list.Add(localizedValue);
            }
            return list;
        }

        public override void RegisterForOnLanguageChangedEvent()
        {
            if (IsInitialized(this)) { return; }
            base.RegisterForOnLanguageChangedEvent();
            LocalizationSettings.SelectedLocaleChanged += OnLocaleChange;
        }

        public override void UnregisterFromOnLanguageChangedEvent()
        {
            base.UnregisterFromOnLanguageChangedEvent();
            LocalizationSettings.SelectedLocaleChanged -= OnLocaleChange;
        }

        private void OnLocaleChange(Locale locale)
        {
            OnLanguageChange();
        }
    }
}