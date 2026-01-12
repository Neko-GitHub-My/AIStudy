using UnityEngine;

namespace Framework.Module.UI
{
    /// <summary>
    /// UI 面板基类
    /// </summary>
    public abstract class UIPanel : MonoBehaviour
    {
        /// <summary>
        /// 面板名称
        /// </summary>
        public string PanelName { get; protected set; }

        /// <summary>
        /// 是否已打开
        /// </summary>
        public bool IsOpen { get; protected set; }

        /// <summary>
        /// 初始化面板
        /// </summary>
        /// <param name="data">初始化数据</param>
        public virtual void Initialize(object data = null)
        {
            // TODO: 实现初始化逻辑
        }

        /// <summary>
        /// 打开面板
        /// </summary>
        /// <param name="data">打开数据</param>
        public virtual void OnOpen(object data = null)
        {
            // TODO: 实现打开逻辑
        }

        /// <summary>
        /// 关闭面板
        /// </summary>
        public virtual void OnClose()
        {
            // TODO: 实现关闭逻辑
        }

        /// <summary>
        /// Unity Update 方法
        /// </summary>
        private void Update()
        {
            if (IsOpen)
            {
                OnUpdate(Time.deltaTime);
            }
        }

        /// <summary>
        /// 更新面板
        /// </summary>
        /// <param name="deltaTime">帧间隔时间</param>
        public virtual void OnUpdate(float deltaTime)
        {
            // TODO: 实现更新逻辑
        }
    }
}
