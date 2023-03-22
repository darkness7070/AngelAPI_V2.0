namespace AngelAPI.Models;

public class RequestGeneral
{
    public class Authentication
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
    public class Authorization
    {
        public string Token { get; set; }
    }

    public class Applications
    {
        public string Token { get; set; }
        public bool isAdmin { get; set; }
    }
}