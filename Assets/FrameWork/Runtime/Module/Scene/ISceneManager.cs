using System.Threading.Tasks;

using Framework.Core;

namespace Framework.Module.Scene
{
    /// <summary>
    /// 场景管理接口
    /// </summary>
    public interface ISceneManager : IModule
    {
        /// <summary>
        /// 加载场景
        /// </summary>
        /// <param name="sceneName">场景名称</param>
        /// <param name="additive">是否叠加加载</param>
        /// <returns>加载任务</returns>
        Task LoadScene(string sceneName, bool additive = false);

        /// <summary>
        /// 卸载场景
        /// </summary>
        /// <param name="sceneName">场景名称</param>
        /// <returns>卸载任务</returns>
        Task UnloadScene(string sceneName);

        /// <summary>
        /// 获取当前场景名称
        /// </summary>
        /// <returns>场景名称</returns>
        string GetCurrentSceneName();

        /// <summary>
        /// 检查场景是否已加载
        /// </summary>
        /// <param name="sceneName">场景名称</param>
        /// <returns>是否已加载</returns>
        bool IsSceneLoaded(string sceneName);
    }
}
