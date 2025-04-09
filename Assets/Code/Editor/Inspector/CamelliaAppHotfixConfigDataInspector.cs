using Camellia.Logic;
using UnityEditor;

namespace Camellia.CamelliaEditor
{
    /// <summary>
    /// 热更配置的inspector界面重绘
    /// </summary>

    [CustomEditor(typeof(CamelliaAppHotfixConfigData))]
    internal class CamelliaAppHotfixConfigDataInspector:UnityEditor.Editor
    {

        public override void OnInspectorGUI( )
        {
            base.OnInspectorGUI( );
        }
    }
}
