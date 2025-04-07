using GameFramework;
using GameFramework.Localization;
using System;
using UnityGameFramework.Runtime;

namespace Camellia.Runtime
{
    public class RuntimeLocalization:DefaultLocalizationHelper
    {
        /// <summary>
        /// 解析字典。
        /// </summary>
        /// <param name="dictionaryString">要解析的字典字符串。</param>
        /// <param name="userData">用户自定义数据。</param>
        /// <returns>是否解析字典成功。</returns>
        public override bool ParseData(ILocalizationManager localizationManager , string dictionaryString , object userData)
        {
            try
            {
                CamelliaGameDataStruct.LocalizedLanguage language = Utility.Json.ToObject<CamelliaGameDataStruct.LocalizedLanguage>(dictionaryString);
                if(language == null)
                {
                    return false;
                }
                for(int i = 0; i < language.LanguageData.Count; i++)
                {
                    if(!localizationManager.AddRawString(language.LanguageData[i].Key , language.LanguageData[i].Value))
                    {
                        Log.Warning("Can not add raw string with key '{0}' which may be invalid or duplicate." , language.LanguageData[i].Key);
                        return false;
                    }
                }
                return true;
            }
            catch(Exception exception)
            {
                Log.Error("Can not parse dictionary data with exception '{0}'." , exception.Message);
                return false;
            }
        }
    }
}
