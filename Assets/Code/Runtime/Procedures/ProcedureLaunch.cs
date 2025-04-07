using GameFramework.Localization;
using GameFramework.Procedure;
using System;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
namespace Camellia.Runtime
{
    /// <summary>
    /// 流程入口
    /// </summary>
    internal class ProcedureLaunch:ProcedureBase
    {
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);

            InitSDK( );

            InitBuildInfo( );

            InitLanguageSettings( );
            //TODO:后续这里其实应该等待视频播放完成，如果视频播放完成但是还没有加载完毕那就停留在最后一帧视频
            SwitchGameProcedure(procedureOwner);
        }

        /// <summary>
        /// 初始化检查构建信息
        /// </summary>
        private void InitBuildInfo( )
        {

        }

        /// <summary>
        /// 初始化SDK【这里应该通过异步去请求权限,而且是在游戏刚开始得时候去判断有没有改权限】
        /// </summary>
        private void InitSDK( )
        {
            //这里根据平台去请求一些权限问题
        }

        /// <summary>
        /// 初始化语言配置
        /// </summary>
        private void InitLanguageSettings( )
        {
            //获取当前使用的语言
            string languageString = CamelliaApp.Setting.GetString(GlobalVariable.USER_LANGUAGE , Language.ChineseSimplified.ToString( ));
            Language language = (Language)Enum.Parse(typeof(Language) , languageString);
            if(language != Language.English && language != Language.ChineseSimplified)
            {
                //如果语言不是支持的语言默认使用中文
                language = Language.ChineseSimplified;
                CamelliaApp.Setting.SetString(GlobalVariable.USER_LANGUAGE , language.ToString( ));
                CamelliaApp.Setting.Save( );
            }
            CamelliaApp.BuiltinData.ResourceAsync($"Localization/{language}" , (textAssets) =>
            {
                TextAsset asset = textAssets as TextAsset;
                if(asset != null)
                {
                    if(!CamelliaApp.Localization.ParseData(asset.text))
                    {
                        Log.Warning("Parse default dictionary failure.");
                        return;
                    }
                    CamelliaApp.Localization.Language = language;
                    Log.Info("The initialization language configuration is complete, and the current language is {0}." , language.ToString( ));
                }
                else
                {
                    Log.Error("Load language configs failure!");
                }
            });
        }


        /// <summary>
        /// 切换游戏流程
        /// </summary>
        /// <param name="procedureOwner"></param>
        void SwitchGameProcedure(ProcedureOwner procedureOwner)
        {
            if(CamelliaApp.Base.EditorResourceMode)
            {
                // 编辑器模式
                Log.Info("Editor resource mode detected.");
                ChangeState<ProcedurePreloadDll>(procedureOwner);
            }
            else if(CamelliaApp.Resource.ResourceMode == GameFramework.Resource.ResourceMode.Package)
            {
                // 单机模式
                Log.Info("Package resource mode detected.");
                ChangeState<ProcedureInitResources>(procedureOwner);
            }
            else
            {
                // 可更新模式
                Log.Info("Updatable resource mode detected.");
                ChangeState<ProcedureCheckVersion>(procedureOwner);
            }
        }
    }
}
