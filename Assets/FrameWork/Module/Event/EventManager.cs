using System;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Module.Event
{
    /// <summary>
    /// 事件管理器
    /// </summary>
    public class EventManager : MonoBehaviour, IEventManager
    {
        private Dictionary<string, List<Action<object>>> _eventHandlers;

        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName => "EventManager";

        /// <summary>
        /// 初始化模块
        /// </summary>
        public void Initialize()
        {
            // TODO: 实现初始化逻辑
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
        /// 订阅事件
        /// </summary>
        /// <param name="eventType">事件类型</param>
        /// <param name="callback">回调函数</param>
        public void On(string eventType, Action<object> callback)
        {
            // TODO: 实现订阅逻辑
        }

        /// <summary>
        /// 取消订阅事件
        /// </summary>
        /// <param name="eventType">事件类型</param>
        /// <param name="callback">回调函数</param>
        public void Off(string eventType, Action<object> callback)
        {
            // TODO: 实现取消订阅逻辑
        }

        /// <summary>
        /// 发送事件
        /// </summary>
        /// <param name="eventType">事件类型</param>
        /// <param name="data">事件数据</param>
        public void Emit(string eventType, object data = null)
        {
            // TODO: 实现发送逻辑
        }

        /// <summary>
        /// 订阅一次事件
        /// </summary>
        /// <param name="eventType">事件类型</param>
        /// <param name="callback">回调函数</param>
        public void Once(string eventType, Action<object> callback)
        {
            // TODO: 实现订阅一次逻辑
        }

        /// <summary>
        /// 移除所有指定类型的事件监听
        /// </summary>
        /// <param name="eventType">事件类型</param>
        public void RemoveAll(string eventType)
        {
            // TODO: 实现移除逻辑
        }

        /// <summary>
        /// 清空所有事件监听
        /// </summary>
        public void Clear()
        {
            // TODO: 实现清空逻辑
        }
    }
}
