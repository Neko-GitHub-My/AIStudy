namespace Framework.Config
{
    /// <summary>
    /// 游戏配置
    /// </summary>
    public class GameConfig
    {
        /// <summary>
        /// 游戏版本
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 是否开启调试模式
        /// </summary>
        public bool DebugMode { get; set; }

        /// <summary>
        /// 帧率限制
        /// </summary>
        public int TargetFrameRate { get; set; }
    }
}
