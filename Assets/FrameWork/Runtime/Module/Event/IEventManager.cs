using System;
using Framework.Core;

namespace Framework.Module.Event
{
    /// <summary>
    /// 事件管理接口
    /// </summary>
    public interface IEventManager : IModule
    {
        /// <summary>
        /// 订阅事件
        /// </summary>
        /// <param name="eventType">事件类型</param>
        /// <param name="callback">回调函数</param>
        void On(string eventType, Action<object> callback);

        /// <summary>
        /// 取消订阅事件
        /// </summary>
        /// <param name="eventType">事件类型</param>
        /// <param name="callback">回调函数</param>
        void Off(string eventType, Action<object> callback);

        /// <summary>
        /// 发送事件
        /// </summary>
        /// <param name="eventType">事件类型</param>
        /// <param name="data">事件数据</param>
        void Emit(string eventType, object data = null);

        /// <summary>
        /// 订阅一次事件
        /// </summary>
        /// <param name="eventType">事件类型</param>
        /// <param name="callback">回调函数</param>
        void Once(string eventType, Action<object> callback);

        /// <summary>
        /// 移除所有指定类型的事件监听
        /// </summary>
        /// <param name="eventType">事件类型</param>
        void RemoveAll(string eventType);

        /// <summary>
        /// 清空所有事件监听
        /// </summary>
        void Clear();
    }
}
