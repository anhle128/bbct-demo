﻿using System.Collections.Generic;

namespace BattleSimulator
{
    public class TeamParameter
    {
        public int level { get; set; }
        public List<CharacterParameter> mainChars { get; set; }
        public List<CharacterParameter> subChars { get; set; }

        public TeamParameter()
        {

        }
    }
}
