using System.Runtime.CompilerServices;

namespace WebShop6;
public class Login
{
    public static bool LogInUser()
    {
        string? UserName;
        string? UserPassword;
        bool validInput;
        bool validPassword;
        do
        {
            validPassword = true;
            do
            {
                validInput = true;
                Console.Clear();
                Console.WriteLine("Welcome to the time-travelling Feline!");
                Console.WriteLine();
                Console.WriteLine("Please enter username and password to log in:");
                Console.Write("Username: ");
                UserName = Console.ReadLine();
                Console.Write("Password: ");
                UserPassword = Console.ReadLine();
                if (UserPassword.Length <= 0 || UserName.Length <= 0)
                {
                    Console.WriteLine("Please make sure you've actually entered both a username and a password.");
                    Console.WriteLine("Press any key to try again");
                    Console.ReadKey();
                    Console.Clear();
                    validInput = false;
                }
            } while (!validInput);

            if (ValidateUser(UserName, UserPassword))
            {
                validPassword = true;
            }
            else
            {
                Console.WriteLine("Invalid username or password, press any key to try again");
                Console.ReadKey();
                Console.Clear();
                validPassword = false;
            }
        } while (!validPassword);
        return true;
    }
    private static bool ValidateUser(string username, string password)
    {
        string[] listUsers = File.ReadAllLines("../../../Users.csv");
        bool validLogin = false;
        foreach (string user in listUsers)
        {
            string[] userInfo = user.Split(",");
            string userN = userInfo[0];
            string userP = userInfo[1];
            if(userN == username && userP == password)
            {
                validLogin = true;
            }
            else
            {
               validLogin = false;
            }
        }
        if (validLogin)
        {
            return true;
        }
        else
            return false;
    }
}