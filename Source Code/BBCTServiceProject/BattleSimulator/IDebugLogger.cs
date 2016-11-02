using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleSimulator
{
    public interface IDebugLogger
    {
        void Print(string message);
    }
}
