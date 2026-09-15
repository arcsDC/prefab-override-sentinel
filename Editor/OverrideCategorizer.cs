using UnityEngine;

namespace PrefabOverrideSentinel
{
    public enum OverrideCategory { All, Transform, Component, Material, Animation, Other }

    public static class OverrideCategorizer
    {
        public static OverrideCategory Classify(string propertyPath)
        {
            if (string.IsNullOrEmpty(propertyPath)) return OverrideCategory.Other;
            if (propertyPath.StartsWith("m_LocalPosition") || propertyPath.StartsWith("m_LocalRotation") || propertyPath.StartsWith("m_LocalScale"))
                return OverrideCategory.Transform;
            if (propertyPath.Contains("m_Materials") || propertyPath.Contains("m_Material"))
                return OverrideCategory.Material;
            if (propertyPath.Contains("m_Animation") || propertyPath.Contains("m_Controller"))
                return OverrideCategory.Animation;
            if (propertyPath.Contains("m_Script") || propertyPath.Contains("m_Enabled"))
                return OverrideCategory.Component;
            return OverrideCategory.Other;
        }
    }
}
