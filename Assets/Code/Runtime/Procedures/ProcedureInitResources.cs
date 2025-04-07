using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
namespace Camellia.Runtime
{
    /// <summary>
    /// 单机模式下初始化资源流程
    /// </summary>
    internal class ProcedureInitResources:ProcedureBase
    {
        ProcedureOwner m_CurrentProcedureOwner;
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Log.Info("Enter init resouces procedure!");
            m_CurrentProcedureOwner = procedureOwner;
            CamelliaApp.Resource.InitResources(OnInitResourceComplete);
        }

        protected override void OnLeave(ProcedureOwner procedureOwner , bool isShutdown)
        {
            base.OnLeave(procedureOwner , isShutdown);
            m_CurrentProcedureOwner = null;
        }

        /// <summary>
        /// 初始化资源完成回调
        /// </summary>
        private void OnInitResourceComplete( )
        {
            Log.Info("Single machine mode initialization resource completed!");
            ChangeState<ProcedurePreloadDll>(m_CurrentProcedureOwner);
        }
    }
}
