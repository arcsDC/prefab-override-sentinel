using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace PrefabOverrideSentinel
{
    public static class ProjectValidator
    {
        public static List<string> ValidatePrefabHierarchy(GameObject prefab)
        {
            var issues = new List<string>();
            var components = prefab.GetComponentsInChildren<Component>(true);
            foreach (var comp in components)
            {
                if (comp == null)
                {
                    issues.Add($"Null component reference in {prefab.name}");
                    break;
                }
            }
            var renderers = prefab.GetComponentsInChildren<Renderer>(true);
            foreach (var r in renderers)
            {
                if (r.sharedMaterial == null)
                    issues.Add($"Missing material on {r.name} in {prefab.name}");
            }
            return issues;
        }
    }
}
