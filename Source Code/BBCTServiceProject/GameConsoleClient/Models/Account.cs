
namespace GameConsoleClient.Models
{
    public class Account
    {
        public Account(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

    }
}
