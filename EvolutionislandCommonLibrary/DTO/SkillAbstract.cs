using EvolutionislandCommonLibrary.Library;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EvolutionislandCommonLibrary.DTO
{
    public class Skill
    {
        private Dictionary<string, object> _skillAbilityList = new Dictionary<string, object>();
        public Dictionary<string, object> SkillAbilityList { get => _skillAbilityList;private set => _skillAbilityList = value; }

        private SkillFormat _skillFormat;
        public Skill(SkillFormat format)
        {
            _skillFormat = format;
        }
        public int GetSkillCount()
        {
            return SkillAbilityList.Count;
        }
        public Skill Add(params SkillAction[] skillStrategys)
        {
            if (skillStrategys == null) return this;
            foreach(SkillAction aSkillStrategy in skillStrategys)
            {               
                if (!this.SkillAbilityList.ContainsKey(aSkillStrategy.GetName()))
                {
                    this.SkillAbilityList.Add(aSkillStrategy.GetName(), aSkillStrategy);
                }
                else
                {                    
                    if (this._skillFormat.Format(aSkillStrategy.GetName(), this.SkillAbilityList[aSkillStrategy.GetName()]) < aSkillStrategy)
                        this.SkillAbilityList[aSkillStrategy.GetName()] = aSkillStrategy;
                }
            }
            return this;
        }
        public void FreeAttack(GamePlayerData gamePlayerData,SkillFormat format)
        {
            _skillFormat = format;
            Dictionary<string, SkillAction> newList = this._skillFormat.FormatList(this.SkillAbilityList);
            foreach (var aSkillStrategy in newList)
            {
                aSkillStrategy.Value.FreeAattack(gamePlayerData);
            }
        }  
        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }
        public Skill Deserialize(string text)
        {
            return JsonConvert.DeserializeObject<Skill>(text);
        }        
    }
    public abstract class SkillFormat
    {
        public abstract SkillAction Format(string key, object value);
        public Dictionary<string, SkillAction> FormatList(Dictionary<string, object> list)
        {
            Dictionary<string, SkillAction> newList = new Dictionary<string, SkillAction>();
            foreach (var skill in list)
            {
                newList.Add(skill.Key, Format(skill.Key, skill.Value));
            }
            return newList;
        }
    }
    public abstract class SkillAction: IComparable
    {        
        protected string _name;
        protected GamePlayerData _playerData;

        public SkillAction()
        {
        }
        public SkillAction(GamePlayerData playerData)
        {
            this._playerData = playerData;
        }

        public string GetName()
        {
            return this._name;
        }
        public abstract void FreeAattack(GamePlayerData gamePlayerData);

        public abstract int CompareTo(object obj);

        public static bool operator <(SkillAction skillAction1, SkillAction skillAction2)
        {
            return skillAction1.CompareTo(skillAction2) < 0;
        }
        public static bool operator >(SkillAction skillAction1, SkillAction skillAction2)
        {
            return skillAction1.CompareTo(skillAction2) > 0;
        }
    }
}
