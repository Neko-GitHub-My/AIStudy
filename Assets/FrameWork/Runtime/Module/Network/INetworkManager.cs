using System;
using System.Threading.Tasks;

using Framework.Core;

namespace Framework.Module.Network
{
    /// <summary>
    /// 网络管理接口
    /// </summary>
    public interface INetworkManager : IModule
    {
        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <param name="url">服务器地址</param>
        /// <param name="port">端口号</param>
        /// <returns>连接任务</returns>
        Task Connect(string url, int port);

        /// <summary>
        /// 断开连接
        /// </summary>
        void Disconnect();

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message">消息数据</param>
        void Send(byte[] message);

        /// <summary>
        /// 是否已连接
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// 消息接收事件
        /// </summary>
        event Action<byte[]> OnMessageReceived;

        /// <summary>
        /// 连接断开事件
        /// </summary>
        event Action OnDisconnected;
    }
}
