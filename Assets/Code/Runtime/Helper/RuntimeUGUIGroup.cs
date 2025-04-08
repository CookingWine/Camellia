using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace Camellia.Runtime
{
    /// <summary>
    /// UGUI界面辅助器
    /// </summary>
    public class RuntimeUGUIGroup:UIGroupHelperBase
    {
        /// <summary>
        /// 匹配宽度或高度
        /// </summary>
        public const float MatchWidthOrHeight = 0.5f;
        /// <summary>
        /// 深度系数
        /// </summary>
        public const int DepthFactor = 100;

        /// <summary>
        /// 深度
        /// </summary>
        private int m_Depth = 0;

        /// <summary>
        /// 缓存画布
        /// </summary>
        private Canvas m_CachedCanvas = null;

        /// <summary>
        /// 设置界面组深度。
        /// </summary>
        /// <param name="depth">界面组深度。</param>
        public override void SetDepth(int depth)
        {
            m_Depth = depth;
            m_CachedCanvas.overrideSorting = true;
            m_CachedCanvas.sortingOrder = DepthFactor * depth;
        }

        private void Awake( )
        {
            m_CachedCanvas = gameObject.GetOrAddComponent<Canvas>( );
            gameObject.GetOrAddComponent<GraphicRaycaster>( );
        }
        private void Start( )
        {
            InitCanvas( );
            RectTransform transform = GetComponent<RectTransform>( );
            transform.anchorMin = Vector2.zero;
            transform.anchorMax = Vector2.one;
            transform.anchoredPosition = Vector2.zero;
            transform.sizeDelta = Vector2.zero;
        }
        private void InitCanvas( )
        {
            m_CachedCanvas = gameObject.GetOrAddComponent<Canvas>( );
            m_CachedCanvas.renderMode = RenderMode.ScreenSpaceCamera;
            m_CachedCanvas.overrideSorting = true;
            m_CachedCanvas.worldCamera = CamelliaApp.BuiltinData.UICamera;
            m_CachedCanvas.sortingOrder = DepthFactor * m_Depth;
            m_CachedCanvas.vertexColorAlwaysGammaSpace = true;
            CanvasScaler csc = gameObject.GetOrAddComponent<CanvasScaler>( );
            csc.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            csc.referenceResolution = new Vector2(1920 , 1080);
            csc.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
            csc.matchWidthOrHeight = MatchWidthOrHeight;
            gameObject.GetOrAddComponent<GraphicRaycaster>( );
        }

        public void SetLayer(string nameLayer)
        {
            gameObject.layer = LayerMask.NameToLayer(nameLayer);
        }
    }
}
