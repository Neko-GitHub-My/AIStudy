using System.Threading.Tasks;
using UnityEngine;
using Framework.Core;
using Game.Runtime;

namespace Boot.Runtime
{
    /// <summary>
    /// Boot 组件（挂载到 Startup 场景的 Boot 节点）
    /// </summary>
    public class Boot : MonoBehaviour
    {
        private ModuleManager _moduleManager;
        private GameApp _gameApp;

        private async void Awake()
        {
            // 将 Boot 节点设置为永不删除（跨场景保留）
            DontDestroyOnLoad(gameObject);

            // 按顺序执行初始化流程
            await InitializeHotUpdate();      // 接口1：热更新检查
            InitializeFramework();              // 接口2：初始化框架
            InitializeGameApp();               // 接口3：初始化游戏应用
        }

        private void Update()
        {
            // 更新所有模块
            if (_moduleManager != null)
            {
                _moduleManager.UpdateModules(Time.deltaTime);
            }
        }

        /// <summary>
        /// 接口1：热更新相关接口（检查版本与资源更新）
        /// </summary>
        /// <returns>更新任务</returns>
        private async Task InitializeHotUpdate()
        {
            // TODO: 实现热更新检查逻辑
            // 1. 检查版本
            // 2. 检查资源更新
            // 3. 下载更新资源
            
            UnityEngine.Debug.Log("[Boot] 热更新检查完成");
            await Task.CompletedTask;
        }

        /// <summary>
        /// 接口2：初始化 Framework 下的游戏框架与模块
        /// </summary>
        private void InitializeFramework()
        {
            // 初始化模块管理器
            _moduleManager = new ModuleManager();
            _moduleManager.Initialize();

            UnityEngine.Debug.Log("[Boot] 框架初始化完成");
        }

        /// <summary>
        /// 接口3：初始化游戏的 GameApp
        /// </summary>
        private void InitializeGameApp()
        {
            // 添加 GameApp 组件到 Boot 节点下
            _gameApp = gameObject.GetComponent<GameApp>();
            if (_gameApp == null)
            {
                _gameApp = gameObject.AddComponent<GameApp>();
            }

            // 调用 GameApp 的初始化接口
            _gameApp.Initialize();

            // 将 GameApp 注册到模块管理器
            if (_moduleManager != null)
            {
                _moduleManager.RegisterModule(_gameApp);
            }
            else
            {
                UnityEngine.Debug.LogError("[Boot] ModuleManager 未初始化，无法注册 GameApp");
            }

            UnityEngine.Debug.Log("[Boot] GameApp 初始化完成");
        }

        /// <summary>
        /// 获取模块
        /// </summary>
        /// <typeparam name="T">模块类型</typeparam>
        /// <returns>模块实例</returns>
        public T GetModule<T>() where T : class, IModule
        {
            if (_moduleManager == null)
            {
                return null;
            }
            return _moduleManager.GetModule<T>();
        }

        /// <summary>
        /// 注册模块
        /// </summary>
        /// <typeparam name="T">模块类型</typeparam>
        /// <param name="module">模块实例</param>
        public void RegisterModule<T>(T module) where T : class, IModule
        {
            if (_moduleManager == null)
            {
                _moduleManager = new ModuleManager();
                _moduleManager.Initialize();
            }
            _moduleManager.RegisterModule(module);
        }

        private void OnDestroy()
        {
            // 关闭所有模块
            if (_moduleManager != null)
            {
                _moduleManager.ShutdownAll();
            }
        }
    }
}
