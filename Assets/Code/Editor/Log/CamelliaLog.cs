using GameFramework;
using UnityEngine;

namespace Camellia.CamelliaEditor
{
    /// <summary>
    /// 编辑器log
    /// </summary>
    internal static class CamelliaLog
    {
        /// <summary>
        /// 编辑器log
        /// </summary>
        /// <param name="message"></param>
        internal static void Log(object message)
        {
            Debug.Log(Utility.Text.Format("<color=#00F5FF><Camellia Editor>--{0}</color>" , message.ToString( )));
        }
        /// <summary>
        /// 编辑器警告
        /// </summary>
        /// <param name="message"></param>
        internal static void Warning(object message)
        {
            Debug.LogWarning(Utility.Text.Format("<Camellia Editor>--{0}" , message.ToString( )));
        }
        /// <summary>
        /// 编辑器错误
        /// </summary>
        /// <param name="message"></param>
        internal static void Error(object message)
        {
            Debug.LogError(Utility.Text.Format("<Camellia Editor>--{0}" , message.ToString( )));
        }

        /// <summary>
        /// 编辑器异常
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        internal static string EditorException(string message)
        {
            return Utility.Text.Format("<Camellia Editor>--{0}" , message);
        }
    }
}
