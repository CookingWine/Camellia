﻿//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2021 Jiang Yin. All rights reserved.
// Homepage: https://gameframework.cn/
// Feedback: mailto:ellan@gameframework.cn
//------------------------------------------------------------

using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Build;

namespace UnityGameFramework.Editor
{
    /// <summary>
    /// 脚本宏定义。
    /// </summary>
    public static class ScriptingDefineSymbols
    {
        private static readonly BuildTargetGroup[] BuildTargetGroups = new BuildTargetGroup[]
        {
            BuildTargetGroup.Standalone,
            BuildTargetGroup.iOS,
            BuildTargetGroup.Android,
            BuildTargetGroup.WSA,
            BuildTargetGroup.WebGL
        };

        /// <summary>
        /// 检查指定平台是否存在指定的脚本宏定义。
        /// </summary>
        /// <param name="buildTargetGroup">要检查脚本宏定义的平台。</param>
        /// <param name="scriptingDefineSymbol">要检查的脚本宏定义。</param>
        /// <returns>指定平台是否存在指定的脚本宏定义。</returns>
        public static bool HasScriptingDefineSymbol(BuildTargetGroup buildTargetGroup , string scriptingDefineSymbol)
        {
            if(string.IsNullOrEmpty(scriptingDefineSymbol))
            {
                return false;
            }

            string[] scriptingDefineSymbols = GetScriptingDefineSymbols(buildTargetGroup);
            foreach(string i in scriptingDefineSymbols)
            {
                if(i == scriptingDefineSymbol)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 为指定平台增加指定的脚本宏定义。
        /// </summary>
        /// <param name="buildTargetGroup">要增加脚本宏定义的平台。</param>
        /// <param name="scriptingDefineSymbol">要增加的脚本宏定义。</param>
        public static void AddScriptingDefineSymbol(BuildTargetGroup buildTargetGroup , string scriptingDefineSymbol)
        {
            if(string.IsNullOrEmpty(scriptingDefineSymbol))
            {
                return;
            }

            if(HasScriptingDefineSymbol(buildTargetGroup , scriptingDefineSymbol))
            {
                return;
            }

            List<string> scriptingDefineSymbols = new List<string>(GetScriptingDefineSymbols(buildTargetGroup))
            {
                scriptingDefineSymbol
            };

            SetScriptingDefineSymbols(buildTargetGroup , scriptingDefineSymbols.ToArray( ));
        }

        /// <summary>
        /// 为指定平台移除指定的脚本宏定义。
        /// </summary>
        /// <param name="buildTargetGroup">要移除脚本宏定义的平台。</param>
        /// <param name="scriptingDefineSymbol">要移除的脚本宏定义。</param>
        public static void RemoveScriptingDefineSymbol(BuildTargetGroup buildTargetGroup , string scriptingDefineSymbol)
        {
            if(string.IsNullOrEmpty(scriptingDefineSymbol))
            {
                return;
            }

            if(!HasScriptingDefineSymbol(buildTargetGroup , scriptingDefineSymbol))
            {
                return;
            }

            List<string> scriptingDefineSymbols = new List<string>(GetScriptingDefineSymbols(buildTargetGroup));
            while(scriptingDefineSymbols.Contains(scriptingDefineSymbol))
            {
                scriptingDefineSymbols.Remove(scriptingDefineSymbol);
            }

            SetScriptingDefineSymbols(buildTargetGroup , scriptingDefineSymbols.ToArray( ));
        }

        /// <summary>
        /// 为所有平台增加指定的脚本宏定义。
        /// </summary>
        /// <param name="scriptingDefineSymbol">要增加的脚本宏定义。</param>
        public static void AddScriptingDefineSymbol(string scriptingDefineSymbol)
        {
            if(string.IsNullOrEmpty(scriptingDefineSymbol))
            {
                return;
            }

            foreach(BuildTargetGroup buildTargetGroup in BuildTargetGroups)
            {
                AddScriptingDefineSymbol(buildTargetGroup , scriptingDefineSymbol);
            }
        }

        /// <summary>
        /// 为所有平台移除指定的脚本宏定义。
        /// </summary>
        /// <param name="scriptingDefineSymbol">要移除的脚本宏定义。</param>
        public static void RemoveScriptingDefineSymbol(string scriptingDefineSymbol)
        {
            if(string.IsNullOrEmpty(scriptingDefineSymbol))
            {
                return;
            }

            foreach(BuildTargetGroup buildTargetGroup in BuildTargetGroups)
            {
                RemoveScriptingDefineSymbol(buildTargetGroup , scriptingDefineSymbol);
            }
        }

        /// <summary>
        /// 获取指定平台的脚本宏定义。
        /// </summary>
        /// <param name="buildTargetGroup">要获取脚本宏定义的平台。</param>
        /// <returns>平台的脚本宏定义。</returns>
        public static string[] GetScriptingDefineSymbols(BuildTargetGroup buildTargetGroup)
        {
            NamedBuildTarget target = GetNamedBuildTarget(buildTargetGroup);
            PlayerSettings.GetScriptingDefineSymbols(target , out string[] symbols);
            return symbols;
            //return PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTargetGroup).Split(';');
        }

        /// <summary>
        /// 设置指定平台的脚本宏定义。
        /// </summary>
        /// <param name="buildTargetGroup">要设置脚本宏定义的平台。</param>
        /// <param name="scriptingDefineSymbols">要设置的脚本宏定义。</param>
        public static void SetScriptingDefineSymbols(BuildTargetGroup buildTargetGroup , string[] scriptingDefineSymbols)
        {
            NamedBuildTarget target = GetNamedBuildTarget(buildTargetGroup);
            PlayerSettings.GetScriptingDefineSymbols(target , out string[] symbols);
            for(int i = 0; i < scriptingDefineSymbols.Length; i++)
            {
                if(!ArrayUtility.Contains(symbols , scriptingDefineSymbols[i]))
                {
                    ArrayUtility.Add(ref symbols , scriptingDefineSymbols[i]);
                }
            }
            PlayerSettings.SetScriptingDefineSymbols(target , symbols);
            //PlayerSettings.SetScriptingDefineSymbolsForGroup(buildTargetGroup , string.Join(";" , scriptingDefineSymbols));
        }

        private static NamedBuildTarget GetNamedBuildTarget(BuildTargetGroup buildTargetGroup)
        {
            return buildTargetGroup switch
            {
                BuildTargetGroup.Standalone => NamedBuildTarget.Standalone,
                BuildTargetGroup.iOS => NamedBuildTarget.iOS,
                BuildTargetGroup.Android => NamedBuildTarget.Android,
                BuildTargetGroup.WSA => NamedBuildTarget.WindowsStoreApps,
                BuildTargetGroup.WebGL => NamedBuildTarget.WebGL,
                _ => NamedBuildTarget.Standalone,
            };
        }
    }
}
