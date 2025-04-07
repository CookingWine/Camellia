namespace Camellia.Runtime
{
    /// <summary>
    /// sdk接口
    /// </summary>
    internal interface ICamelliaCommunicationHelps
    {
        /// <summary>
        /// 初始化
        /// </summary>
        void OnInit( );

        /// <summary>
        /// 登录
        /// </summary>
        void OnLogin( );

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="imageData">图片数据</param>
        void OnSaveImage(string path , byte[] imageData);

        /// <summary>
        /// 加载图片
        /// </summary>
        void OnLoadImage( );

        /// <summary>
        /// 复制内容到粘贴板
        /// </summary>
        /// <param name="content">复制内容</param>
        void OnCopyToClipboard(string content);
    }
}
