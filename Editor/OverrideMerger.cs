using UnityEngine;
using UnityEditor;

namespace PrefabOverrideSentinel
{
    public class OverrideMerger
    {
        public void Revert(GameObject instance, string propertyPath)
        {
            var prefab = PrefabUtility.GetCorrespondingObjectFromSource(instance);
            if (prefab == null) return;
            PrefabUtility.RevertPropertyOverride(instance, propertyPath, InteractionMode.AutomatedAction);
            Debug.Log($"Reverted {propertyPath} on {instance.name}");
        }

        public void Promote(GameObject instance, string propertyPath)
        {
            var prefab = PrefabUtility.GetCorrespondingObjectFromSource(instance);
            if (prefab == null) return;
            PrefabUtility.RevertPropertyOverride(prefab, propertyPath, InteractionMode.AutomatedAction);
            Debug.Log($"Promoted {propertyPath} from {instance.name} to prefab");
        }
    }
}
