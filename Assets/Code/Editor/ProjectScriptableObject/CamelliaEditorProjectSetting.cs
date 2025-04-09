using UnityEngine;
using UnityEditorInternal;
namespace Camellia.CamelliaEditor
{
    /// <summary>
    /// 项目配置文件
    /// </summary>
    internal partial class CamelliaEditorProjectSetting:ScriptableObject
    {
#if CAMELLIA_TEST
        /// <summary>
        /// 项目配置路径
        /// </summary>
        const string ProjectSettingAssetsPath = "ProjectSettings/CamelliaGameSettingTest.asset";

#else
        /// <summary>
        /// 项目配置路径
        /// </summary>
        const string ProjectSettingAssetsPath = "ProjectSettings/CamelliaGameSetting.asset";
#endif
        static CamelliaEditorProjectSetting s_Instance;

        /// <summary>
        /// 项目配置
        /// </summary>
        public static CamelliaEditorProjectSetting Instance
        {
            get
            {
                if(s_Instance == null)
                {
                    throw new System.Exception(CamelliaLog.EditorException("Load camellia game setting failue!"));
                }
                return s_Instance;
            }
        }

        /// <summary>
        /// 加载项目配置
        /// </summary>
        internal static void LoadCamelliaProjectSetting( )
        {
            if(s_Instance != null)
            {
                return;
            }
            Object[] asset = InternalEditorUtility.LoadSerializedFileAndForget(ProjectSettingAssetsPath);
            if(asset.Length > 0)
            {
                s_Instance = asset[0] as CamelliaEditorProjectSetting;
            }
            else
            {
                s_Instance = CreateInstance<CamelliaEditorProjectSetting>( );
                Instance.SaveProjectSetting( );
            }
            CamelliaLog.Log("加载项目配置完毕");
        }

        internal void SaveProjectSetting(bool save = true)
        {
            if(!s_Instance)
            {
                throw new System.Exception(CamelliaLog.EditorException("Unable to save camera game settings, camera game settings resource not loaded."));
            }
            Object[] obj = new CamelliaEditorProjectSetting[1] { s_Instance };
            InternalEditorUtility.SaveToSerializedFileAndForget(obj , ProjectSettingAssetsPath , save);
        }
    }
}
