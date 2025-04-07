using Camellia.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using LitJson;
using UnityEngine;
using UnityEditor;
namespace Camellia.Editor
{
    /// <summary>
    /// 本地多语言配置
    /// </summary>
    internal class LocalizedLanguageConfiguration:CamelliaEditorWindowsBase
    {
        internal override string WindowsName => "多语言配置";

        internal override bool AddWindowsConfigs => true;

        bool m_DrawRuntime = true;

        //非热更的语言配置
        readonly Dictionary<string , CamelliaGameDataStruct.LocalizedLanguage> m_CacheRuntime = new Dictionary<string , CamelliaGameDataStruct.LocalizedLanguage>( );
        //热更的语言配置
        readonly Dictionary<string , CamelliaGameDataStruct.LocalizedLanguage> m_CacheLogic = new Dictionary<string , CamelliaGameDataStruct.LocalizedLanguage>( );
        internal override void DrawWindowContent(float width , float height)
        {
            EditorGUILayout.BeginVertical(GUILayout.Height(height * 0.85f));
            {
                if(m_DrawRuntime)
                {

                }
                else
                {

                }
            }
            EditorGUILayout.EndVertical( );
            GUILayout.Space(10);

            EditorGUILayout.BeginHorizontal(GUILayout.Height(height * 0.15f));
            {
                string content = m_DrawRuntime ? "切换热更语言配置" : "切换非热更语言配置";
                if(GUILayout.Button(content))
                {
                    m_DrawRuntime = !m_DrawRuntime;
                }
                if(GUILayout.Button("添加一项"))
                {
                    if(m_DrawRuntime)
                    {
                        foreach(var item in m_CacheRuntime)
                        {
                            item.Value.LanguageData.Add(new CamelliaGameDataStruct.LocalizedLanguageItem( ));
                        }
                    }
                    else
                    {

                    }
                }

                if(GUILayout.Button("保存配置"))
                {

                }
            }
            EditorGUILayout.EndHorizontal( );

        }

        internal override void LoadConfigurationResources(Action<bool> compelete)
        {
            string[] runtime = LoadAndReadFile(CamelliaEditorConstConfigs.RuntimeLocalizedLanguagePath);
            for(int i = 0; i < runtime.Length; i++)
            {
                string content = File.ReadAllText(runtime[i]);
                CamelliaGameDataStruct.LocalizedLanguage item = JsonMapper.ToObject<CamelliaGameDataStruct.LocalizedLanguage>(content);
                m_CacheRuntime.Add(runtime[i] , item);
            }
            string[] logic = LoadAndReadFile(CamelliaEditorConstConfigs.LogicLocalizedLanguagePath);
            for(int i = 0; i < logic.Length; i++)
            {
                string content = File.ReadAllText(runtime[i]);
                CamelliaGameDataStruct.LocalizedLanguage item = JsonMapper.ToObject<CamelliaGameDataStruct.LocalizedLanguage>(content);
                m_CacheLogic.Add(runtime[i] , item);
            }
            m_DrawRuntime = true;
            compelete?.Invoke(true);
        }

        string[] LoadAndReadFile(string path)
        {

            path = Path.Combine(Application.dataPath , path);
            try
            {
                return Directory.GetFiles(path , "*.json");
            }
            catch(Exception ex)
            {
                CamelliaLog.EditorException(ex.Message);
                return null;
            }
        }
    }
}
