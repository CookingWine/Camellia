using HybridCLR;
using System;
using System.Collections;
using UnityEngine;
using UnityGameFramework.Runtime;
namespace Camellia.Runtime
{
    public class HybridclrComponent:GameFrameworkComponent
    {
        /// <summary>
        /// 加载dll成功事件
        /// </summary>
        private Action m_SuccessComplate = null;

        private Action<float , float> m_UpdateCallback = null;

        private Action m_ShutdownCallback = null;


        /// <summary>
        /// Hybridclr元数据模式
        /// <para>Consistent模式:即补充的dll与打包时裁剪后的dll精确一致。因此必须使用build过程中生成的裁剪后的dll，则不能直接复制原始dll</para>
        /// <para>SuperSet模式:即补充的dll是打包时裁剪后的dll的超集。这个模式放松对了AOT dll的要求，你既可以用裁剪后的AOT dll，也可以用原始AOT dll</para>
        /// </summary>
        [Header("元数据模式【默认使用SuperSet模式】")]
        [SerializeField]
        private HomologousImageMode m_HomologousImageMode = HomologousImageMode.SuperSet;

        /// <summary>
        /// 进入热更入口
        /// </summary>
        /// <param name="complate"></param>
#if UNITY_EDITOR
        internal void HotfixEntry(Action complate)
#else

#endif
        {
            m_SuccessComplate = complate;

            StartCoroutine(LoadHotfixEntry( ));
        }

        /// <summary>
        /// 加载程序集
        /// </summary>
        /// <param name="dllBytes">dll二进制文件</param>
        /// <returns>是否加载成功</returns>
        public bool LoadMetadataForAOTAssembly(byte[] dllBytes)
        {
            return LoadMetadataForAOT(dllBytes) == LoadImageErrorCode.OK;
        }

        protected override void Awake( )
        {
            base.Awake( );
        }
        private void Start( )
        {

        }

        private void Update( )
        {
            if(m_UpdateCallback == null)
            {
                return;
            }
            m_UpdateCallback(Time.deltaTime , Time.unscaledDeltaTime);
        }

        private void FixedUpdate( )
        {

        }

        private void OnApplicationPause(bool pause)
        {

        }

        private void OnApplicationFocus(bool focus)
        {

        }

        private void OnDestroy( )
        {
            if(m_ShutdownCallback == null)
            {
                return;
            }
            m_ShutdownCallback( );
        }

        /// <summary>
        /// 为aot assembly加载原始metadata， 
        /// 这个代码放aot或者热更新都行。一旦加载后，如果AOT泛型函数对应native实现不存在，则自动替换为解释模式执行
        /// </summary>
        /// <param name="dllBytes">dll二进制文件</param>
        /// <returns></returns>
        private LoadImageErrorCode LoadMetadataForAOT(byte[] dllBytes)
        {
            return RuntimeApi.LoadMetadataForAOTAssembly(dllBytes , m_HomologousImageMode);
        }

        /// <summary>
        /// 加载热更
        /// </summary>
        /// <returns></returns>
        private IEnumerator LoadHotfixEntry( )
        {
            yield return new WaitForEndOfFrame( );

        }

    }
}
