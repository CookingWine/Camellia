namespace Camellia.Editor
{
    /// <summary>
    /// 配置
    /// </summary>
    internal class CamelliaEditorConstConfigs
    {
        /// <summary>
        /// 测试服
        /// </summary>
        internal const string CAMELLIA_TEST = "CAMELLIA_TEST";

        #region 非热更路径

        /// <summary>
        /// 非热更本地化语言配置路径
        /// </summary>
        internal const string RuntimeLocalizedLanguagePath = "Resources/Localization/";

        #endregion

        #region 热更路径

        /// <summary>
        /// 热更内本地化语言配置路径
        /// </summary>
        internal const string LogicLocalizedLanguagePath = "HotfixAssets/Localization/";

        #endregion
    }
}
