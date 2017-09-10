using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionislandGameServer
{
    public class Client
    {
        public int CurrentPlayerNum { get; set; }
        public Socket PlayerSocket { get; set; }
        public int CurrentStatus { get; set; }       
        public Client(int PlayerNum, Socket mySocket)
        {
            this.CurrentPlayerNum = PlayerNum;
            this.PlayerSocket = mySocket;
            this.CurrentStatus = 1;
            SocketRecevie();
        }
        
        public void SocketRecevie()
        {
            Task.Run(() =>
            {
                try
                {
                    //server & client 已經連線完成    
                    Console.WriteLine("客戶端No.{0}已連結.", CurrentPlayerNum.ToString());
                    SocketServer.BoardCast("客戶端No." + CurrentPlayerNum.ToString() + "已連結.");
                    while (PlayerSocket.Connected)
                    {                        
                        byte[] readBuffer = new byte[1024];
                        int count = 0;

                        if ((count = PlayerSocket.Receive(readBuffer)) > 0)
                        {
                            string clientRequest = Encoding.UTF8.GetString(readBuffer, 0, count);

                            Console.WriteLine("客戶端No.{0}：{1}", CurrentPlayerNum.ToString(), clientRequest);
                        }
                    }
                }
                catch
                {
                    SocketServer.BoardCast("客戶端No." + CurrentPlayerNum.ToString() + "已斷開連結.");
                    Console.WriteLine("客戶端No.{0}已斷開連結.", CurrentPlayerNum.ToString());
                }
                finally
                {
                    PlayerSocket.Dispose();
                    this.CurrentStatus = 0;
                    SocketServer.RemoveClient(this.CurrentPlayerNum, this);
                }
            });
        }

        public void Send(string serverResponse)
        {
            if (this.CurrentStatus.Equals(1))
            {
                try
                {
                    byte[] sendBytes = Encoding.UTF8.GetBytes(serverResponse);
                    PlayerSocket.Send(sendBytes);                   
                }
                catch
                {
                }
            }
        }

    }
}
