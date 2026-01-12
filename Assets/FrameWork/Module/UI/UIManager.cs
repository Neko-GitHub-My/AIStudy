using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Framework.Module.UI
{
    /// <summary>
    /// UI 管理器
    /// </summary>
    public class UIManager : MonoBehaviour, IUIManager
    {
        private Dictionary<string, UIPanel> _panelDict;

        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName => "UIManager";

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
        /// 打开面板
        /// </summary>
        /// <typeparam name="T">面板类型</typeparam>
        /// <param name="panelName">面板名称</param>
        /// <param name="data">传递数据</param>
        /// <returns>面板实例</returns>
        public async Task<T> OpenPanel<T>(string panelName, object data = null) where T : UIPanel
        {
            // TODO: 实现打开面板逻辑
            return null;
        }

        /// <summary>
        /// 关闭面板
        /// </summary>
        /// <param name="panelName">面板名称</param>
        public void ClosePanel(string panelName)
        {
            // TODO: 实现关闭面板逻辑
        }

        /// <summary>
        /// 获取面板
        /// </summary>
        /// <typeparam name="T">面板类型</typeparam>
        /// <param name="panelName">面板名称</param>
        /// <returns>面板实例</returns>
        public T GetPanel<T>(string panelName) where T : UIPanel
        {
            // TODO: 实现获取面板逻辑
            return null;
        }

        /// <summary>
        /// 显示/隐藏加载界面
        /// </summary>
        /// <param name="show">是否显示</param>
        public void ShowLoading(bool show)
        {
            // TODO: 实现显示加载界面逻辑
        }
    }
}
