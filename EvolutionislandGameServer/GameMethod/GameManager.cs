using EvolutionislandGameServer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using EvolutionislandGameServer.DTO;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace EvolutionislandGameServer.GameMethod
{
    public partial class GameManager :IGameManager
    {
        static protected GameManager sInstance;
        protected readonly object _locking;
        protected readonly ConcurrentDictionary<string, Player> _playerMap;
        // 追蹤全部的task
        private List<Task> _taskList;

        public GameManager()
        {
            _locking = new object();
            
            _playerMap = new ConcurrentDictionary<string, Player>();

            _taskList = new List<Task>();
        }
        static public void Initialize(GameManager manager)
        {
            sInstance = manager;
        }
        static public GameManager Instance
        {
            get { return sInstance; }
        }        

        public object Locking
        {
            get { return _locking; }
        }

        public ConcurrentDictionary<string, Player> PlayerMap
        {
            get { return _playerMap; }
        }
        public List<Task> TaskList
        {
            get { return _taskList; }
            set { _taskList = value; }
        }

        public string GetAppVersion()
        {
            return "0.1";
        }
    }
}
