
namespace GameConsoleClient.Helpers.FEnum
{
    public class CommonEnum
    {
        public enum Action : int
        {
            None = -1,
            EndProgram = 0,
            Move = 1,
            AttackMap = 2,
            Random = 3,
        }

        public enum STATUS : int
        {
            SUCCESS = 1,
            SERVER_EXCEPTION = 2,
            INVALID_DATA = 3,
            USER_EXIST = 4,
            WRONG_PASSORD = 5,
            USER_DOES_NOT_EXSIT = 6
        }

        public enum BOOL : int
        {
            TRUE = 1,
            FALSE = 2
        }
    }
}
