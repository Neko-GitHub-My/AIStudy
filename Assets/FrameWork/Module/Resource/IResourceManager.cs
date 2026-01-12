using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Framework.Module.Resource
{
    /// <summary>
    /// 资源管理接口
    /// </summary>
    public interface IResourceManager : Core.IModule
    {
        /// <summary>
        /// 异步加载资源
        /// </summary>
        /// <typeparam name="T">资源类型</typeparam>
        /// <param name="path">资源路径</param>
        /// <returns>资源对象</returns>
        Task<T> LoadAsset<T>(string path) where T : Object;

        /// <summary>
        /// 同步加载资源
        /// </summary>
        /// <typeparam name="T">资源类型</typeparam>
        /// <param name="path">资源路径</param>
        /// <returns>资源对象</returns>
        T LoadAssetSync<T>(string path) where T : Object;

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="path">资源路径</param>
        void ReleaseAsset(string path);

        /// <summary>
        /// 预加载资源
        /// </summary>
        /// <param name="paths">资源路径列表</param>
        /// <returns>加载任务</returns>
        Task PreloadAssets(List<string> paths);

        /// <summary>
        /// 检查资源是否存在
        /// </summary>
        /// <param name="path">资源路径</param>
        /// <returns>是否存在</returns>
        bool HasAsset(string path);
    }
}
