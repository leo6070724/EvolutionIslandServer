using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionislandCommonLibrary.Library
{
    [Serializable]
    public class ResponseInfo
    {
        public bool OK;
        public string Message;
    }
    /// <summary>
    /// Evolutionisland Client To Server
    /// </summary>
    [Serializable]
    public class VersionResponse : ResponseInfo
    {
        public string Version;
    }
    /// <summary>
    /// 註冊
    /// </summary>
    [Serializable]
    public class RegisterResponse : ResponseInfo
    {
    }
    /// <summary>
    /// 登入
    /// </summary>
    [Serializable]
    public class LoginResponse : ResponseInfo
    {
        public PlayerData PlayerData;
    }
    /// <summary>
    /// 登出
    /// </summary>
    [Serializable]
    public class LogoutResponse : ResponseInfo
    {
    }
    [Serializable]
    public class EnterGameResponse : ResponseInfo
    {
    }
    [Serializable]
    public class LeaveGameResponse : ResponseInfo
    {
    }
}
