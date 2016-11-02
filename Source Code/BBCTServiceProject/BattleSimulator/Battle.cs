using DynamicDBModel.Models.Battle;
using StaticDB;
using StaticDB.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleSimulator
{
    public class Battle
    {
        public Entity staticDB;

        public DataInputBattle inputBattle;
        public List<BCharacter> characters;
        public List<BCharacter> charactersA;
        public List<BCharacter> charactersB;
        public List<BCharacter> charactersAS;
        public List<BCharacter> charactersBS;
        public List<BCharacter> turns;

        public int countTurn;
        public bool isGenerateReplay;
        public bool isAuto;
        public BattleReplay replay;
        public bool isIgnoreView;
        public IDebugLogger logger;
        public int result;
        public int star;
        private int curAutoTeamA;
        private int curAutoTeamB;
        public int curCharSubA;
        public int curCharSubB;

        public Battle(Entity staticDB, DataInputBattle inputBattle, bool isGenerateReplay, bool isIgnoreView, IDebugLogger logger, bool isAuto)
        {
            this.staticDB = staticDB;
            this.inputBattle = inputBattle;
            this.isGenerateReplay = isGenerateReplay;
            this.isIgnoreView = isIgnoreView;
            this.logger = logger;
            this.isAuto = isAuto;

            if (isGenerateReplay)
            {
                replay = new BattleReplay();
                replay.teamA = new List<CharacterReplay>();
                replay.teamB = new List<CharacterReplay>();
                replay.teamAS = new List<CharacterReplay>();
                replay.teamBS = new List<CharacterReplay>();
                replay.teamASStart = new List<CharacterReplay>();
                replay.teamBSStart = new List<CharacterReplay>();
                replay.turns = new List<TurnReplay>();
                replay.idBackground = inputBattle.idBackground;
            }
            characters = new List<BCharacter>();

            charactersA = new List<BCharacter>();
            charactersB = new List<BCharacter>();
            charactersAS = new List<BCharacter>();
            charactersBS = new List<BCharacter>();

            for (int i = 0; i < inputBattle.teamA.mainChars.Count; i++)
            {
                BCharacter bCharacter = new BCharacter("A" + (i + 1), this, inputBattle.teamA.mainChars[i], "A", true,
                    inputBattle.teamA.mainChars[i].typeElement);
                charactersA.Add(bCharacter);
                characters.Add(bCharacter);
            }
            for (int i = 0; i < inputBattle.teamB.mainChars.Count; i++)
            {
                BCharacter bCharacter = new BCharacter("B" + (i + 1), this, inputBattle.teamB.mainChars[i], "B", true,
                    inputBattle.teamB.mainChars[i].typeElement);
                charactersB.Add(bCharacter);
                characters.Add(bCharacter);
            }
            for (int i = 0; i < inputBattle.teamA.subChars.Count; i++)
            {
                BCharacter bCharacterAS = new BCharacter("Asub" + (i + 1), this, inputBattle.teamA.subChars[i], "A", false,
                    inputBattle.teamA.subChars[i].typeElement);
                charactersAS.Add(bCharacterAS);
            }

            for (int i = 0; i < inputBattle.teamB.subChars.Count; i++)
            {
                BCharacter bCharacterBS = new BCharacter("Bsub" + (i + 1), this, inputBattle.teamB.subChars[i], "B", false,
                    inputBattle.teamB.subChars[i].typeElement);
                charactersBS.Add(bCharacterBS);
            }

            foreach (var ch in characters)
            {
                ch.ProcessInit();
            }
            characters = characters.OrderByDescending(x => x.calculator.GetAttribute(CharacterAttribute.Agi)).ToList();
            turns = new List<BCharacter>(characters);

            curAutoTeamA = 0;
            curAutoTeamB = 0;
        }

        public void StartBattle()
        {
            turns[0].CallViewerChangeTurn(GetTurnId());
            ProcessTurn();
        }

        public void ProcessTurn()
        {

            foreach (var ch in characters)
            {
                ch.coolDown.ForEach(a => a--);
            }
            BCharacter turnOwner = turns[0];
            if (turnOwner.state == BCharacter.State.Alive)
            {
                countTurn++;

                TurnReplay turnReplay = new TurnReplay();
                turnReplay.idOwner = turnOwner.id;

                #region Affliction
                float totalAffDmg = turnOwner.affController.Minus();
                #endregion

                turnReplay.affDmg = totalAffDmg;
                turnReplay.hp = (int)turnOwner.hp;

                if (turnOwner.state == BCharacter.State.Die ||
                    turnOwner.affController.GetAffliction(Affliction.DongBang).IsStart() ||
                    turnOwner.affController.GetAffliction(Affliction.Choang).IsStart())
                {
                    result = CheckEndBattle();
                    turnOwner.CallViewerProcessTurn(turnReplay.idOwner, false, 0, null, totalAffDmg, turnReplay.hp, result);
                }
                else
                {
                    #region Process Choose Skill and change mana
                    //                    SkillCalculator curSkill = null;
                    //                    TurnReplay.TypeSkill typeSkill = TurnReplay.TypeSkill.Normal;
                    //                    if (turnOwner.affController.GetAffliction(Affliction.CamChieu).IsStart() ||
                    //                        turnOwner.affController.GetAffliction(Affliction.KhieuKhich).IsStart()
                    //                        && turnOwner.isUltimate)
                    //                    {
                    //                        turnOwner.isUltimate = false;
                    //                    }
                    //                    if (turnOwner.isUltimate)
                    //                    {
                    //                        typeSkill = TurnReplay.TypeSkill.Ultimate;
                    //
                    //                        if (turnOwner.CurrentSkillUltimate() != null)
                    //                            curSkill = turnOwner.CurrentSkillUltimate();
                    //
                    //                        turnOwner.isUltimate = false;
                    //                    }
                    //                    else
                    //                    {
                    //                        typeSkill = TurnReplay.TypeSkill.Normal;
                    //                        curSkill = turnOwner.normalSkill;
                    //
                    //                    }
                    //                    if (curSkill.info.target == TargetSkill.Attack)
                    //                    {
                    //
                    //                    }
                    //
                    //                    turnReplay.typeSkill = (int)typeSkill;

                    #endregion

                    ProcessSkill(turnReplay, turnOwner);
                }

                if (isIgnoreView)
                {
                    EndTurn();
                }
            }
            else
            {
                EndTurn();
            }

        }



        public void ProcessSkill(TurnReplay turnReplay, BCharacter owner)
        {
            SkillCalculator skill = owner.normalSkill;
            if (turnReplay.typeSkill == TurnReplay.TypeSkillCharacter.Ultimate)
            {
                skill = owner.CurrentSkillUltimate();
            }

            if (turnReplay.typeSkill == TurnReplay.TypeSkillCharacter.Passive)
            {
                skill = owner.passiveSkill1;
            }

            List<TargetReplay> targetsReplay = new List<TargetReplay>();

            #region Process Content Skill

            if (skill != null)
            {
                List<BCharacter> targets = FindTarget(owner, skill);

                if (targets.Count <= 0)
                {
                    PrintLog("Error : Can not find target with " + skill.info.range + " of " + owner.id);
                }

                #region Effect skill
                switch (skill.info.effect)
                {
                    case EffectSkill.Revenger:
                    case EffectSkill.Damage:
                        for (int a = 0; a < targets.Count; a++)
                        {
                            if (targets[a].state == BCharacter.State.Alive)
                            {
                                TargetReplay targetReplay = new TargetReplay();
                                targetsReplay.Add(targetReplay);

                                targetReplay.idTarget = targets[a].id;
                                targetReplay.actions = new List<ActionReplay>();

                                targets[a].SetRevengerCharacter(owner);

                                for (int i = 0; i < skill.info.countTurn; i++)
                                {
                                    if (targets[a].state == BCharacter.State.Alive)
                                    {
                                        ActionReplay actionReplay = new ActionReplay();
                                        targetReplay.actions.Add(actionReplay);

                                        bool isMiss = false;
                                        float percentAccurate = owner.calculator.GetAttribute(CharacterAttribute.Accurate)
                                            - targets[a].calculator.GetAttribute(CharacterAttribute.Dodge) * staticDB.configs.battleConfig.modX;

                                        if (percentAccurate < 20f)
                                        {
                                            percentAccurate = 20;
                                            isMiss = true;
                                        }

                                        float rnd = RandomHelper.RandomFloat(0f, 100f);
                                        if (rnd > percentAccurate)
                                        {
                                            isMiss = true;
                                        }

                                        bool isCrit = false;
                                        float procCrit = owner.calculator.GetAttribute(CharacterAttribute.CritRate) - targets[a].calculator.GetAttribute(CharacterAttribute.ResistCrit);
                                        if (RandomHelper.RandomFloat(0f, 100f) <= procCrit)
                                        {
                                            isCrit = true;
                                        }

                                        float dmg = 0f;



                                        bool isBlock = RandomHelper.RandomFloat(0f, 100f) <= targets[a].calculator.GetAttribute(CharacterAttribute.BlockRate);

                                        if (!isMiss)
                                        {
                                            dmg = targets[a].Attacked(owner, skill.GetAttributes()[0].mod, (int)skill.info.category, isCrit, isBlock, skill.info.countTurn);
                                        }

                                        bool isProcAffliction = false;

                                        if (i == skill.info.countTurn - 1)
                                        {
                                            if (skill.info.afflictionSkill != 0)
                                            {
                                                isProcAffliction = (RandomHelper.RandomFloat(0f, 100f) <= skill.info.afflictionProc);
                                            }
                                        }

                                        if (isProcAffliction)
                                        {
                                            isProcAffliction = StartAffliction(skill, targets[a]);
                                        }

                                        actionReplay.isMiss = isMiss;
                                        actionReplay.isCrit = isCrit;
                                        actionReplay.isBlock = isBlock;
                                        actionReplay.attribute = (int)dmg;
                                        actionReplay.hp = (int)targets[a].hp;
                                        actionReplay.isAffliction = isProcAffliction;
                                    }
                                }
                            }
                        }
                        break;
                    case EffectSkill.HPRegen:
                        for (int a = 0; a < targets.Count; a++)
                        {
                            if (targets[a].state == BCharacter.State.Alive)
                            {
                                TargetReplay targetReplay = new TargetReplay();
                                targetsReplay.Add(targetReplay);

                                targetReplay.idTarget = targets[a].id;
                                targetReplay.actions = new List<ActionReplay>();

                                for (int i = 0; i < skill.info.countTurn; i++)
                                {
                                    if (targets[a].state == BCharacter.State.Alive)
                                    {
                                        ActionReplay actionReplay = new ActionReplay();
                                        targetReplay.actions.Add(actionReplay);

                                        float regen = targets[a].RegenHP(skill.GetAttributes()[0].mod);

                                        bool isProcAffliction = false;

                                        if (i == skill.info.countTurn - 1)
                                        {
                                            if (skill.info.afflictionSkill != 0)
                                            {
                                                isProcAffliction = (RandomHelper.RandomFloat(0f, 100f) <= skill.info.afflictionProc);
                                            }
                                        }

                                        if (isProcAffliction)
                                        {
                                            isProcAffliction = StartAffliction(skill, targets[a]);
                                        }

                                        actionReplay.isMiss = false;
                                        actionReplay.isCrit = false;
                                        actionReplay.attribute = (int)regen;
                                        actionReplay.hp = (int)targets[a].hp;
                                        actionReplay.isAffliction = isProcAffliction;
                                    }
                                }
                            }
                        }
                        break;
                    case EffectSkill.LifeSteal:
                        for (int a = 0; a < targets.Count; a++)
                        {
                            if (targets[a].state == BCharacter.State.Alive)
                            {
                                TargetReplay targetReplay = new TargetReplay();
                                targetsReplay.Add(targetReplay);

                                targetReplay.idTarget = targets[a].id;
                                targetReplay.actions = new List<ActionReplay>();

                                for (int i = 0; i < skill.info.countTurn; i++)
                                {
                                    if (targets[a].state == BCharacter.State.Alive)
                                    {
                                        ActionReplay actionReplay = new ActionReplay();
                                        targetReplay.actions.Add(actionReplay);

                                        bool isMiss = false;
                                        float percentAccurate = owner.calculator.GetAttribute(CharacterAttribute.Accurate) - targets[a].calculator.GetAttribute(CharacterAttribute.Dodge);
                                        if (percentAccurate <= 0f)
                                        {
                                            isMiss = true;
                                        }
                                        else
                                        {
                                            if (RandomHelper.RandomFloat(0f, 100f) > percentAccurate)
                                            {
                                                isMiss = true;
                                            }
                                        }

                                        bool isCrit = false;
                                        float procCrit = owner.calculator.GetAttribute(CharacterAttribute.CritRate) - targets[i].calculator.GetAttribute(CharacterAttribute.ResistCrit);
                                        if (RandomHelper.RandomFloat(0f, 100f) <= procCrit)
                                        {
                                            isCrit = true;
                                        }

                                        float dmg = 0f;

                                        bool isBlock = RandomHelper.RandomFloat(0f, 100f) <= owner.calculator.GetAttribute(CharacterAttribute.BlockRate);

                                        if (!isMiss)
                                        {
                                            dmg = targets[a].Attacked(owner, skill.GetAttributes()[0].mod, (int)skill.info.category, isCrit, isBlock, skill.info.countTurn);
                                            targets[a].RegenHPByPoint(dmg);
                                        }

                                        bool isProcAffliction = false;

                                        if (i == skill.info.countTurn - 1)
                                        {
                                            if (skill.info.afflictionSkill != 0)
                                            {
                                                isProcAffliction = (RandomHelper.RandomFloat(0f, 100f) <= skill.info.afflictionProc);
                                            }
                                        }

                                        if (isProcAffliction)
                                        {
                                            isProcAffliction = StartAffliction(skill, targets[a]);
                                        }

                                        actionReplay.isMiss = isMiss;
                                        actionReplay.isCrit = isCrit;
                                        actionReplay.isBlock = isBlock;
                                        actionReplay.attribute = (int)dmg;
                                        actionReplay.hp = (int)targets[a].hp;
                                        actionReplay.isAffliction = isProcAffliction;
                                    }
                                }
                            }
                        }
                        break;
                    case EffectSkill.OnlyAffliction:
                        for (int a = 0; a < targets.Count; a++)
                        {
                            if (targets[a].state == BCharacter.State.Alive)
                            {
                                TargetReplay targetReplay = new TargetReplay();
                                targetsReplay.Add(targetReplay);

                                targetReplay.idTarget = targets[a].id;
                                targetReplay.actions = new List<ActionReplay>();

                                for (int i = 0; i < skill.info.countTurn; i++)
                                {
                                    if (targets[a].state == BCharacter.State.Alive)
                                    {
                                        ActionReplay actionReplay = new ActionReplay();
                                        targetReplay.actions.Add(actionReplay);

                                        bool isProcAffliction = false;

                                        if (i == skill.info.countTurn - 1)
                                        {
                                            if (skill.info.afflictionSkill != 0)
                                            {
                                                isProcAffliction = (RandomHelper.RandomFloat(0f, 100f) <= skill.info.afflictionProc);
                                            }
                                        }

                                        if (isProcAffliction)
                                        {
                                            isProcAffliction = StartAffliction(skill, targets[a]);
                                        }

                                        actionReplay.isMiss = false;
                                        actionReplay.isCrit = false;
                                        actionReplay.attribute = 0;
                                        actionReplay.hp = (int)targets[a].hp;
                                        actionReplay.isAffliction = isProcAffliction;
                                    }
                                }
                            }
                        }
                        break;
                    case EffectSkill.InCreaseCooldown:
                    case EffectSkill.DecreaseCooldown:
                        for (int a = 0; a < targets.Count; a++)
                        {
                            if (targets[a].state == BCharacter.State.Alive)
                            {
                                TargetReplay targetReplay = new TargetReplay();
                                targetsReplay.Add(targetReplay);

                                targetReplay.idTarget = targets[a].id;
                                targetReplay.actions = new List<ActionReplay>();

                                for (int i = 0; i < skill.info.countTurn; i++)
                                {
                                    if (targets[a].state == BCharacter.State.Alive)
                                    {
                                        ActionReplay actionReplay = new ActionReplay();
                                        targetReplay.actions.Add(actionReplay);

                                        targets[a].ReCooldown(skill.info.countTurn, skill.info.afflictionDuration, EffectSkill.DecreaseCooldown);

                                        bool isProcAffliction = false;

                                        if (i == skill.info.countTurn - 1)
                                        {
                                            if (skill.info.afflictionSkill != 0)
                                            {
                                                isProcAffliction = (RandomHelper.RandomFloat(0f, 100f) <= skill.info.afflictionProc);
                                            }
                                        }

                                        if (isProcAffliction)
                                        {
                                            isProcAffliction = StartAffliction(skill, targets[a]);
                                        }

                                        actionReplay.isMiss = false;
                                        actionReplay.isCrit = false;
                                        actionReplay.attribute = 0;
                                        actionReplay.hp = (int)targets[a].hp;
                                        actionReplay.isAffliction = isProcAffliction;
                                    }
                                }
                            }
                        }
                        break;
                    case EffectSkill.Revive:
                        owner.Revive();
                        break;
                    case EffectSkill.DeleteGoodEffect:
                    case EffectSkill.DeleteBadEffect:
                        for (int a = 0; a < targets.Count; a++)
                        {
                            if (targets[a].state == BCharacter.State.Alive)
                            {
                                TargetReplay targetReplay = new TargetReplay();
                                targetsReplay.Add(targetReplay);

                                targetReplay.idTarget = targets[a].id;
                                targetReplay.actions = new List<ActionReplay>();

                                for (int i = 0; i < skill.info.countTurn; i++)
                                {
                                    if (targets[a].state == BCharacter.State.Alive)
                                    {
                                        ActionReplay actionReplay = new ActionReplay();
                                        targetReplay.actions.Add(actionReplay);

                                        targets[a].DeleteAffliction(EffectSkill.DeleteBadEffect);

                                        bool isProcAffliction = false;

                                        if (i == skill.info.countTurn - 1)
                                        {
                                            if (skill.info.afflictionSkill != 0)
                                            {
                                                isProcAffliction = (RandomHelper.RandomFloat(0f, 100f) <= skill.info.afflictionProc);
                                            }
                                        }

                                        if (isProcAffliction)
                                        {
                                            isProcAffliction = StartAffliction(skill, targets[a]);
                                        }

                                        actionReplay.isMiss = false;
                                        actionReplay.isCrit = false;
                                        actionReplay.attribute = 0;
                                        actionReplay.hp = (int)targets[a].hp;
                                        actionReplay.isAffliction = isProcAffliction;
                                    }
                                }
                            }
                        }
                        break;
                }

                #endregion
            }

            #endregion

            #region Auto Skill

            if (isAuto)
            {
                bool isFoundA = true;
                int countLoopA = 0;

                while (isFoundA)
                {
                    if (curAutoTeamA < charactersA.Count)
                    {
                        if (charactersA[curAutoTeamA].state == BCharacter.State.Alive)
                        {
                            isFoundA = false;
                            if (charactersA[curAutoTeamA].CanProcSkillPassive())
                            {
                                AddPassiveSkill(charactersA[curAutoTeamA].id, "A");
                                curAutoTeamA++;
                            }

                            if (charactersA[curAutoTeamA].CanProcSkill())
                            {
                                AddTurnUltimate(charactersA[curAutoTeamA].id, "A");
                                curAutoTeamA++;
                            }
                        }
                        else
                        {
                            countLoopA++;
                            curAutoTeamA++;
                        }
                    }
                    else
                    {
                        curAutoTeamA = 0;
                        if (charactersA[curAutoTeamA].state == BCharacter.State.Alive)
                        {
                            isFoundA = false;
                            if (charactersA[curAutoTeamA].CanProcSkillPassive())
                            {
                                AddPassiveSkill(charactersA[curAutoTeamA].id, "A");
                                curAutoTeamA++;
                            }

                            if (charactersA[curAutoTeamA].CanProcSkill())
                            {
                                AddTurnUltimate(charactersA[curAutoTeamA].id, "A");
                                curAutoTeamA++;
                            }
                        }
                        else
                        {
                            countLoopA++;
                            curAutoTeamA++;
                        }
                    }
                    if (countLoopA == charactersA.Count)
                    {
                        isFoundA = false;
                    }
                }
            }

            bool isFoundB = true;
            int countLoopB = 0;

            while (isFoundB)
            {
                if (curAutoTeamB < charactersB.Count)
                {
                    if (charactersB[curAutoTeamB].state == BCharacter.State.Alive)
                    {
                        isFoundB = false;
                        if (charactersB[curAutoTeamB].CanProcSkillPassive())
                        {
                            AddPassiveSkill(charactersB[curAutoTeamB].id, "A");
                            curAutoTeamB++;
                        }

                        if (charactersB[curAutoTeamB].CanProcSkill())
                        {
                            AddTurnUltimate(charactersB[curAutoTeamB].id, "B");
                            curAutoTeamB++;
                        }

                    }
                    else
                    {
                        countLoopB++;
                        curAutoTeamB++;
                    }
                }
                else
                {
                    curAutoTeamB = 0;
                    if (charactersB[curAutoTeamB].state == BCharacter.State.Alive)
                    {
                        isFoundB = false;
                        if (charactersB[curAutoTeamB].CanProcSkillPassive())
                        {
                            AddPassiveSkill(charactersB[curAutoTeamB].id, "A");
                            curAutoTeamB++;
                        }

                        if (charactersB[curAutoTeamB].CanProcSkill())
                        {
                            AddTurnUltimate(charactersB[curAutoTeamB].id, "B");
                            curAutoTeamB++;
                        }
                    }
                    else
                    {
                        countLoopB++;
                        curAutoTeamB++;
                    }
                }

                if (countLoopB == charactersB.Count)
                {
                    isFoundB = false;
                }
            }

            #endregion

            result = CheckEndBattle();

            turnReplay.targets = targetsReplay;

            owner.CallViewerProcessTurn(owner.id, true, (int)turnReplay.typeSkill, turnReplay.targets, turnReplay.affDmg, turnReplay.hp, result);
        }

        public bool StartAffliction(SkillCalculator skill, BCharacter target)
        {
            if (target.calculator.idInStatic == 53)
            {
                return false;
            }
            bool canProc = true;
            if (target.affController.GetAffliction(Affliction.KhangHieuUng).IsStart())
            {
                canProc = false;
            }
            else
            {

                if (target.affController.GetAffliction(Affliction.TrungDoc).IsStart() && skill.info.afflictionSkill == Affliction.DotChay)
                {
                    canProc = false;
                }
                if (target.affController.GetAffliction(Affliction.DotChay).IsStart() && skill.info.afflictionSkill == Affliction.TrungDoc)
                {
                    canProc = false;
                }
            }
            if (canProc)
            {
                float attribute = 0f;
                if (skill.info.afflictionSkill == Affliction.DotChay ||
                    skill.info.afflictionSkill == Affliction.TrungDoc ||
                    skill.info.afflictionSkill == Affliction.PhaGiap ||
                    skill.info.afflictionSkill == Affliction.GiamCong ||
                    skill.info.afflictionSkill == Affliction.TangCong ||
                    skill.info.afflictionSkill == Affliction.TangGiap ||
                    skill.info.afflictionSkill == Affliction.TangBao)
                {
                    attribute = skill.GetAfflictionAttributes()[0];
                }
                target.affController.StartAffliction(skill.info.afflictionSkill, attribute, skill.info.afflictionDuration);
            }
            return canProc;
        }

        public bool EndTurn()
        {
            try
            {
                result = CheckEndBattle();
                if (result == 0)
                {
                    for (int i = 0; i < characters.Count; i++)
                    {
                        if (characters[i].id.Equals(turns[turns.Count - 1].id))
                        {
                            turns.RemoveAt(0);
                            int startIndex = i + 1;
                            bool isFound = true;
                            while (isFound)
                            {
                                if (startIndex < characters.Count)
                                {
                                    if (characters[startIndex].state == BCharacter.State.Alive)
                                    {
                                        turns.Add(characters[startIndex]);
                                        isFound = false;
                                    }
                                }
                                else
                                {
                                    startIndex = 0;
                                    if (startIndex < characters.Count)
                                    {
                                        if (characters[startIndex].state == BCharacter.State.Alive)
                                        {
                                            turns.Add(characters[startIndex]);
                                            isFound = false;
                                        }
                                    }
                                }
                                startIndex++;
                            }
                            break;
                        }
                    }
                    turns[0].CallViewerChangeTurn(GetTurnId());
                    ProcessTurn();
                    return false;
                }
                else
                {
                    EndBattle(result);
                    return true;
                }
            }
            catch (Exception ex)
            {
                PrintLog(ex.ToString());
                return true;
            }
        }

        public int CheckEndBattle()
        {
            int countA = 0;
            foreach (var ch in charactersA)
            {
                if (ch.state == BCharacter.State.Alive)
                {
                    countA++;
                }
            }
            if (countA == 0)
            {
                star = 0;
                if (isGenerateReplay)
                {
                    replay.star = star;
                }
                return 1;
            }
            else
            {
                int countB = 0;
                foreach (var ch in charactersB)
                {
                    if (ch.state == BCharacter.State.Alive)
                    {
                        countB++;
                    }
                }
                if (countB == 0)
                {
                    if (charactersA.Count - countA == 0)
                    {
                        star = 3;
                    }
                    else if (charactersA.Count - countA == 1)
                    {
                        star = 2;
                    }
                    else
                    {
                        star = 1;
                    }
                    if (isGenerateReplay)
                    {
                        replay.star = star;
                    }
                    return 2;
                }
                else
                {
                    if (countTurn >= staticDB.configs.battleConfig.maxTurn)
                    {
                        star = 0;
                        if (isGenerateReplay)
                        {
                            replay.star = star;
                        }
                        return 3;
                    }
                }
            }

            return 0;
        }

        public void EndBattle(int result)
        {

        }

        #region FindTarget

        public List<BCharacter> FindTarget(BCharacter owner, SkillCalculator skill)
        {
            List<BCharacter> listFind = null;
            string tagFind = null;
            if (skill.info.target == TargetSkill.Attack)
            {
                if (owner.tagTeam.Equals("A"))
                {
                    tagFind = "B";
                    listFind = charactersB;
                }
                else
                {
                    tagFind = "A";
                    listFind = charactersA;
                }
            }
            else
            {
                tagFind = owner.tagTeam;
                if (owner.tagTeam.Equals("A"))
                {
                    listFind = charactersA;
                }
                else
                {
                    listFind = charactersB;
                }
            }
            List<BCharacter> targets = new List<BCharacter>();
            switch (skill.info.range)
            {
                case RangeSkill.All:
                    targets = listFind.Where(x => x.state == BCharacter.State.Alive).ToList();
                    break;
                case RangeSkill.Face:
                    List<BCharacter> tempFind = listFind.Where(x => x.row == owner.row).ToList();
                    if (tempFind.Count > 0)
                    {
                        tempFind = tempFind.OrderBy(x => x.col).ToList();
                        if (tempFind[0].state == BCharacter.State.Alive)
                        {
                            targets.Add(tempFind[0]);
                        }
                        else
                        {
                            if (tempFind.Count > 1)
                            {
                                if (tempFind[1].state == BCharacter.State.Alive)
                                {
                                    targets.Add(tempFind[1]);
                                }
                                else
                                {
                                    if (tempFind.Count > 2)
                                    {
                                        if (tempFind[2].state == BCharacter.State.Alive)
                                        {
                                            targets.Add(tempFind[2]);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (targets.Count <= 0)
                    {
                        for (int i = 1; i <= 3; i++)
                        {
                            if (owner.row != i)
                            {
                                List<BCharacter> tempFindOther = listFind.Where(x => x.row == i).ToList();
                                tempFindOther = tempFindOther.OrderBy(x => x.col).ToList();
                                if (tempFindOther.Count > 0)
                                {
                                    if (tempFindOther[0].state == BCharacter.State.Alive)
                                    {
                                        targets.Add(tempFindOther[0]);
                                        break;
                                    }
                                    else
                                    {
                                        if (tempFindOther.Count > 1)
                                        {
                                            if (tempFindOther[1].state == BCharacter.State.Alive)
                                            {
                                                targets.Add(tempFindOther[1]);
                                                break;
                                            }
                                            else
                                            {
                                                if (tempFindOther.Count > 2)
                                                {
                                                    if (tempFindOther[2].state == BCharacter.State.Alive)
                                                    {
                                                        targets.Add(tempFindOther[2]);
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;
                case RangeSkill.FaceRow:
                    List<BCharacter> tempFindFR = listFind.Where(x => x.row == owner.row).ToList();
                    tempFindFR = tempFindFR.OrderBy(x => x.col).ToList();
                    if (tempFindFR.Where(x => x.state == BCharacter.State.Alive).Count() > 0)
                    {
                        targets = tempFindFR;
                    }
                    else
                    {
                        for (int i = 1; i <= 3; i++)
                        {
                            if (owner.row != i)
                            {
                                List<BCharacter> tempFindFROther = listFind.Where(x => x.row == i).ToList();
                                if (tempFindFROther.Where(x => x.state == BCharacter.State.Alive).Count() > 0)
                                {
                                    targets = tempFindFROther;
                                    break;
                                }
                            }
                        }
                    }
                    break;
                case RangeSkill.FrontCol:
                    targets = listFind.Where(x => x.col == 1 && x.state == BCharacter.State.Alive).ToList();
                    if (targets.Count <= 0)
                    {
                        targets = listFind.Where(x => x.col == 2 && x.state == BCharacter.State.Alive).ToList();
                    }
                    if (targets.Count <= 0)
                    {
                        targets = listFind.Where(x => x.col == 3 && x.state == BCharacter.State.Alive).ToList();
                    }
                    break;
                case RangeSkill.MidCol:
                    targets = listFind.Where(x => x.col == 2 && x.state == BCharacter.State.Alive).ToList();
                    if (targets.Count <= 0)
                    {
                        targets = listFind.Where(x => x.col == 1 && x.state == BCharacter.State.Alive).ToList();
                    }
                    if (targets.Count <= 0)
                    {
                        targets = listFind.Where(x => x.col == 3 && x.state == BCharacter.State.Alive).ToList();
                    }
                    break;
                case RangeSkill.RearCol:
                    targets = listFind.Where(x => x.col == 3 && x.state == BCharacter.State.Alive).ToList();
                    if (targets.Count <= 0)
                    {
                        targets = listFind.Where(x => x.col == 2 && x.state == BCharacter.State.Alive).ToList();
                    }
                    if (targets.Count <= 0)
                    {
                        targets = listFind.Where(x => x.col == 1 && x.state == BCharacter.State.Alive).ToList();
                    }
                    break;
                case RangeSkill.Self:
                    targets.Add(owner);
                    break;
                case RangeSkill.Revenger:
                    targets.Add(owner.characterRevenger);
                    break;
            }
            return targets;
        }

        #endregion

        #region Method Support

        public void PrintLog(string message)
        {
            if (logger != null)
            {
                logger.Print(message);
            }
        }

        public double GetTotalDamageTeamA()
        {
            double totalDamage = 0;
            foreach (var mainChar in charactersA)
            {
                totalDamage += mainChar.totalDmg;
            }

            foreach (var subChar in charactersAS)
            {
                totalDamage += subChar.totalDmg;
            }
            return totalDamage;
        }

        public double GetTotalDamageTeamB()
        {
            double totalDamage = 0;
            foreach (var mainChar in charactersB)
            {
                totalDamage += mainChar.totalDmg;
            }

            foreach (var subChar in charactersBS)
            {
                totalDamage += subChar.totalDmg;
            }
            return totalDamage;
        }

        public void AddTurnUltimate(string id, string tagTeam)
        {
            BCharacter bCharacter = characters.Where(x => x.id.Equals(id)).FirstOrDefault();
            int indexSkillUltimate = bCharacter.IndexUltimateSkill();

            if (indexSkillUltimate > -1)
                bCharacter.coolDown[indexSkillUltimate] = bCharacter.CurrentSkillUltimate().info.cooldown;

            if (bCharacter.IndexUltimateSkill() > 0 && !bCharacter.affController.GetAffliction(Affliction.CamChieu).IsStart()
                || !bCharacter.affController.GetAffliction(Affliction.KhieuKhich).IsStart())
            {
                bCharacter.isUltimate = true;
                turns.Insert(1, bCharacter);
                turns[0].CallViewerChangeTurn(GetTurnId());
            }
        }

        public void AddPassiveSkill(string id, string tagTeam)
        {
            BCharacter bCharacter = characters.Where(x => x.id.Equals(id)).FirstOrDefault();

            bCharacter.coolDownPassive = bCharacter.passiveSkill1.info.cooldown;

            if (!bCharacter.affController.GetAffliction(Affliction.CamChieu).IsStart())
            {
                bCharacter.isPassive = true;
                turns.Insert(1, bCharacter);
                turns[0].CallViewerChangeTurn(GetTurnId());
                //                bCharacter.curPassiveSkill = TypePassiveSkill.WaitSkill;
            }
        }

        public string[] GetTurnId()
        {
            string[] ids = new string[turns.Count];
            for (int i = 0; i < turns.Count; i++)
            {
                ids[i] = turns[i].id;
            }
            return ids;
        }

        public int[] GetFormation(List<BCharacter> chars)
        {
            int[] formation = new int[chars.Count];
            for (int i = 0; i < formation.Length; i++)
            {
                formation[i] = chars[i].calculator.idInStatic;
            }
            return formation;
        }

        #endregion

        #region Sub Team

        public void ChangeSubChar(BCharacter sCharacter, Battle battle, bool isTeamA)
        {

            if (isTeamA)
            {
                int index = characters.FindIndex(a => a.id == sCharacter.id && a.tagTeam.Equals("A"));
                int indInListChar = battle.charactersA.FindIndex(a => a.id == sCharacter.id);
                if (indInListChar != -1 &&
                    battle.charactersAS.Count > 0 &&
                    battle.curCharSubA <= (battle.charactersAS.Count - 1))
                {
                    SetColRow(battle.charactersA[indInListChar], battle.charactersAS[battle.curCharSubA]);
                    battle.charactersA[indInListChar] = battle.charactersAS[battle.curCharSubA];
                    battle.charactersA[indInListChar].state = BCharacter.State.Alive;
                    battle.charactersA[indInListChar].ProcessInit();
                    battle.characters[index] = battle.charactersAS[battle.curCharSubA];
                    battle.curCharSubA++;
                    turns = new List<BCharacter>(characters);

                }
            }
            else
            {
                int index = characters.FindIndex(a => a.id == sCharacter.id && a.tagTeam.Equals("B"));
                int indInListChar = battle.charactersB.FindIndex(a => a.id == sCharacter.id);
                if (indInListChar != -1 &&
                    battle.charactersBS.Count > 0 &&
                    battle.curCharSubB <= (battle.charactersBS.Count - 1))
                {
                    SetColRow(charactersB[indInListChar], battle.charactersBS[battle.curCharSubB]);
                    battle.charactersB[indInListChar] = battle.charactersBS[battle.curCharSubB];
                    battle.charactersB[indInListChar].state = BCharacter.State.Alive;
                    battle.charactersB[indInListChar].ProcessInit();
                    battle.characters[index] = battle.charactersBS[battle.curCharSubB];
                    battle.curCharSubB++;
                    turns = new List<BCharacter>(characters);
                }
            }

        }

        void SetColRow(BCharacter curChar, BCharacter tagChar)
        {
            tagChar.col = curChar.col;
            tagChar.row = curChar.row;
        }

        #endregion

        #region Res TypeElement Caculator

        int ResTypeElement(TypeElement charType, TypeElement targetType)
        {
            if (charType == TypeElement.Kim && targetType == TypeElement.Moc)
                return 1;
            if (charType == TypeElement.Moc && targetType == TypeElement.Kim)
                return -1;

            if (charType == TypeElement.Moc && targetType == TypeElement.Thuy)
                return 1;
            if (charType == TypeElement.Thuy && targetType == TypeElement.Moc)
                return -1;

            if (charType == TypeElement.Thuy && targetType == TypeElement.Hoa)
                return 1;
            if (charType == TypeElement.Hoa && targetType == TypeElement.Thuy)
                return -1;

            if (charType == TypeElement.Hoa && targetType == TypeElement.Tho)
                return 1;
            if (charType == TypeElement.Tho && targetType == TypeElement.Hoa)
                return -1;

            if (charType == TypeElement.Tho && targetType == TypeElement.Kim)
                return 1;
            if (charType == TypeElement.Kim && targetType == TypeElement.Tho)
                return -1;

            return 0;

        }

        public float ResNguHanh(BCharacter attackerCharacter, BCharacter targetCharacter)
        {
            if (attackerCharacter.typeElement == TypeElement.Kim)
                return targetCharacter.calculator.GetAttribute(CharacterAttribute.ResKim);

            if (attackerCharacter.typeElement == TypeElement.Moc)
                return targetCharacter.calculator.GetAttribute(CharacterAttribute.ResMoc);

            if (attackerCharacter.typeElement == TypeElement.Thuy)
                return targetCharacter.calculator.GetAttribute(CharacterAttribute.ResThuy);

            if (attackerCharacter.typeElement == TypeElement.Hoa)
                return targetCharacter.calculator.GetAttribute(CharacterAttribute.ResHoa);

            if (attackerCharacter.typeElement == TypeElement.Tho)
                return targetCharacter.calculator.GetAttribute(CharacterAttribute.ResTho);

            return 1;
        }

        public float DamageResTypeElement(TypeElement charType, TypeElement targetType, float resHe)
        {
            int typeRes = ResTypeElement(charType, targetType);

            if (typeRes == 1)
                return 1 + resHe / 100;

            if (typeRes == -1)
                return 1 - resHe / 100;

            return 1;
        }

        #endregion

    }
}
