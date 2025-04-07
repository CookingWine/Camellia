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
        public enum Platform
        {
            Editor = 0x01,
            Android = 0x11,
            IOS = 0x21,
        }

        /// <summary>
        /// 用户语言
        /// </summary>
        public const string USER_LANGUAGE = "USER_LANGUAGE";

        /// <summary>
        /// 获取当前平台
        /// </summary>
        public static Platform GetPlatform
        {
            get
            {
#if UNITY_EDITOR
                return Platform.Android;
#elif UNITY_ANDROID
                return Platform.Android;
#elif UNITY_IOS
                return Platform.IOS;
#endif
            }
        }

    }
}
