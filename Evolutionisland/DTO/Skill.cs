using EvolutionislandCommonLibrary.DTO;
using EvolutionislandCommonLibrary.Library;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Evolutionisland.DTO
{
    public class BaseSkillFormat : SkillFormat
    {
        public override SkillAction Format(string key, object value)
        {
            switch(key)
            {
                case "NormalSkillAbility":                   
                    return JsonConvert.DeserializeObject<NormalSkillAbility>(JsonConvert.SerializeObject(value));
                case "BloodSkillAbility":
                    return JsonConvert.DeserializeObject<BloodSkillAbility>(JsonConvert.SerializeObject(value));
                default:
                    throw new NotImplementedException();
            }
        }
    }
    public class NormalSkillAbility : SkillAction
    {
        public float _power;
        public NormalSkillAbility()
        {
            
        }
        public NormalSkillAbility(GamePlayerData playerData) : base(playerData)
        {

            this._name = "NormalSkillAbility";
            this._power = _playerData.PhysicalAtk;
        }

        public override int CompareTo(object obj)
        {
            NormalSkillAbility normalSkillAbility = (NormalSkillAbility)obj;

            if (_power < normalSkillAbility._power) { return -1; }
            if (_power > normalSkillAbility._power) { return 1; }
            return 0;
        }

        public override void FreeAattack(GamePlayerData gamePlayerData)
        {
            gamePlayerData.Health -= _power;
            Console.WriteLine(GetName() + " -" + this._power);
            Console.WriteLine(gamePlayerData.Health);
        }
    }
    public class BloodSkillAbility : SkillAction
    {
        public float _time;
        public float _power;

        public BloodSkillAbility()
        {

        }

        public BloodSkillAbility(GamePlayerData playerData, float time,float power = 0) : base(playerData)
        {
            _name = "BloodSkillAbility";
            _time = time;
            if(power != 0)
            {
                this._power = power;
            }
            else
            {
                this._power = _playerData.PhysicalAtk;
            }
        }

        public override int CompareTo(object obj)
        {
            BloodSkillAbility normalSkillAbility = (BloodSkillAbility)obj;

            if (_power < normalSkillAbility._power) { return -1; }
            if (_power > normalSkillAbility._power) { return 1; }
            return 0;
        }

        public override void FreeAattack(GamePlayerData gamePlayerData)
        {
            Console.WriteLine(GetName() + " -" + _power + "持續" + this._time + "秒");
            Task.Run(() =>
            {               
                while(this._time >0)
                {
                    gamePlayerData.Health -= _power;
                    Console.WriteLine(gamePlayerData.Health);
                    this._time--;
                    Thread.Sleep(1000);
                }
            });
        }
    }
}