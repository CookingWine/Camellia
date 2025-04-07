using UnityEditor;
namespace Camellia.Editor
{
    /// <summary>
    /// 编辑器启动配置
    /// </summary>
    // 此特性会使类的静态构造函数在Unity编辑器启动时执行
    [InitializeOnLoad]
    internal class CamelliaEditorStartupExecution
    {
        /// <summary>
        /// 静态构造函数，会在编辑器启动时自动调用
        /// </summary>
        static CamelliaEditorStartupExecution( )
        {
            //加载项目配置
            CamelliaEditorProjectSetting.LoadCamelliaProjectSetting( );
        }
    }
}
