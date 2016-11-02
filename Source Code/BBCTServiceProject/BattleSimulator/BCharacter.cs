using DynamicDBModel.Models.Battle;
using StaticDB.Enum;
using System.Collections.Generic;

namespace BattleSimulator
{
    public class BCharacter
    {
        #region Properties
        public string id;
        public enum State
        {
            Alive,
            Die,
        }
        public State state;
        public Battle battle;
        public CharacterCalculator calculator;
        public bool isUltimate;
        public bool isPassive;
        public string tagTeam;
        public int col;
        public int row;
        public bool isMainTeam;
        public TypeElement typeElement;

        public float hp;
        public SkillCalculator normalSkill;
        public SkillCalculator[] ultimateSkill;
        public SkillCalculator passiveSkill1;
        public ICharacterViewer viewer;

        public BAfflictionController affController;

        public CharacterParameter characterParameter;

        public float totalDmg;

        public List<int> coolDown;
        public int coolDownPassive;

        public BCharacter characterRevenger;
        #endregion

        public BCharacter(string id, Battle battle, CharacterParameter characterParameter, string tagTeam, bool isMain,
            TypeElement typeElement)
        {
            this.battle = battle;
            this.id = id;
            this.characterParameter = characterParameter;
            this.isMainTeam = isMain;
            this.typeElement = typeElement;

            calculator = new CharacterCalculator();
            calculator.idInStatic = characterParameter.idInStatic;
            calculator.level = characterParameter.level;
            calculator.levelPowerUp = characterParameter.levelPowerUp;
            calculator.star = characterParameter.star;
            calculator.staticDB = battle.staticDB;
            calculator.powerUpItems = characterParameter.powerUpItems;
            calculator.formation = characterParameter.formation;
            calculator.equipments = characterParameter.GetEquipmentsCalculator();

            this.viewer = characterParameter.viewer;
            coolDown = new List<int>();

            calculator.Calculate();
            if (battle.inputBattle.mode == DataInputBattle.Mode.Boss && tagTeam.Equals("B"))
            {
                calculator.SetBaseAttribute(CharacterAttribute.Agi, 0f);
            }

            isUltimate = false;
            this.tagTeam = tagTeam;
            state = State.Alive;

            this.col = characterParameter.colFormation;
            this.row = characterParameter.rowFormation;

            normalSkill = new SkillCalculator(calculator.GetInfo().normalSkill, characterParameter.levelNormalSkill);
            for (int i = 0; i < ultimateSkill.Length; i++)
            {
                int levelSkill = i > 0 ? characterParameter.levelUltimateSkill2 : characterParameter.levelUltimateSkill;
                ultimateSkill[i] = new SkillCalculator(calculator.GetInfo().ultimateSkill[characterParameter.indexSkillUltimate], levelSkill);
            }
            passiveSkill1 = new SkillCalculator(calculator.GetInfo().passiveSkill, characterParameter.levelPassiveSkill1);

            normalSkill.Calculate();
            for (int i = 0; i < ultimateSkill.Length; i++)
            {
                ultimateSkill[i].Calculate();
            }
            passiveSkill1.Calculate();

            affController = new BAfflictionController(this);
            for (int i = 0; i < ultimateSkill.Length; i++)
            {
                coolDown[i] = ultimateSkill[i].info.cooldown;
            }
            coolDownPassive = normalSkill.info.startCooldown;
        }

        #region Action

        public void ProcessInit()
        {
            CalculatePassiveSkillStart(passiveSkill1);

            hp = calculator.GetAttribute(CharacterAttribute.Hp);

            CallViewerAfterCreated();
        }

        #region Passive Skill

        public void CalculatePassiveSkillStart(SkillCalculator skill)
        {
            if (skill.GetAttributes() != null)
            {
                if (skill.info.range == RangeSkill.Self)
                {
                    for (int i = 1; i <= skill.GetAttributes().Length; i++)
                    {
                        calculator.BuffPoint(skill.GetAttributes()[i - 1].attribute, skill.GetAttributes()[i - 1].mod);
                    }
                }
                else if (skill.info.range == RangeSkill.All)
                {
                    foreach (var ch in battle.characters)
                    {
                        if (ch.tagTeam.Equals(tagTeam))
                        {
                            for (int i = 1; i <= skill.GetAttributes().Length; i++)
                            {
                                ch.calculator.BuffPoint(skill.GetAttributes()[i - 1].attribute, skill.GetAttributes()[i - 1].mod);
                            }
                        }
                    }
                }
            }
        }

        #endregion

        public float Attacked(BCharacter attacker, float SkillMod, int category, bool isCrit, bool isBlock, int countTurn)
        {
            if (state == State.Alive)
            {

                float crit = 1f;

                if (isCrit)
                {
                    crit = RandomHelper.RandomFloat(0.9f, 1.1f) + attacker.calculator.GetAttribute(CharacterAttribute.CritModifier) / 100f;
                }
                float mainAtt = (category == (int)CategoryCharacter.Physic) ? attacker.calculator.GetAttribute(CharacterAttribute.Physic) : attacker.calculator.GetAttribute(CharacterAttribute.Magic);

                float constX = (category == (int)CategoryCharacter.Physic) ? battle.staticDB.configs.battleConfig.modX
                    : battle.staticDB.configs.battleConfig.modF;
                float constY = (category == (int)CategoryCharacter.Physic) ? battle.staticDB.configs.battleConfig.modY
                    : battle.staticDB.configs.battleConfig.modU;

                float resKH = battle.ResNguHanh(attacker, this);
                if (resKH > battle.staticDB.configs.characterConfig.maxResKH)
                {
                    resKH = battle.staticDB.configs.characterConfig.maxResKH;
                }

                float dmgResType = (category == (int)CategoryCharacter.Physic) ? 1 :
                    battle.DamageResTypeElement(attacker.typeElement, typeElement, resKH);

                float dmg = constX * (mainAtt - constY * ((category == (int)CategoryCharacter.Physic) ?
                    calculator.GetAttribute(CharacterAttribute.Def) : calculator.GetAttribute(CharacterAttribute.DefOn)) * crit) *
                    dmgResType;


                if (isBlock)
                {
                    dmg -= (dmg * (calculator.GetAttribute(CharacterAttribute.BlockModifier) / 100));
                }

                dmg = dmg / countTurn;

                dmg += RandomHelper.RandomRange(-battle.staticDB.configs.battleConfig.rangeRandomDamage, battle.staticDB.configs.battleConfig.rangeRandomDamage);
                if (dmg <= 0)
                {
                    dmg = 1f;
                }
                if (affController.GetAffliction(Affliction.BatTu).IsStart())
                {
                    dmg = 0f;
                }
                if (affController.GetAffliction(Affliction.DongBang).IsStart())
                {
                    dmg = dmg / 2f;
                }
                if (battle.inputBattle.mode == DataInputBattle.Mode.Boss)
                {
                    if (attacker.tagTeam.Equals("B"))
                    {
                        dmg = calculator.GetAttribute(CharacterAttribute.Hp);
                    }
                }


                attacker.totalDmg += dmg;
                return MinusHP(dmg);
            }
            return 0f;
        }

        public float MinusHP(float dmg)
        {
            if (battle.inputBattle.mode == DataInputBattle.Mode.Boss && tagTeam.Equals("A"))
            {
                dmg = hp;
            }
            hp -= dmg;
            if (hp < 1f)
            {
                hp = 0;
                if (battle.inputBattle.mode == DataInputBattle.Mode.Boss && tagTeam.Equals("B"))
                {
                    hp = 1;
                }
                else
                {
                    state = State.Die;
                    bool isTeamA = tagTeam.Equals("A");
                    battle.ChangeSubChar(this, battle, isTeamA);
                }

            }
            return dmg;
        }

        public float RegenHP(float skillMod)
        {
            float regen = skillMod / 100f * calculator.GetAttribute(CharacterAttribute.Hp);
            return RegenHPByPoint(regen);
        }

        public float RegenHPByPoint(float regen)
        {
            if (affController.GetAffliction(Affliction.CamHoiMau).IsStart())
            {
                regen = 0f;
            }
            hp += regen;
            if (hp > calculator.GetAttribute(CharacterAttribute.Hp))
            {
                hp = calculator.GetAttribute(CharacterAttribute.Hp);
            }
            return regen;
        }

        public void Revive()
        {
            if (state == State.Die)
            {
                state = State.Alive;
                float procHP = passiveSkill1.GetModAttribute();
                hp = calculator.GetAttribute(CharacterAttribute.Hp) * ((100 - procHP) / 100);
            }
        }


        public void ReCooldown(int indexSkill, int countCooldown, EffectSkill eff)
        {
            bool isDegree = eff == EffectSkill.DecreaseCooldown;

            if (countCooldown > 0)
                coolDown[indexSkill] = isDegree ? coolDown[indexSkill] - countCooldown : coolDown[indexSkill] + countCooldown;
            else
                coolDown[indexSkill] = 0;
        }

        public void SetRevengerCharacter(BCharacter characterRev)
        {
            this.characterRevenger = characterRev;
        }

        public void DeleteAffliction(EffectSkill eff)
        {
            bool isBad = eff == EffectSkill.DeleteBadEffect;

            List<Affliction> lAff = ListAffliction(isBad);
            for (int i = 0; i < lAff.Count; i++)
            {
                affController.EndAffliction(lAff[i]);
            }
        }

        List<Affliction> ListAffliction(bool isBad)
        {
            if (isBad)
                return new List<Affliction>()
                {
                    Affliction.DotChay, Affliction.CamChieu, Affliction.DongBang, Affliction.Choang, Affliction.PhaGiap,
                    Affliction.TrungDoc,Affliction.CamHoiMau, Affliction.GiamCong, Affliction.KhieuKhich, Affliction.CamHieuUng,
                };

            return new List<Affliction>()
            {
                Affliction.TangCong, Affliction.BatTu, Affliction.TangGiap, Affliction.BatTu,
                Affliction.TangBao, Affliction.KhienBaoVe, Affliction.KhangHieuUng
            };
        }

        #region cooldown skill
        public bool CanProcSkill()
        {
            return (IndexUltimateSkill() > -1 && !affController.GetAffliction(Affliction.CamChieu).IsStart() && !affController.GetAffliction(Affliction.Choang).IsStart() && !affController.GetAffliction(Affliction.DongBang).IsStart() && !affController.GetAffliction(Affliction.KhieuKhich).IsStart());
        }

        public int IndexUltimateSkill()
        {
            int index = coolDown.FindIndex(a => a <= 0);
            if (index > -1)
                return index;

            return -1;
        }

        public SkillCalculator CurrentSkillUltimate()
        {
            int index = IndexUltimateSkill();
            if (index > -1)
                return ultimateSkill[index];

            return null;
        }

        public bool CanProcSkillPassive()
        {
            return (coolDownPassive <= 0 &&
                !affController.GetAffliction(Affliction.CamChieu).IsStart() &&
                !affController.GetAffliction(Affliction.Choang).IsStart() &&
                !affController.GetAffliction(Affliction.DongBang).IsStart());
        }
        #endregion

        #endregion

        #region Call Viewer

        private void CallViewerAfterCreated()
        {
            if (battle.isGenerateReplay)
            {
                CharacterReplay re = new CharacterReplay();
                re.id = id;
                re.idStatic = calculator.idInStatic;
                re.level = calculator.level;
                re.powerUpLevel = calculator.levelPowerUp;
                re.star = calculator.star;
                re.hpMax = calculator.GetAttribute(CharacterAttribute.Hp);
                re.colFormation = col;
                re.rowFormation = row;
                re.indexUltimate = characterParameter.indexSkillUltimate;
                if (tagTeam.Equals("A"))
                {
                    if (isMainTeam)
                    {
                        battle.replay.teamA.Add(re);

                    }
                    else
                    {
                        battle.replay.teamAS.Add(re);
                    }
                }
                else
                {
                    if (isMainTeam)
                        battle.replay.teamB.Add(re);
                    else
                    {
                        battle.replay.teamBS.Add(re);
                    }
                }
            }
            if (viewer != null)
            {
                viewer.AfterCreated(id, calculator.idInStatic, calculator.level, calculator.levelPowerUp,
                    calculator.star, col, row, calculator.GetAttribute(CharacterAttribute.Hp), characterParameter.indexSkillUltimate);
            }
        }

        public void CallViewerProcessTurn(string idOwner, bool canProcSkill, int typeSkill, List<TargetReplay> targets, float affDmg, int hp, int result)
        {
            if (battle.isGenerateReplay)
            {
                TurnReplay re = new TurnReplay();
                re.idOwner = idOwner;
                re.canProcSkill = canProcSkill;
                re.typeSkill = (TurnReplay.TypeSkillCharacter)typeSkill;
                re.targets = targets;
                re.affDmg = affDmg;
                re.hp = hp;
                re.result = result;
                battle.replay.turns.Add(re);
            }
            if (viewer != null)
            {
                viewer.ProcessTurn(idOwner, canProcSkill, typeSkill, targets, affDmg, hp, result);
            }
        }

        public void CallViewerChangeTurn(string[] ids)
        {
            if (viewer != null)
            {
                viewer.ChangeTurn(ids);
            }
        }

        #endregion

    }
}
