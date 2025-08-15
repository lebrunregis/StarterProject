using RelationsInspector.Extensions;
using System.IO;
using UnityEditor;
using UnityEngine;


namespace RelationsInspector.Backend
{
    public class ScriptableObjectBackendToolbar<T> where T : ScriptableObject
    {
        private static readonly GUIContent newButtonContent = new("New", "Create new graph");
        private static readonly GUIContent pathButtonContent = new("", "Where to store the asset files");
        private static readonly GUIContent createEntityButtonContent = new("+", "Create entity");

        // EditorPrefs key for where to store the ScriptableObject assets
        private const string prefsKeyPath = "RelationsInspectorBackendPath";
        private const string newEntityFieldControlName = "NewEntityField";
        private const string defaultEntityName = "entityName";
        private const float defaultEntityNameFieldWidth = 80;

        private readonly RelationsInspectorAPI api;
        private bool waitingForEntityName;  // true if we wait for the user to enter a new for the entity to create
        private string entityName;          // name of the entity to create
        private string assetPath;           // where to store the ScriptableObject assets. relative to Application.dataPath
        private Vector2 createEntityPosition;   // widget coordinates of the entity to create

        // ctor
        public ScriptableObjectBackendToolbar(RelationsInspectorAPI api)
        {
            this.api = api;
            this.assetPath = string.Empty;
        }

        public void SetAssetPath(string path)
        {
            assetPath = path;
            if (assetPath == null)
            {
                // have unique path preference per entity type
                string prefsKey = Path.Combine(prefsKeyPath, typeof(T).Name);
                assetPath = EditorPrefs.GetString(prefsKey, string.Empty);
            }
        }

        public void OnGUI()
        {
            EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
            RenderToolbar();
            EditorGUILayout.EndHorizontal();
        }

        public void RenderToolbar()
        {
            // entiy name field and buttons
            GUI.enabled = waitingForEntityName;
            if (waitingForEntityName)
                RenderEntityCreationGUI();
            GUI.enabled = true;

            // new graph button
            if (GUILayout.Button(newButtonContent, EditorStyles.toolbarButton))
            {
                api.ResetTargets(new object[] { });
            }

            // create entity button
            if (!waitingForEntityName)
            {
                if (GUILayout.Button(createEntityButtonContent, EditorStyles.toolbarButton))
                    InitEntityCreation(Vector2.zero);
            }

            // asset path selector
            pathButtonContent.text = "Path: " + assetPath;
            if (GUILayout.Button(pathButtonContent, EditorStyles.toolbarButton))
            {
                string absoluteAssetDir = Path.Combine(Application.dataPath, assetPath);
                string userSelectedPath = EditorUtility.OpenFolderPanel("Asset directory", absoluteAssetDir, "");
                if (BackendUtil.IsValidAssetDirectory(userSelectedPath))
                {
                    assetPath = userSelectedPath.RemovePrefix(Application.dataPath);
                    string prefsKey = Path.Combine(prefsKeyPath, typeof(T).Name);
                    EditorPrefs.SetString(prefsKey, assetPath);
                }
            }

            GUILayout.FlexibleSpace();
        }

        private void RenderEntityCreationGUI()
        {
            GUILayout.Label("Entity name", EditorStyles.toolbarButton);

            GUI.SetNextControlName(newEntityFieldControlName);
            bool doAddEntity = ControlGotReturnKeyEvent(newEntityFieldControlName);
            entityName = EditorGUILayout.TextField(entityName, GUILayout.Width(defaultEntityNameFieldWidth));
            doAddEntity |= GUILayout.Button("OK", EditorStyles.miniButtonLeft);
            if (doAddEntity)
            {
                CreateEntityAsset();
                // reset entity creation parameters
                waitingForEntityName = false;
                entityName = defaultEntityName;
                GUI.FocusControl("");
            }

            if (GUILayout.Button("X", EditorStyles.miniButtonRight))
                waitingForEntityName = false;
        }

        // create entity asset at the given path
        private void CreateEntityAsset()
        {
            var relativeAssetDirectory = "Assets" + assetPath;
            var path = System.IO.Path.Combine(relativeAssetDirectory, entityName + ".asset");
            path = AssetDatabase.GenerateUniqueAssetPath(path);

            T entity = BackendUtil.CreateAssetOfType<T>(path);
            api.AddEntity(entity, createEntityPosition);
        }

        public void InitEntityCreation(Vector2 entityPosition)
        {
            waitingForEntityName = true;
            entityName = defaultEntityName;
            EditorGUI.FocusTextInControl(newEntityFieldControlName);
            this.createEntityPosition = entityPosition;
        }

        // utility
        // returns true if the given control has focus and received a Return key event
        public static bool ControlGotReturnKeyEvent(string controlName)
        {
            if (GUI.GetNameOfFocusedControl() != controlName)
                return false;

            if (Event.current.isKey)
                return false;

            if (Event.current.keyCode != KeyCode.Return && Event.current.keyCode != KeyCode.KeypadEnter)
                return false;

            return true;
        }
    }
}
