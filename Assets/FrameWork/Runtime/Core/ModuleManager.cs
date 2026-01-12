using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core
{
    /// <summary>
    /// 模块管理器
    /// </summary>
    public class ModuleManager
    {
        private Dictionary<System.Type, IModule> _moduleDict;
        private List<IModule> _moduleList;

        /// <summary>
        /// 初始化模块管理器
        /// </summary>
        public void Initialize()
        {
            _moduleDict = new Dictionary<System.Type, IModule>();
            _moduleList = new List<IModule>();
        }

        /// <summary>
        /// 注册模块
        /// </summary>
        /// <typeparam name="T">模块类型</typeparam>
        /// <param name="module">模块实例</param>
        public void RegisterModule<T>(T module) where T : class, IModule
        {
            if (module == null)
            {
                UnityEngine.Debug.LogError($"[ModuleManager] 尝试注册空模块: {typeof(T).Name}");
                return;
            }

            System.Type moduleType = typeof(T);
            
            // 检查模块是否已注册
            if (_moduleDict.ContainsKey(moduleType))
            {
                UnityEngine.Debug.LogWarning($"[ModuleManager] 模块已存在，将被替换: {module.ModuleName}");
                _moduleList.Remove(_moduleDict[moduleType]);
            }

            // 注册模块
            _moduleDict[moduleType] = module;
            _moduleList.Add(module);

            // 初始化模块
            module.Initialize();
            
            UnityEngine.Debug.Log($"[ModuleManager] 模块注册成功: {module.ModuleName}");
        }

        /// <summary>
        /// 获取模块
        /// </summary>
        /// <typeparam name="T">模块类型</typeparam>
        /// <returns>模块实例</returns>
        public T GetModule<T>() where T : class, IModule
        {
            System.Type moduleType = typeof(T);
            
            if (_moduleDict == null || !_moduleDict.ContainsKey(moduleType))
            {
                UnityEngine.Debug.LogWarning($"[ModuleManager] 模块未注册: {moduleType.Name}");
                return null;
            }

            return _moduleDict[moduleType] as T;
        }

        /// <summary>
        /// 更新所有模块
        /// </summary>
        /// <param name="deltaTime">帧间隔时间</param>
        public void UpdateModules(float deltaTime)
        {
            if (_moduleList == null || _moduleList.Count == 0)
            {
                return;
            }

            // 遍历所有模块并调用 OnUpdate
            for (int i = 0; i < _moduleList.Count; i++)
            {
                if (_moduleList[i] != null)
                {
                    try
                    {
                        _moduleList[i].OnUpdate(deltaTime);
                    }
                    catch (System.Exception e)
                    {
                        UnityEngine.Debug.LogError($"[ModuleManager] 模块更新失败: {_moduleList[i].ModuleName}, 错误: {e.Message}");
                    }
                }
            }
        }

        /// <summary>
        /// 关闭所有模块
        /// </summary>
        public void ShutdownAll()
        {
            if (_moduleList == null || _moduleList.Count == 0)
            {
                return;
            }

            // 按相反顺序关闭模块（后注册的先关闭）
            for (int i = _moduleList.Count - 1; i >= 0; i--)
            {
                if (_moduleList[i] != null)
                {
                    try
                    {
                        _moduleList[i].Shutdown();
                        UnityEngine.Debug.Log($"[ModuleManager] 模块关闭成功: {_moduleList[i].ModuleName}");
                    }
                    catch (System.Exception e)
                    {
                        UnityEngine.Debug.LogError($"[ModuleManager] 模块关闭失败: {_moduleList[i].ModuleName}, 错误: {e.Message}");
                    }
                }
            }

            // 清空所有模块
            _moduleList.Clear();
            _moduleDict?.Clear();
            
            UnityEngine.Debug.Log("[ModuleManager] 所有模块已关闭");
        }
    }
}
