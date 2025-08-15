using RelationsInspector;
using UnityEditor;

public class RelationsInspectorMenuItem
{
    [MenuItem("Window/RelationsInspector")]
    private static void SpawnWindow()
    {
        EditorWindow.GetWindow<RelationsInspectorWindow>("Relations", typeof(SceneView));
    }
}
