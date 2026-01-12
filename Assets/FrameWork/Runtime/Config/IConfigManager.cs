using Framework.Core;

namespace Framework.Config
{
    /// <summary>
    /// 配置管理接口
    /// </summary>
    public interface IConfigManager : IModule
    {
        /// <summary>
        /// 加载配置
        /// </summary>
        /// <typeparam name="T">配置类型</typeparam>
        /// <param name="configName">配置名称</param>
        /// <returns>配置对象</returns>
        T LoadConfig<T>(string configName) where T : class;

        /// <summary>
        /// 保存配置
        /// </summary>
        /// <typeparam name="T">配置类型</typeparam>
        /// <param name="configName">配置名称</param>
        /// <param name="config">配置对象</param>
        void SaveConfig<T>(string configName, T config) where T : class;
    }
}
