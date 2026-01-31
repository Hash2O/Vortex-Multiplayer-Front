public static class AuthService
{
    public static bool Login(string login, string password)
    {
        // Simulation backend
        return login == "user" && password == "1234";
    }
}

