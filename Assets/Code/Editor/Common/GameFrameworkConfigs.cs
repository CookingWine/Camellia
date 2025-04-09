using UnityGameFramework.Editor.ResourceTools;
using UnityGameFramework.Editor;
using GameFramework;
using System.IO;
using UnityEngine;

namespace Camellia.CamelliaEditor
{
    /// <summary>
    /// GF配置
    /// </summary>
    public static class GameFrameworkConfigs
    {
        [BuildSettingsConfigPath]
        public static string BuildSettingsConfig = Utility.Path.GetRegularPath(Path.Combine(Application.dataPath , "GameConfigAssets/GameFramework/BuildSettings.xml"));

        [ResourceCollectionConfigPath]
        public static string ResourceCollectionConfig = Utility.Path.GetRegularPath(Path.Combine(Application.dataPath , "GameConfigAssets/GameFramework/Release/ResourceCollection.xml"));

        [ResourceEditorConfigPath]
        public static string ResourceEditorConfig = Utility.Path.GetRegularPath(Path.Combine(Application.dataPath , "GameConfigAssets/GameFramework/ResourceEditor.xml"));

        [ResourceBuilderConfigPath]
        public static string ResourceBuilderConfig = Utility.Path.GetRegularPath(Path.Combine(Application.dataPath , "GameConfigAssets/GameFramework/Release/Base/ResourceBuilder.xml"));
    }
}
