using UnityEngine;

namespace Framework.Utility
{
    /// <summary>
    /// 日志工具
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// 日志级别
        /// </summary>
        public enum LogLevel
        {
            Debug,
            Info,
            Warning,
            Error
        }

        private static LogLevel _logLevel = LogLevel.Debug;

        /// <summary>
        /// 设置日志级别
        /// </summary>
        /// <param name="level">日志级别</param>
        public static void SetLogLevel(LogLevel level)
        {
            _logLevel = level;
        }

        /// <summary>
        /// 输出调试日志
        /// </summary>
        /// <param name="message">消息</param>
        public static void Debug(string message)
        {
            // TODO: 实现调试日志逻辑
        }

        /// <summary>
        /// 输出信息日志
        /// </summary>
        /// <param name="message">消息</param>
        public static void Info(string message)
        {
            // TODO: 实现信息日志逻辑
        }

        /// <summary>
        /// 输出警告日志
        /// </summary>
        /// <param name="message">消息</param>
        public static void Warning(string message)
        {
            // TODO: 实现警告日志逻辑
        }

        /// <summary>
        /// 输出错误日志
        /// </summary>
        /// <param name="message">消息</param>
        public static void Error(string message)
        {
            // TODO: 实现错误日志逻辑
        }
    }
}
