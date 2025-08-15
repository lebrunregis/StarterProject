#if GRIFFIN
using UnityEditor;
using UnityEngine;

namespace Pinwheel.Griffin.Wizard
{
    public static class GUrpPackageImporter
    {
        public static void Import()
        {
            string packagePath = GEditorSettings.Instance.renderPipelines.GetUrpPackagePath();
            if (string.IsNullOrEmpty(packagePath))
            {
                Debug.Log("URP Support package not found. Please re-install Polaris.");
                return;
            }

            AssetDatabase.ImportPackage(packagePath, false);
        }
    }
}
#endif
