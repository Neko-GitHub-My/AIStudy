namespace Framework.Module.Data
{
    /// <summary>
    /// 数据管理接口
    /// </summary>
    public interface IDataManager : Core.IModule
    {
        /// <summary>
        /// 加载数据表
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="tableName">表名</param>
        /// <returns>数据表</returns>
        DataTable<T> LoadTable<T>(string tableName) where T : class;

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="key">键</param>
        /// <param name="data">数据</param>
        void SaveData<T>(string key, T data) where T : class;

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="key">键</param>
        /// <returns>数据</returns>
        T LoadData<T>(string key) where T : class;

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="key">键</param>
        void DeleteData(string key);
    }
}
