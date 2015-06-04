using System;
using System.Net.Sockets;

namespace SocketClient.Domain
{
    public interface ISocketClient<T> : IDisposable
    {
        /// <summary>
        /// 連結遠端主機
        /// </summary>
        /// <returns>連線成功/連線失敗</returns>
        bool ConnectToServer();
        /// <summary>
        /// 傳送和接收要處理的物件
        /// </summary>
        /// <param name="poco">Client端送出的物件</param>
        /// <returns>遠端主機傳送的物件</returns>
        T SendAndReceive(T poco);

        void CloseConnection();
    }

    public interface ISocketClient : IDisposable
    {
        /// <summary>
        /// 連結遠端主機
        /// </summary>
        /// <returns>連線成功/連線失敗</returns>
        bool ConnectToServer();
        /// <summary>
        /// 傳送和接收要處理的物件
        /// </summary>
        /// <param name="poco">Client端送出的物件</param>
        /// <returns>遠端主機傳送的物件</returns>
        byte[] SendAndReceive(byte[] poco);

        /// <summary>
        /// 同步傳送byte array和接收byte array並out出SocketError狀態
        /// </summary>
        /// <param name="poco">傳送的data(byte array)</param>
        /// <param name="socketErr">output SocketError(socket狀態)</param>
        /// <returns>接收到的data(byte array)/失敗則回傳null</returns>
        byte[] SendAndReceive(byte[] poco,out SocketError socketErr);

        void CloseConnection();
    }
}
