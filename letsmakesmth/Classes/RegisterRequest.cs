namespace letsmakesmth.Classes
{
    public class RegisterRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string Role { set; get; } = "User";
    }
}
