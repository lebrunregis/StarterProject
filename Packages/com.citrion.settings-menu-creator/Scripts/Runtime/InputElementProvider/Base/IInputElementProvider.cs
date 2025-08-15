using System;

namespace CitrioN.SettingsMenuCreator
{
    public interface IInputElementProvider
    {
        string Name { get; }

        Type GetInputFieldParameterType(SettingsCollection settings);

        Type GetInputFieldType(SettingsCollection settings);
    }
}
