using UnityEngine;
using UnityEditor;

namespace PrefabOverrideSentinel
{
    public class SentinelConfig : ScriptableObject
    {
        public bool autoRescanOnSceneChange = true;
        public bool showCategoryColors = true;
        public int maxEntriesDisplayed = 500;

        public static SentinelConfig Load()
        {
            var path = "ProjectSettings/SentinelConfig.asset";
            var config = AssetDatabase.LoadAssetAtPath<SentinelConfig>(path);
            if (config == null)
            {
                config = CreateInstance<SentinelConfig>();
                AssetDatabase.CreateAsset(config, path);
                AssetDatabase.SaveAssets();
            }
            return config;
        }
    }
