
using DynamicDBModel.Models.Battle;
using System.Collections.Generic;
namespace BattleSimulator
{
    public interface ICharacterViewer
    {
        void AfterCreated(string id, int idStatic, int level, int powerUpLevel,
            int star, int colFormation, int rowFormation, float hpMax, int indexUltimate);

        void ProcessTurn(string idOwner, bool canProcSkill, int typeSkill, List<TargetReplay> targets, float affDmg, int hp, int result);

        void ChangeTurn(string[] ids);
    }
}
