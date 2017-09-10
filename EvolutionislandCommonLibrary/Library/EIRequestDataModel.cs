using EvolutionislandCommon.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionislandCommonLibrary.Library
{
    /// <summary>
    /// Evolutionisland Client To Server
    /// </summary>
    [Serializable]
    public class VersionRequest
    {
        public string Version;
    }
    /// <summary>
    /// 註冊
    /// </summary>
    [Serializable]
    public class RegisterRequest
    {
        public string FBID;
        public string Version;
        public string Account;
        public string Password;
        public string Device;
    }
    /// <summary>
    /// 登入
    /// </summary>
    [Serializable]
    public class LoginRequest
    {
        public string FBID;
        public string Version;
        public string Device;
        public string Account;
        public string Password;
        public string Session;
    }
    /// <summary>
    /// 登出
    /// </summary>
    [Serializable]
    public class LogoutRequest
    {
    }
    [Serializable]
    public class EnterGameRequest
    {
        public GameType GameType;
        public GameMapType GameMapType;
    }
    [Serializable]
    public class LeaveGameRequest
    {
    }
}
