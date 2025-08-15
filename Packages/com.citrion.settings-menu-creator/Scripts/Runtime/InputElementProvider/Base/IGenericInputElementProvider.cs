using System.Collections.Generic;

namespace CitrioN.SettingsMenuCreator
{
    public interface IGenericInputElementProvider<T> : IInputElementProvider
    {
        IGenericInputElementProvider<T> GetProvider(SettingsCollection settings);

        T GetInputElement(string settingIdentifier, SettingsCollection settings);

        T FindInputElement(T root, string settingIdentifier, SettingsCollection settings);

        bool UpdateInputElement(T elem, string settingIdentifier,
                                       string labelText, SettingsCollection settings,
                                       List<object> values, bool initialize);
    }
}
