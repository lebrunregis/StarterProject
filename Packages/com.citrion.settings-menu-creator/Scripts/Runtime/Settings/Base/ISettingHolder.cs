using CitrioN.Common;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace CitrioN.SettingsMenuCreator
{
    [SkipObfuscationRename]
    public interface ISettingHolder
    {
#if UNITY_EDITOR
        string MenuName { get; }
#endif

        string Identifier { get; set; }

        Setting Setting { get; set; }

        bool ApplyImmediately { get; set; }

        InputElementProviderSettings InputElementProviderSettings { get; set; }

        List<string> ParameterTypes { get; }

        List<StringToStringRelation> Options { get; }

        List<string> DisplayOptions { get; }

#if UNITY_EDITOR
        int CurrentTabMenuIndex { get; set; }
#endif

        bool StoreValueInternally { get; }

        [SkipObfuscationRename]
        object ApplySettingChange(SettingsCollection settings, params object[] args);

        [SkipObfuscationRename]
        VisualElement CreateElement_UIToolkit(VisualElement root, SettingsCollection settings);

        [SkipObfuscationRename]
        VisualElement FindElement_UIToolkit(VisualElement root, SettingsCollection settings);

        [SkipObfuscationRename]
        void InitializeElement_UIToolkit(VisualElement elem, SettingsCollection settings, bool initialize);

        [SkipObfuscationRename]
        RectTransform CreateElement_UGUI(RectTransform root, SettingsCollection settings);

        [SkipObfuscationRename]
        RectTransform FindElement_UGUI(RectTransform root, SettingsCollection settings);

        [SkipObfuscationRename]
        void InitializeElement_UGUI(RectTransform elem, SettingsCollection settings, bool initialize);
    }
}
