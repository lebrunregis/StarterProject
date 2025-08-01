﻿namespace UnityEditor.SettingsManagement.Examples
{
    // Usually you will only have a single Settings instance, so it is convenient to define a UserSetting<T> implementation
    // that points to your instance. In this way you avoid having to pass the Settings parameter in setting field definitions.
    internal class MySetting<T> : UserSetting<T>
    {
        public MySetting(string key, T value, SettingsScope scope = SettingsScope.Project)
            : base(MySettingsManager.Instance, key, value, scope)
        { }

        private MySetting(Settings settings, string key, T value, SettingsScope scope = SettingsScope.Project)
            : base(settings, key, value, scope) { }
    }
}
