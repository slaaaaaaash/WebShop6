Console.WriteLine("Welcome to the Time-travelling Feline");

registerNewUser();


void registerNewUser()
{
    bool freshUser = true;
    bool PassCheck = false;
    string newPass, newUser, tempPass;
    if (freshUser = true)
    {
        Console.Write("Please enter Username: ");
        newUser = Console.ReadLine();
        Console.Write("Please enter a secure password: ");
        newPass = Console.ReadLine();
        Console.Write("Plase enter your password one more time: ");
        tempPass = Console.ReadLine();
        {
            if (newPass == tempPass)
            {
                PassCheck = true;
            }
            else if (newPass != tempPass)
            {
                Console.Write("WRONG! Please reenter your password: ");
                tempPass = Console.ReadLine();
            }

            string[] userAndPass = { newUser + ", " + newPass };
            File.AppendAllLines("../../../newUser.csv", userAndPass);
        }

    }
}