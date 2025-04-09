using UnityEditor;
namespace Camellia.CamelliaEditor
{
    /// <summary>
    /// 编辑器启动配置
    /// </summary>
    internal class CamelliaEditorStartupExecution
    {
        /// <summary>
        /// 静态构造函数，会在编辑器启动时自动调用
        /// </summary>
        static CamelliaEditorStartupExecution( )
        {

        }

        [InitializeOnLoadMethod]
        static void EditorStartupExecution( )
        {
            //加载项目配置
            CamelliaEditorProjectSetting.LoadCamelliaProjectSetting( );
        }
    }
}
