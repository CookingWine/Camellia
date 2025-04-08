using GameFramework;
using UnityEngine;

namespace Camellia.Runtime
{
    /// <summary>
    /// 日志
    /// </summary>
    internal class RuntimeLog:GameFrameworkLog.ILogHelper
    {
        public void Log(GameFrameworkLogLevel level , object message)
        {
            switch(level)
            {
                case GameFrameworkLogLevel.Debug:
                    Debug.Log(Utility.Text.Format("<color=#00F5FF><CamelliaApp>--[{0}]--{1}</color>" , Time.time , message.ToString( )));
                    break;
                case GameFrameworkLogLevel.Info:
                    Debug.Log(Utility.Text.Format("<color=#FFDAB9><CamelliaApp>--[{0}]--{1}</color>" , Time.time , message.ToString( )));
                    break;
                case GameFrameworkLogLevel.Warning:
                    Debug.LogWarning(Utility.Text.Format("<color=#FFD700><CamelliaApp>--[{0}]--{1}</color>" , Time.time , message.ToString( )));
                    break;
                case GameFrameworkLogLevel.Error:
                    Debug.LogError(Utility.Text.Format("<color=#CD5555><CamelliaApp>--[{0}]--{1}</color>" , Time.time , message.ToString( )));
                    break;
                default:
                    throw new GameFrameworkException(message.ToString( ));
            }
        }
    }
}
