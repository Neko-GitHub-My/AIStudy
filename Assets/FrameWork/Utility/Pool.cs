using System.Collections.Generic;
using UnityEngine;

namespace Framework.Utility
{
    /// <summary>
    /// 对象池
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    public class Pool<T> where T : class, new()
    {
        private Queue<T> _pool;
        private int _maxSize;

        /// <summary>
        /// 从池中获取对象
        /// </summary>
        /// <returns>对象</returns>
        public T Get()
        {
            // TODO: 实现获取对象逻辑
            return null;
        }

        /// <summary>
        /// 将对象归还到池中
        /// </summary>
        /// <param name="obj">对象</param>
        public void Return(T obj)
        {
            // TODO: 实现归还对象逻辑
        }

        /// <summary>
        /// 清空对象池
        /// </summary>
        public void Clear()
        {
            // TODO: 实现清空逻辑
        }
    }
}
