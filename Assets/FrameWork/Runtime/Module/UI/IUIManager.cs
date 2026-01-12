using System.Threading.Tasks;
using Framework.Core;

namespace Framework.Module.UI
{
    /// <summary>
    /// UI 管理接口
    /// </summary>
    public interface IUIManager : IModule
    {
        /// <summary>
        /// 打开面板
        /// </summary>
        /// <typeparam name="T">面板类型</typeparam>
        /// <param name="panelName">面板名称</param>
        /// <param name="data">传递数据</param>
        /// <returns>面板实例</returns>
        Task<T> OpenPanel<T>(string panelName, object data = null) where T : UIPanel;

        /// <summary>
        /// 关闭面板
        /// </summary>
        /// <param name="panelName">面板名称</param>
        void ClosePanel(string panelName);

        /// <summary>
        /// 获取面板
        /// </summary>
        /// <typeparam name="T">面板类型</typeparam>
        /// <param name="panelName">面板名称</param>
        /// <returns>面板实例</returns>
        T GetPanel<T>(string panelName) where T : UIPanel;

        /// <summary>
        /// 显示/隐藏加载界面
        /// </summary>
        /// <param name="show">是否显示</param>
        void ShowLoading(bool show);
    }
}
