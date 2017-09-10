﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EvolutionislandRobotClient
{
    class Program
    {

        private static Socket mSocket;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;            

            IPAddress ipAddress = null;
            if (!IPAddress.TryParse("192.168.11.2", out ipAddress))
            {
                ipAddress = null;
            }
            mSocket = new Socket(SocketType.Stream,ProtocolType.Tcp);

            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress,8001);
            mSocket.Connect(ipEndPoint);

            Task.Run(() =>
            {
                try
                {
                    while (mSocket.Connected)
                    {
                        byte[] readBuffer = new byte[1024];
                        int count = 0;

                        if ((count = mSocket.Receive(readBuffer)) > 0)
                        {
                            string clientRequest = Encoding.UTF8.GetString(readBuffer, 0, count);

                            Console.WriteLine(clientRequest);
                        }
                    }
                }
                catch(Exception e)
                {
                    
                    Console.WriteLine(e.Message);
                }
            });

            Console.Read();
        }
    }
}