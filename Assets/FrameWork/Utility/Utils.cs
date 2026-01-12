namespace Framework.Utility
{
    /// <summary>
    /// 通用工具类
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// 检查字符串是否为空
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>是否为空</returns>
        public static bool IsNullOrEmpty(string str)
        {
            // TODO: 实现检查逻辑
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// 格式化字符串
        /// </summary>
        /// <param name="format">格式</param>
        /// <param name="args">参数</param>
        /// <returns>格式化后的字符串</returns>
        public static string Format(string format, params object[] args)
        {
            // TODO: 实现格式化逻辑
            return string.Format(format, args);
        }
    }
}
