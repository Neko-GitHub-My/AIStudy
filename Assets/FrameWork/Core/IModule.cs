namespace Framework.Core
{
    /// <summary>
    /// 模块接口
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// 模块名称
        /// </summary>
        string ModuleName { get; }

        /// <summary>
        /// 初始化模块
        /// </summary>
        void Initialize();

        /// <summary>
        /// 更新模块
        /// </summary>
        /// <param name="deltaTime">帧间隔时间</param>
        void OnUpdate(float deltaTime);

        /// <summary>
        /// 关闭模块
        /// </summary>
        void Shutdown();
    }
}
