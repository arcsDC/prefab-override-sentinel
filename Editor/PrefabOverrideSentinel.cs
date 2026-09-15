using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

namespace PrefabOverrideSentinel
{
    public class PrefabOverrideSentinel : EditorWindow
    {
        private SceneOverrideScanner scanner = new SceneOverrideScanner();
        private OverrideMerger merger = new OverrideMerger();
        private List<OverrideEntry> entries = new List<OverrideEntry>();
        private string filter = "";
        private OverrideCategory categoryFilter = OverrideCategory.All;
        private Vector2 scroll;

        [MenuItem("Window/Prefab Override Sentinel")]
        public static void Open() => GetWindow<PrefabOverrideSentinel>("Override Sentinel");

        private void OnEnable() { Refresh(); }

        private void Refresh()
        {
            var scene = SceneManager.GetActiveScene();
            var instances = scanner.Scan(scene);
            entries = new List<OverrideEntry>();
            foreach (var inst in instances)
                foreach (var ov in inst.Overrides)
                    entries.Add(new OverrideEntry(inst, ov));
            entries = entries.Where(e =>
                (categoryFilter == OverrideCategory.All || e.Override.Category == categoryFilter) &&
                (string.IsNullOrEmpty(filter) ||
                 e.Instance.name.Contains(filter, System.StringComparison.OrdinalIgnoreCase) ||
                 e.Override.PropertyPath.Contains(filter, System.StringComparison.OrdinalIgnoreCase))
            ).ToList();
            Repaint();
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Rescan", GUILayout.Width(60))) Refresh();
            filter = EditorGUILayout.TextField("Filter", filter, GUILayout.Width(160));
            categoryFilter = (OverrideCategory)EditorGUILayout.EnumPopup(categoryFilter, GUILayout.Width(120));
            EditorGUILayout.LabelField($"{entries.Count} overrides", GUILayout.Width(100));
            EditorGUILayout.EndHorizontal();

            scroll = EditorGUILayout.BeginScrollView(scroll);
            foreach (var e in entries)
            {
                EditorGUILayout.BeginHorizontal(EditorStyles.helpBox);
                EditorGUILayout.LabelField(e.Instance.name, GUILayout.Width(140));
                EditorGUILayout.LabelField(e.Override.PropertyPath, GUILayout.Width(200));
                EditorGUILayout.LabelField(e.Override.Category.ToString(), GUILayout.Width(8
