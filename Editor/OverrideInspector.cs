using UnityEngine;
using UnityEditor;

namespace PrefabOverrideSentinel
{
    [CustomEditor(typeof(GameObject), true)]
    public class OverrideInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var prefab = PrefabUtility.GetCorrespondingObjectFromSource(target as GameObject);
            if (prefab != null)
            {
                EditorGUILayout.Space();
                if (GUILayout.Button("Open in Override Sentinel"))
                    PrefabOverrideSentinel.Open();
            }
        }
    }
}
