using WebShop6;

string? UserName;
string? UserPassword;
bool validInput = false;

do
{
    validInput = true;
    Console.Clear();
    Console.WriteLine("Welcome to the time-travelling Feline!");
    Console.WriteLine();
    Console.WriteLine("Please enter username and password to log in:");
    Console.Write("username: ");
    UserName = Console.ReadLine();
    if (UserName.Length <= 0)
    {
        Console.WriteLine();
        Console.WriteLine("Please make sure you've actually entered a username.");
        Console.WriteLine("Press any key to try again");
        Console.ReadKey();
        Console.Clear();
        validInput = false;
    }
    else
    {
        Console.Write("Password: ");
        UserPassword = Login.MaskedPass();
        Console.WriteLine();
        if (UserPassword.Length <= 0 || UserName.Length <= 0)
        {
            Console.WriteLine();
            Console.WriteLine("Please make sure you've actually entered a password.");
            Console.WriteLine("Press any key to try again");
            Console.ReadKey();
            Console.Clear();
            validInput = false;
        }
    }
} while (!validInput);

Console.WriteLine(Login.ValidateUsername(UserName));

