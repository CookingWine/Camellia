using System;
using UnityGameFramework.Runtime;
using UnityEngine;
using System.Collections.Generic;
namespace Camellia.Runtime
{
    /// <summary>
    /// 非热更的一些配置数据
    /// </summary>
    public class BuiltinComponent:GameFrameworkComponent
    {
        /// <summary>
        /// UI相机
        /// </summary>
        public Camera UICamera { get; private set; }

        /// <summary>
        /// 3d相机
        /// </summary>
        public Camera Camera2D { get; private set; }

        /// <summary>
        /// 游戏主界面非热更【当进入热更后把改ui给删除掉】
        /// </summary>
        public GameObject GameMainInterface { get; private set; }

        /// <summary>
        /// 资源组
        /// </summary>
        [SerializeField]
        private List<string> m_ReourceGroupName;

        /// <summary>
        /// 资源组
        /// </summary>
        public string[] ResoueceGroup
        {
            get
            {
                return m_ReourceGroupName.ToArray( );
            }
        }

        protected override void Awake( )
        {
            base.Awake( );
            UICamera = GameObject.Find("UICamera").GetComponent<Camera>( );
            Camera2D = GameObject.Find("2DCamera").GetComponent<Camera>( );
        }

        /// <summary>
        /// 异步加载Resource内的资源【只非热更的资源才可以使用这个】
        /// </summary>
        /// <param name="path">资源路径</param>
        /// <param name="action">加载完成后的回调</param>
        public void ResourceAsync(string path , Action<object> action)
        {
            ResourceRequest temp = Resources.LoadAsync(path);
            temp.completed += (rq) =>
            {
                action.Invoke(( rq as ResourceRequest ).asset);
            };
        }

        /// <summary>
        /// 销毁基础非热更界面
        /// </summary>
        public void DestroyMainInterface( )
        {
            if(GameMainInterface != null)
            {
                Destroy(GameMainInterface);
                GC.Collect( );
            }
        }
    }
}
