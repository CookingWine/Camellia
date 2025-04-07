using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
namespace Camellia.Runtime
{
    internal class ProcedureUpdateResources:ProcedureBase
    {
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            Log.Info("Start update resources!");
        }

        protected override void OnLeave(ProcedureOwner procedureOwner , bool isShutdown)
        {
            base.OnLeave(procedureOwner , isShutdown);
        }
    }
}
