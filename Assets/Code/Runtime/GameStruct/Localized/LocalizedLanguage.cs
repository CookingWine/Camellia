using GameFramework.Localization;
using System.Collections.Generic;
using UnityEngine;
namespace Camellia.Runtime
{
    public partial class CamelliaGameDataStruct
    {
        /// <summary>
        /// 本地语言配置
        /// </summary>
        [SerializeField]
        public class LocalizedLanguage
        {
            /// <summary>
            /// 当前语言
            /// </summary>
            public Language CurrentLanguage { get; set; }

            /// <summary>
            /// 语言项
            /// </summary>
            public List<LocalizedLanguageItem> LanguageData { get; set; }
        }
        /// <summary>
        /// 本地语言item数据
        /// </summary>
        public class LocalizedLanguageItem
        {
            /// <summary>
            /// 语言Key
            /// </summary>
            public string Key { get; set; }

            /// <summary>
            /// 语言value
            /// </summary>
            public string Value { get; set; }
        }

    }

}
