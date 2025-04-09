using System;
using UnityEngine;

namespace Camellia.CamelliaEditor
{
    /// <summary>
    /// 窗口配置基类
    /// </summary>
    internal abstract class CamelliaEditorWindowsBase
    {
        /// <summary>
        /// 窗口名称
        /// </summary>
        internal abstract string WindowsName { get; }

        /// <summary>
        /// 是否添加到配置窗口内
        /// </summary>
        internal abstract bool AddWindowsConfigs { get; }

        /// <summary>
        /// 窗口内的滑动列表
        /// </summary>
        protected Vector2 ScrollPosition;

        /// <summary>
        /// 加载配置资源
        /// </summary>
        /// <param name="compelete">配置资源完成事件</param>
        internal abstract void LoadConfigurationResources(Action<bool> compelete);

        /// <summary>
        /// 绘制窗口内容
        /// </summary>
        /// <param name="width">窗口的宽</param>
        /// <param name="height">窗口的高</param>
        internal abstract void DrawWindowContent(float width , float height);
    }
}
