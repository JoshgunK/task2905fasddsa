using System.Text.RegularExpressions;

public class User : IAccount
{
    private static int _idCounter = 0;
    public int Id { get; }
    public string Fullname { get; set; }
    public string Email { get; set; }
    private string _password;

    public string Password
    {
        get => _password;
        set
        {
            if (PasswordChecker(value))
                _password = value;
            else
                throw new ArgumentException("Password does not match requirements.");
        }
    }

    public User(string fullname, string email, string password)
    {
        Id = ++_idCounter;
        Fullname = fullname;
        Email = email;
        Password = password;
    }

    public bool PasswordChecker(string password)
    {
        if (password.Length < 8) return false;
        if (!Regex.IsMatch(password, @"[A-Z]")) return false;
        if (!Regex.IsMatch(password, @"[a-z]")) return false;
        if (!Regex.IsMatch(password, @"\d")) return false;
        return true;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Id: {Id}, Fullname: {Fullname}, Email: {Email}");
    }
}
