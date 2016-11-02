
namespace BattleSimulator
{
    public class DataInputBattle
    {
        public enum Mode : int
        {
            Normal = 1,
            Boss = 2,
        }
        public Mode mode = Mode.Normal;

        public TeamParameter teamA { get; set; }

        public TeamParameter teamB { get; set; }

        //public TeamParameter teamAS { get; set; }

        //public TeamParameter teamBS { get; set; }

        public int idBackground;


        public DataInputBattle()
        {
            
            
        }
    }
}
