using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Collections.Generic;

namespace PrefabOverrideSentinel
{
    public class PrefabInstanceInfo
    {
        public GameObject Instance;
        public List<OverrideInfo> Overrides = new List<OverrideInfo>();
    }

    public class OverrideInfo
    {
        public string PropertyPath;
        public OverrideCategory Category;
    }

    public class SceneOverrideScanner
    {
        public List<PrefabInstanceInfo> Scan(Scene scene)
        {
            var results = new List<PrefabInstanceInfo>();
            var roots = scene.GetRootGameObjects();
            foreach (var root in roots)
            {
                var prefab = PrefabUtility.GetCorrespondingObjectFromSource(root);
                if (prefab == null) continue;
                var info = new PrefabInstanceInfo { Instance = root };
                var overrides = PrefabUtility.GetPropertyModifications(root);
                foreach (var mod in overrides)
                {
                    info.Overrides.Add(new OverrideInfo
                    {
                        PropertyPath = mod.propertyPath,
                        Category = OverrideCategorizer.Classify(mod.propertyPath)
                    });
                }
                results.Add(info);
            }
            return results;
        }
    }
}
