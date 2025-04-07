using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Camellia.Editor
{
    /// <summary>
    /// 编辑器窗口配置
    /// </summary>
    internal class CamelliaEditorWindows:EditorWindow
    {
        /// <summary>
        /// 默认最小宽
        /// </summary>
        const float DeflautMinWidth = 1980;

        /// <summary>
        /// 默认最小高
        /// </summary>
        const float DefalutMinHeight = 1080f;

        //编辑窗口
        static CamelliaEditorWindows s_EditorWindows = null;

        /// <summary>
        /// 缓存的窗口项
        /// </summary>
        static List<CamelliaEditorWindowsBase> s_CacheCamelliaWindow = null;

        /// <summary>
        /// 当前绘制的item
        /// </summary>
        static CamelliaEditorWindowsBase m_CurrentDrawItem = null;

        /// <summary>
        /// 左侧的滑动列表
        /// </summary>
        Vector2 m_SelectionItemScrollPosition = Vector2.zero;

        /// <summary>
        /// 右侧视图
        /// </summary>
        Vector2 m_SelectionItemViewScrollPosition = Vector2.zero;

        //加载成功的个数
        static int s_LoadSuccessCount = 0;
        //加载失败的个数
        static int s_LoadFailureCount = 0;

        /// <summary>
        /// 打开配置窗口
        /// </summary>
        internal static void OpenCamelliaWindows( )
        {
            //获取当前屏幕宽高
            float screenWidth = UnityEngine.Device.Screen.currentResolution.width;
            float screenHeight = UnityEngine.Device.Screen.currentResolution.height;

            //计算窗口的坐标，以左上角为(0,0),使其居中
            float windowX = ( screenWidth - DeflautMinWidth ) / 2;
            float windowY = ( screenHeight - DefalutMinHeight ) / 2;

            s_EditorWindows = GetWindow<CamelliaEditorWindows>(true , "游戏配置" , true);
            s_EditorWindows.position = new Rect(windowX , windowY , DeflautMinWidth , DefalutMinHeight);
            s_EditorWindows.maxSize = s_EditorWindows.minSize = new Vector2(DeflautMinWidth , DefalutMinHeight);
            //加载配置
            LoadWindowConfigs( );
        }

        /// <summary>
        /// 加载窗口配置
        /// </summary>
        static void LoadWindowConfigs( )
        {
            s_CacheCamelliaWindow = new List<CamelliaEditorWindowsBase>( );
            s_LoadSuccessCount = 0;
            s_LoadFailureCount = 0;
            List<Type> derivedClass = GetAllDerivedClasses(typeof(CamelliaEditorWindowsBase));
            foreach(var item in derivedClass)
            {
                try
                {
                    CamelliaEditorWindowsBase instance = (CamelliaEditorWindowsBase)Activator.CreateInstance(item);
                    if(instance != null)
                    {
                        s_CacheCamelliaWindow.Add(instance);
                    }
                }
                catch(Exception e)
                {
                    CamelliaLog.Error(e.Message);
                }
            }
            CamelliaLog.Log($"加载配置个数->{s_CacheCamelliaWindow.Count}");
            if(s_CacheCamelliaWindow.Count > 0)
            {
                int currentCount = s_LoadFailureCount + s_LoadSuccessCount;
                float progrees = currentCount / s_CacheCamelliaWindow.Count;
                EditorUtility.DisplayProgressBar("加载项目配置" , $"{s_CacheCamelliaWindow[currentCount].WindowsName}" , progrees);
                s_CacheCamelliaWindow[0].LoadConfigurationResources(LoadConfigurationResourcesCallback);
                EditorUtility.ClearProgressBar( );
            }
        }

        /// <summary>
        /// 加载资源完成回调
        /// </summary>
        /// <param name="compelete"></param>
        /// <param name="count"></param>
        private static void LoadConfigurationResourcesCallback(bool compelete)
        {
            if(compelete)
            {
                s_LoadSuccessCount++;
            }
            else
            {
                s_LoadFailureCount++;
            }
            int currentIndex = s_LoadFailureCount + s_LoadSuccessCount;
            if(currentIndex >= s_CacheCamelliaWindow.Count)
            {
                if(s_CacheCamelliaWindow.Count > 0)
                {
                    m_CurrentDrawItem = s_CacheCamelliaWindow[0];
                }
                s_EditorWindows.Show( );
                CamelliaLog.Log($"加载窗口成功->{s_LoadSuccessCount};加载失败->{s_LoadFailureCount}");
            }
        }

        /// <summary>
        /// 获取继承自指定基类的所有类
        /// </summary>
        /// <param name="baseType">基类类型</param>
        /// <returns>继承自基类的所有类的列表</returns>
        private static List<Type> GetAllDerivedClasses(Type baseType)
        {
            List<Type> derivedTypes = new List<Type>( );

            // 获取当前应用程序域中的所有程序集
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies( );

            // 遍历每个程序集
            foreach(Assembly assembly in assemblies)
            {
                try
                {
                    // 获取程序集中定义的所有类型
                    Type[] types = assembly.GetTypes( );

                    // 筛选出继承自指定基类的类型
                    derivedTypes.AddRange(types.Where(t => t.IsSubclassOf(baseType)));
                }
                catch(ReflectionTypeLoadException ex)
                {
                    // 处理反射类型加载异常
                    foreach(Exception loaderException in ex.LoaderExceptions)
                    {
                        CamelliaLog.EditorException($"Loader exception:{loaderException.Message}");
                    }
                }
            }

            return derivedTypes;
        }


        void OnEnable( )
        {

        }

        void OnGUI( )
        {
            GUILayout.BeginHorizontal( );
            {
                //左侧区域
                GUILayout.BeginHorizontal(GUILayout.Width(300));
                {
                    m_SelectionItemScrollPosition = GUILayout.BeginScrollView(m_SelectionItemScrollPosition , GUILayout.Width(300) , GUILayout.Height(position.height));
                    {
                        foreach(var item in s_CacheCamelliaWindow)
                        {
                            // 保存当前的 GUI 颜色
                            Color originalColor = GUI.color;
                            GUI.color = item == m_CurrentDrawItem ? GUI.color = Color.green : Color.white;
                            if(GUILayout.Button(item.WindowsName , GUILayout.Width(280) , GUILayout.Height(50f)))
                            {
                                m_CurrentDrawItem = item;
                            }
                            GUI.color = originalColor;
                        }
                    }
                    GUILayout.EndScrollView( );
                }
                GUILayout.EndHorizontal( );

                // 绘制分隔线
                DrawVerticalLine(Color.gray , 2f);

                GUILayout.BeginVertical(GUILayout.Width(1678.0f));
                {
                    if(m_CurrentDrawItem != null)
                    {
                        m_SelectionItemViewScrollPosition = GUILayout.BeginScrollView(m_SelectionItemViewScrollPosition , GUILayout.Width(1678.0f) , GUILayout.Height(position.height * 0.85f));
                        {
                            m_CurrentDrawItem.DrawWindowContent(1678.0f , position.height * 0.85f);
                        }
                        GUILayout.EndScrollView( );
                    }
                    else
                    {

                    }
                }
                GUILayout.EndVertical( );

            }
            GUILayout.EndHorizontal( );
        }
        /// <summary>
        /// 绘制线
        /// </summary>
        /// <param name="color"></param>
        /// <param name="width"></param>
        private void DrawVerticalLine(Color color , float width)
        {
            GUIStyle lineStyle = new GUIStyle( );
            lineStyle.normal.background = EditorGUIUtility.whiteTexture;
            lineStyle.stretchHeight = true;
            lineStyle.margin = new RectOffset(0 , 0 , 0 , 0); // 上下边距

            Color originalColor = GUI.color;
            GUI.color = color;
            GUILayout.Box(GUIContent.none , lineStyle , GUILayout.Width(width));
            GUI.color = originalColor;
        }
    }
}
