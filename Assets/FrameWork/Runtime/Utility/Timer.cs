using System;
using System.Collections.Generic;
using UnityEngine;

namespace Framework.Utility
{
    /// <summary>
    /// 定时器
    /// </summary>
    public class Timer
    {
        private float _duration;
        private float _elapsedTime;
        private Action _onComplete;
        private bool _isRunning;

        /// <summary>
        /// 是否运行中
        /// </summary>
        public bool IsRunning => _isRunning;

        /// <summary>
        /// 更新定时器
        /// </summary>
        /// <param name="deltaTime">帧间隔时间</param>
        public void Update(float deltaTime)
        {
            // TODO: 实现更新逻辑
        }

        /// <summary>
        /// 启动定时器
        /// </summary>
        /// <param name="duration">持续时间</param>
        /// <param name="onComplete">完成回调</param>
        public void Start(float duration, Action onComplete)
        {
            // TODO: 实现启动逻辑
        }

        /// <summary>
        /// 停止定时器
        /// </summary>
        public void Stop()
        {
            // TODO: 实现停止逻辑
        }

        /// <summary>
        /// 重置定时器
        /// </summary>
        public void Reset()
        {
            // TODO: 实现重置逻辑
        }
    }
}
