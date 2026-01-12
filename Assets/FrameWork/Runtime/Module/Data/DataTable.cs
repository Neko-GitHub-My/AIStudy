using System.Collections.Generic;

namespace Framework.Module.Data
{
    /// <summary>
    /// 数据表
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    public class DataTable<T> where T : class
    {
        private Dictionary<int, T> _dataDict;
        private List<T> _dataList;

        /// <summary>
        /// 根据 ID 获取数据
        /// </summary>
        /// <param name="id">数据 ID</param>
        /// <returns>数据</returns>
        public T GetById(int id)
        {
            // TODO: 实现获取数据逻辑
            return null;
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns>数据列表</returns>
        public List<T> GetAll()
        {
            // TODO: 实现获取所有数据逻辑
            return _dataList;
        }
    }
}
