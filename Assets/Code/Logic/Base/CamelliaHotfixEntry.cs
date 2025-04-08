using UnityGameFramework.Runtime;

namespace Camellia.Logic
{
    /// <summary>
    /// 游戏热更入口
    /// </summary>
    public class CamelliaHotfixEntry
    {
        /// <summary>
        /// 不可调用,供给HybridclrComponent使用【相当于Mono.Start】
        /// </summary>
        public static void Start( )
        {
            Log.Info("热更启动");
        }

        /// <summary>
        /// 不可调用,供给HybridclrComponent使用【相当于Mono.Update】
        /// </summary>
        /// <param name="elapseSeconds">逻辑流逝时间，以秒为单位。</param>
        /// <param name="realElapseSeconds">真实流逝时间，以秒为单位。</param>
        public static void Update(float elapseSeconds , float realElapseSeconds)
        {

        }
        /// <summary>
        /// 不可调用,供给HybridclrComponent使用
        /// </summary>
        public static void Shutdown( )
        {
            Log.Info("清除数据");
        }
    }
}
