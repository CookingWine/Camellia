using GameFramework;
using GameFramework.Event;
using GameFramework.Procedure;
using GameFramework.Resource;
using System.IO;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
namespace Camellia.Runtime
{
    /// <summary>
    /// 检查版本流程
    /// </summary>
    internal class ProcedureCheckVersion:ProcedureBase
    {
        private ProcedureOwner m_CurrentProcedure;
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            m_CurrentProcedure = procedureOwner;
            Log.Info("Entry check version procedure!");
            //注册网络请求事件
            CamelliaApp.Event.Subscribe(WebRequestSuccessEventArgs.EventId , OnWebRequestSuccess);
            CamelliaApp.Event.Subscribe(WebRequestFailureEventArgs.EventId , OnWebRequestFailure);

            string versionUrl = Utility.Text.Format("https://suizhou-wukong.oss-cn-beijing.aliyuncs.com/PlayFreelyXiYouBate/{0}/Version.txt" , GlobalVariable.GetPlatform);
            CamelliaApp.WebRequest.AddWebRequest(versionUrl , (object)"ProcedureCheckVersion");
        }

        protected override void OnLeave(ProcedureOwner procedureOwner , bool isShutdown)
        {
            //注销
            if(CamelliaApp.Event.Check(WebRequestStartEventArgs.EventId , OnWebRequestSuccess))
            {
                CamelliaApp.Event.Unsubscribe(WebRequestStartEventArgs.EventId , OnWebRequestSuccess);
            }
            if(CamelliaApp.Event.Check(WebRequestFailureEventArgs.EventId , OnWebRequestFailure))
            {
                CamelliaApp.Event.Unsubscribe(WebRequestFailureEventArgs.EventId , OnWebRequestFailure);
            }
            m_CurrentProcedure = null;
            base.OnLeave(procedureOwner , isShutdown);
        }
        /// <summary>
        /// web请求成功回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWebRequestSuccess(object sender , GameEventArgs e)
        {
            WebRequestSuccessEventArgs args = (WebRequestSuccessEventArgs)e;
            if(args.UserData != (object)"ProcedureCheckVersion")
            {
                return;
            }
            VersionInfo versionInfo = Utility.Json.ToObject<VersionInfo>(Utility.Converter.GetString(args.GetWebResponseBytes( )));
            Version.SetVersionHelper(versionInfo);
            //判断应用是否需要强制更新
            if(versionInfo.ForceUpdateGame)
            {
                //TODO：使用sdk去调用打开商店，去更新应用
            }
            else
            {
                //设置资源更新的地址
                CamelliaApp.Resource.UpdatePrefixUri = Utility.Path.GetRemotePath(Path.Combine(versionInfo.UpdatePrefixUri , versionInfo.InternalResourceVersion.ToString( )));
                //检查版本资源列表需要更新
                if(CamelliaApp.Resource.CheckVersionList(versionInfo.InternalResourceVersion) == CheckVersionListResult.NeedUpdate)
                {
                    //设置更新版本文件的列表数据
                    CamelliaApp.Resource.UpdateVersionList(versionInfo.VersionListLength , versionInfo.VersionListHashCode ,
                        versionInfo.VersionListCompressedLength , versionInfo.VersionListCompressedHashCode
                        , new UpdateVersionListCallbacks(OnUpdateVersionListSuccess , OnUpdateVersionListFailure));
                }
                else
                {
                    ChangeState<ProcedureCheckResources>(m_CurrentProcedure);
                }
            }
        }

        /// <summary>
        /// web请求失败回调
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWebRequestFailure(object sender , GameEventArgs e)
        {
            WebRequestFailureEventArgs args = (WebRequestFailureEventArgs)e;
            if(args.UserData != (object)"ProcedureCheckVersion")
            {
                return;
            }
            Log.Error("Request for version file failed with error message:'{0}'" , args.ErrorMessage);
        }

        /// <summary>
        /// 版本资源列表更新成功回调函数。
        /// </summary>
        /// <param name="downloadPath">版本资源列表更新后存放路径。</param>
        /// <param name="downloadUri">版本资源列表更新地址。</param>
        private void OnUpdateVersionListSuccess(string downloadPath , string downloadUrl)
        {
            Log.Info($"Update version list from '{downloadUrl}' success.Assets path from '{downloadPath}'.");
            ChangeState<ProcedureCheckResources>(m_CurrentProcedure);
        }
        /// <summary>
        /// 版本资源列表更新失败回调函数。
        /// </summary>
        /// <param name="downloadUri">版本资源列表更新地址。</param>
        /// <param name="errorMessage">错误信息。</param>
        private void OnUpdateVersionListFailure(string downloadUrl , string errorMessage)
        {
            Log.Error($"Update version list from '{downloadUrl}' failure, error message is '{errorMessage}'.");
        }

    }
}
