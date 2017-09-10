using EvolutionislandGameServer.GameMethod;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionislandGameServer
{
    class Program
    {
        private static SocketServer mSocketServer { get; set; }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("v0.1");
            StartHost(args);
            if (mSocketServer != null)
            {
                L_CONTINUE:
                string command = Console.ReadLine();
                if (command == "EXIT")
                {
                    StopHost();
                }               
                else
                {
                    goto L_CONTINUE;
                }
                Console.WriteLine("stop the host.");
            }
            Console.Read();
        }
        static public async void StartHost(string[] args)
        {            
            var result = await PlayerLogoutAsync();

            IPAddress ipAddress = null;
            if ((args != null) && (args.Length > 0))
            {
                if (!IPAddress.TryParse(args[0], out ipAddress))
                {
                    ipAddress = null;
                }
            }
            StartHost(ipAddress, 8001);
        }
        static void StartHost(IPAddress ipAddress, int port)
        {
            if (ipAddress == null)
            {
                ipAddress = IPAddress.Any;
            }
            Console.WriteLine($"Server started. Listening to TCP clients at {ipAddress}:{port}");
            mSocketServer = new SocketServer();
            mSocketServer.Start(ipAddress, port);

            // 初始化遊戲 ( 建立遊戲主體 )
            GameManager manager = new GameManager();
            GameManager.Initialize(manager);
            manager.InitializeGame();
        }
        static public async void StopHost()
        {
            if (mSocketServer != null)
            {
                var result = await PlayerLogoutAsync();

                mSocketServer.Stop();
                mSocketServer = null;
            }
        }
        static private Task<bool> PlayerLogoutAsync()
        {
            return Task.Run(() => PlayerLogout());
        }
        static private bool PlayerLogout()
        {
            // 將所有人登出            

            return true;
        }
    }    
}