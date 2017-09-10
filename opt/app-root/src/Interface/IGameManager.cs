using EvolutionislandGameServer.DTO;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace EvolutionislandGameServer.Interface
{
    public interface IGameManager
    {
        object Locking { get; }
        ConcurrentDictionary<string, Player> PlayerMap { get; }

        string GetAppVersion();
    }
}
