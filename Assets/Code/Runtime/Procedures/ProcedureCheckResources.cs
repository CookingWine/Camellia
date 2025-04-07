using GameFramework.Procedure;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
namespace Camellia.Runtime
{
    /// <summary>
    /// 检查验证资源流程
    /// </summary>
    internal class ProcedureCheckResources:ProcedureBase
    {
        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
        }

        protected override void OnLeave(ProcedureOwner procedureOwner , bool isShutdown)
        {
            base.OnLeave(procedureOwner , isShutdown);

        }
    }
}