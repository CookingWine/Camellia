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
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Log.Info("Enter init resouces procedure!");
            CamelliaApp.Resource.InitResources(OnInitResourceComplete);
        }

        protected override void OnLeave(ProcedureOwner procedureOwner , bool isShutdown)
        {
            base.OnLeave(procedureOwner , isShutdown);
        }

        /// <summary>
        /// 初始化资源完成回调
        /// </summary>
        private void OnInitResourceComplete( )
        {

        }
    }
}
