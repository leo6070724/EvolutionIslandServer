using Evolutionisland.DTO;
using EvolutionislandCommonLibrary.DTO;
using EvolutionislandCommonLibrary.Library;
using System;

namespace Evolutionisland
{
    class Program
    {
        static BaseSkillFormat BaseSkillFormat = new BaseSkillFormat();
        static void Main(string[] args)
        {
            GamePlayerData player = new GamePlayerData
            {
                Health = 100,

                PhysicalAtk = 1
                
            };
            Skill skill = new Skill(BaseSkillFormat).Add(new NormalSkillAbility(player),new BloodSkillAbility(player,5),new NormalSkillAbility(player));
            skill.FreeAttack(player, BaseSkillFormat);

            Console.Read();
        }
    }
}
