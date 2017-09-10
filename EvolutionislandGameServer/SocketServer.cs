using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace EvolutionislandGameServer
{
    public class SocketServer
    {
        static ConcurrentDictionary<int, Client> ClientMap;
        static private int CurrentPlayerNum { get; set; }
        static private Socket mServer;
        public SocketServer()
        {
            mServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ClientMap = new ConcurrentDictionary<int, Client>();
        }
        public void Start(IPAddress ipAddress, int port)
        {
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, port);
            mServer.Bind(ipEndPoint);
            mServer.Listen(50);
            Task.Run(()=>
            {
                while(true)
                {
                    try
                    {
                        Socket acceptedSocket = mServer.Accept();
                        CurrentPlayerNum++;
                        Client aClient = new Client(CurrentPlayerNum, acceptedSocket);
                        ClientMap.TryAdd(CurrentPlayerNum, aClient);
                        BoardCast("123");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Stop();
                    }
                }                
            });
            
        }
        internal static void BoardCast(string v)
        {
            foreach (var aClient in ClientMap.ToArray())
            {
                aClient.Value.Send(v);
            }
        }

        internal static void RemoveClient(int currentPlayerNum, Client client)
        {
            if (ClientMap.ContainsKey(currentPlayerNum))
                ClientMap.TryRemove(currentPlayerNum, out client);
        }
        public void Stop()
        {
            mServer.Dispose();
        }
    }
}
