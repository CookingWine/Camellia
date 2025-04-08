namespace Camellia.Runtime
{
    /// <summary>
    /// 全局变量
    /// </summary>
    public static class GlobalVariable
    {
        /// <summary>
        /// 平台
        /// </summary>
        public enum Platform:byte
        {
            /// <summary>
            /// 编辑器
            /// </summary>
            Editor = 0x01,
            /// <summary>
            /// window平台
            /// </summary>
            Windows = 0x02,
            /// <summary>
            /// 安卓平台
            /// </summary>
            Android = 0x11,
            /// <summary>
            /// ios平台
            /// </summary>
            IOS = 0x21,
        }

        /// <summary>
        /// 获取当前平台
        /// </summary>
        public static Platform GetPlatform
        {
            get
            {
#if UNITY_EDITOR
                return Platform.Editor;
#elif UNITY_EDITOR_WIN
                return Platform.Windows;
#elif UNITY_ANDROID
                return Platform.Android;
#elif UNITY_IOS
                return Platform.IOS;
#endif
            }
        }

        /// <summary>
        /// app热更序列化文件
        /// </summary>
        public const string AppHotfixAssets = "CamelliaAppHotfixConfigData";

        /// <summary>
        /// app热更程序集
        /// </summary>
        public const string AppHotfixAssembliy = "Camellia.Logic";

        /// <summary>
        /// app热更入口类
        /// </summary>
        public const string AppHotfixEntryClass = "Camellia.Logic.CamelliaHotfixEntry";

        /// <summary>
        /// app热更start方法
        /// </summary>
        public const string AppHotfixStartFuntion = "Start";
        /// <summary>
        /// app热更Update方法
        /// </summary>
        public const string AppHotfixUpdateFuntion = "Update";
        /// <summary>
        /// app热更Shutdown方法
        /// </summary>
        public const string AppHotfixShutdownFuntion = "Shutdown";

        /// <summary>
        /// 用户语言
        /// </summary>
        public const string USER_LANGUAGE = "USER_LANGUAGE";



    }
}
