using UnityEngine;

namespace Camellia.Logic
{
    /// <summary>
    /// 热更配置
    /// </summary>
    [CreateAssetMenu(fileName = "CamelliaAppHotfixConfigData" , menuName = "序列化数据/热更配置")]
    public class CamelliaAppHotfixConfigData:ScriptableObject
    {
        [SerializeField]
        private string[] m_AotFileList;

        /// <summary>
        /// aot文件列表
        /// </summary>
        public string[] AotFileList
        {
            get
            {
                return m_AotFileList;
            }
        }

        [SerializeField]
        private string[] m_DataTables;

        /// <summary>
        /// 预加载数据表
        /// </summary>
        public string[] DataTables
        {
            get
            {
                return m_DataTables;
            }
        }

        [SerializeField]
        private string[] m_HotfixProcedures;

        /// <summary>
        /// 热更流程
        /// </summary>
        public string[] HotfixProcedures
        {
            get
            {
                return m_HotfixProcedures;
            }
        }

        [SerializeField]
        private string[] m_GameFontFile;

        /// <summary>
        /// 游戏字体文件
        /// </summary>
        public string[] GameFontFile
        {
            get
            {
                return m_GameFontFile;
            }
        }

        [SerializeField]
        private string[] m_MustResourceGroup;

        /// <summary>
        /// 热更资源组
        /// </summary>
        public string[] MustResourceGroup
        {
            get
            {
                return m_MustResourceGroup;
            }
        }
    }
}
