using UnityEngine;

namespace Framework.Config
{
    /// <summary>
    /// 配置管理器
    /// </summary>
    public class ConfigManager : MonoBehaviour, IConfigManager
    {
        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName => "ConfigManager";

        /// <summary>
        /// 初始化模块
        /// </summary>
        public void Initialize()
        {
            // TODO: 实现初始化逻辑
        }

        /// <summary>
        /// Unity Update 方法
        /// </summary>
        private void Update()
        {
            OnUpdate(Time.deltaTime);
        }

        /// <summary>
        /// 更新模块
        /// </summary>
        /// <param name="deltaTime">帧间隔时间</param>
        public void OnUpdate(float deltaTime)
        {
            // TODO: 实现更新逻辑
        }

        /// <summary>
        /// 关闭模块
        /// </summary>
        public void Shutdown()
        {
            // TODO: 实现关闭逻辑
        }

        /// <summary>
        /// 加载配置
        /// </summary>
        /// <typeparam name="T">配置类型</typeparam>
        /// <param name="configName">配置名称</param>
        /// <returns>配置对象</returns>
        public T LoadConfig<T>(string configName) where T : class
        {
            // TODO: 实现加载配置逻辑
            return null;
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        /// <typeparam name="T">配置类型</typeparam>
        /// <param name="configName">配置名称</param>
        /// <param name="config">配置对象</param>
        public void SaveConfig<T>(string configName, T config) where T : class
        {
            // TODO: 实现保存配置逻辑
        }
    }
}
