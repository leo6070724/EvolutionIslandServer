using EvolutionislandCommonLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace EvolutionislandCommonLibrary.Library
{/// <summary>
 ///玩家資料
 /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class PlayerData
    {
        public string Name;
        public int Money;
        public int Diamond;
    }

    /// <summary>
    ///遊戲中玩家資料
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential,Pack = 1)]
    public class GamePlayerData
    {
        public float CDTime;                    //CD時間
        public int Money;                       //玩家金錢
        public int Level;                       //玩家等級
        public float Experience;                //經驗值
        public float ExperienceGain;            //經驗值獲得率
        public float MoveSpeed;                 //移動速度
        public float MaxMoveSpeed;              //最大移動速度
        public float BodyVolume;                //體積
        public float MaxBodyVolume;             //最大體積
        public float Health;                    //目前生命
        public float MaxHealth;                 //最大生命
        public float HealthRegen;               //生命回復
        public float Magic;                     //目前魔力
        public float MaxMagic;                  //最大魔力
        public float MagicRegen;                //魔力回復
        public float AtkSpeed;                  //攻擊速度
        public float MaxAtkSpeed;               //最大攻擊速度
        public float CritRate;                  //暴擊率
        public float MaxCritRate;               //最大暴擊率
        public float CritBonus;                 //暴擊加成
        public float MaxCritBonus;              //最大暴擊加成
        public float AtkRange;                  //攻擊距離
        public float MaxAtkRange;               //最大攻擊距離
        public float PhysicalAtk;               //物理攻擊
        public float MaxPhysicalAtk;            //最大物理攻擊
        public float PhysicalLifeSteal;         //物理吸血
        public float MaxPhysicalLifeSteal;      //最大物理吸血
        public float MagicAtkPower;             //魔法攻擊
        public float MaxMagicAtkPower;          //最大魔法攻擊
        public float MagicAtkPowerLifeSteal;    //魔法攻擊吸血
        public float PhysicalAtkPenetrate;      //物理穿透
        public float MaxPhysicalAtkPenetrate;   //最大物理穿透
        public float MagicAtkPenetrate;         //魔法攻擊穿透
        public float MaxMagicAtkPenetrate;      //最大魔法攻擊穿透
        public int PhysicalDefense;             //物理防禦
        public int MaxPhysicalDefense;          //最大物理防禦
        public int MagicDefense;                //魔法防禦
        public int MaxMagicDefense;             //最大魔法防禦
        public float Tenacity;                  //韌性
        public float MaxTenacity;               //最大韌性
        public bool CanMove;                    //是否可移動
        public bool CanControll;                //是否可控制
    }
}
