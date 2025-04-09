using UnityEditor;
using UnityGameFramework.Editor;
using UnityGameFramework.Editor.ResourceTools;

namespace Camellia.CamelliaEditor
{
    /// <summary>
    /// 编辑器菜单
    /// </summary>
    internal class CamelliaEditorMenuItem
    {
        #region Project

        [MenuItem("Game Framework/白茶编辑器配置" , false)]
        internal static void OpenCamelliaWindows( )
        {
            CamelliaEditorWindows.OpenCamelliaWindows( );
        }

#if CAMELLIA_TEST

        [MenuItem("Game Framework/切换到正式服" , false , 1)]
        internal static void SwitchOfficialEnvironment( )
        {
            ScriptingDefineSymbols.RemoveScriptingDefineSymbol(CamelliaEditorConstConfigs.CAMELLIA_TEST);
        }
#else

        [MenuItem("Game Framework/切换到测试服" , false , 1)]
        internal static void SwitchTestingEnvironment( )
        {
            ScriptingDefineSymbols.AddScriptingDefineSymbol(CamelliaEditorConstConfigs.CAMELLIA_TEST);
        }
#endif

        #endregion

        #region GameFramework

        [MenuItem("Game Framework/打开文件夹/Data Path" , false , 10)]
        internal static void OpenFolderDataPath( )
        {
            OpenFolder.OpenFolderDataPath( );
        }

        [MenuItem("Game Framework/打开文件夹/Persistent Data Path" , false , 11)]
        internal static void OpenFolderPersistentDataPath( )
        {
            OpenFolder.OpenFolderPersistentDataPath( );
        }

        [MenuItem("Game Framework/打开文件夹/Streaming Assets Path" , false , 12)]
        internal static void OpenFolderStreamingAssetsPath( )
        {
            OpenFolder.OpenFolderStreamingAssetsPath( );
        }

        [MenuItem("Game Framework/打开文件夹/Temporary Cache Path" , false , 13)]
        internal static void OpenFolderTemporaryCachePath( )
        {
            OpenFolder.OpenFolderTemporaryCachePath( );
        }

        [MenuItem("Game Framework/打开文件夹/Console Log Path" , false , 14)]
        internal static void OpenFolderConsoleLogPath( )
        {
            OpenFolder.OpenFolderConsoleLogPath( );
        }

        [MenuItem("Game Framework/场景/将构建场景设置为默认" , false , 20)]
        internal static void DefaultScenes( )
        {
            BuildSettings.DefaultScenes( );
        }

        [MenuItem("Game Framework/场景/将构建场景设置为所有" , false , 21)]
        internal static void AllScenes( )
        {
            BuildSettings.AllScenes( );
        }

        [MenuItem("Game Framework/日志/禁用所有日志脚本宏定义" , false , 30)]
        internal static void DisableAllLogs( )
        {
            LogScriptingDefineSymbols.DisableAllLogs( );
        }
        [MenuItem("Game Framework/日志/开启所有日志脚本宏定义" , false , 31)]
        internal static void EnableAllLogs( )
        {
            LogScriptingDefineSymbols.EnableAllLogs( );
        }
        [MenuItem("Game Framework/日志/开启调试及以上级别的日志脚本宏定义" , false , 32)]
        internal static void EnableDebugAndAboveLogs( )
        {
            LogScriptingDefineSymbols.EnableDebugAndAboveLogs( );
        }
        [MenuItem("Game Framework/日志/开启信息及以上级别的日志脚本宏定义" , false , 33)]
        internal static void EnableInfoAndAboveLogs( )
        {
            LogScriptingDefineSymbols.EnableInfoAndAboveLogs( );
        }
        [MenuItem("Game Framework/日志/开启警告及以上级别的日志脚本宏定义" , false , 34)]
        internal static void EnableWarningAndAboveLogs( )
        {
            LogScriptingDefineSymbols.EnableWarningAndAboveLogs( );
        }
        [MenuItem("Game Framework/日志/开启错误及以上级别的日志脚本宏定义" , false , 35)]
        internal static void EnableErrorAndAboveLogs( )
        {
            LogScriptingDefineSymbols.EnableErrorAndAboveLogs( );
        }
        [MenuItem("Game Framework/日志/开启严重错误及以上级别的日志脚本宏定义" , false , 36)]
        internal static void EnableFatalAndAboveLogs( )
        {
            LogScriptingDefineSymbols.EnableFatalAndAboveLogs( );
        }
        [MenuItem("Game Framework/资源工具/资源生成器" , false , 40)]
        internal static void OpenResourceBuilder( )
        {
            ResourceBuilder.Open( );
        }
        [MenuItem("Game Framework/资源工具/资源编辑器" , false , 41)]
        internal static void OpenResourceEditor( )
        {
            ResourceEditor.Open( );
        }
        [MenuItem("Game Framework/资源工具/资源分析器" , false , 42)]
        internal static void OpenResourceAnalyzer( )
        {
            ResourceAnalyzer.Open( );
        }
        [MenuItem("Game Framework/资源工具/资源包生成器" , false , 43)]
        internal static void OpenResourcePackBuilder( )
        {
            ResourcePackBuilder.Open( );
        }
        [MenuItem("Game Framework/资源工具/资源同步工具" , false , 44)]
        internal static void OpenResourceSyncTools( )
        {
            ResourceSyncTools.Open( );
        }
        [MenuItem("Game Framework/帮助/文档" , false , 90)]
        internal static void HelpShowDocumentation( )
        {
            UnityGameFramework.Editor.Help.ShowDocumentation( );
        }
        [MenuItem("Game Framework/帮助/API 参考" , false , 91)]
        internal static void HelpShowApiReference( )
        {
            UnityGameFramework.Editor.Help.ShowApiReference( );
        }

        #endregion
    }
}
