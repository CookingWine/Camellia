using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
namespace Camellia.Runtime
{
    internal class ProcedurePreloadDll:ProcedureBase
    {
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Log.Info("Enter load dll procedure!");

            CamelliaApp.Hybridclr.HotfixEntry(OnDestroyFsm);
        }

        /// <summary>
        /// 销毁状态机
        /// </summary>
        void OnDestroyFsm( )
        {
            CamelliaApp.Fsm.DestroyFsm<IProcedureManager>( );
        }
    }
}
