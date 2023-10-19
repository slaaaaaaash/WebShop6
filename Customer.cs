﻿using System.Buffers;
using System.Text;

namespace WebShop6
{
    public class Customer
    {
        public string Username;
        public string Password;

        public Customer(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public static void ShowCustomerList()
        {
            string[] customers = File.ReadAllLines("../../../Customers.csv");
            Console.Clear();
            Console.WriteLine("Customer List");
            Console.WriteLine();
            Console.WriteLine("Username\n\n");
            foreach (string customer in customers)
            {
                string[] splitCustomer = customer.Split(",");
                Console.WriteLine(splitCustomer[0]);
            }
            Console.WriteLine("\n\n");
        }

        public static string ValidateUsername()
        {
            string[] customers = File.ReadAllLines("../../../Customers.csv");
            bool validInput;
            string? user;
            do
            {
                validInput = false;
                Console.Clear();
                ShowCustomerList();
                Console.WriteLine("Write the username of the customer you want edit\n\n");
                user = Console.ReadLine();
                foreach (string customer in customers)
                {
                    string[] customerSplit = customer.Split(",");
                    if (customerSplit[0] == user)
                    {
                        validInput = true;
                    }
                }
                if (!validInput)
                {
                    Console.WriteLine("User does not exist, try again");
                    Thread.Sleep(1000);
                }
            } while (!validInput);
            return user;
        }

        public static void DisplayCustomerInfo(string user)
        {
            string[] customers = File.ReadAllLines("../../../Customers.csv");
            Console.Clear();
            Console.WriteLine("Customer Info for : " + user);
            Console.WriteLine();
            Console.WriteLine(String.Format("{0,-15} {1,20}\n", "Username", "Passwod"));
            foreach (string customer in customers)
            {
                string[] splitCustomer = customer.Split(",");
                if (splitCustomer[0] == user)
                {
                    Console.WriteLine(String.Format("{0,-15} {1,20:N0}", splitCustomer[0], splitCustomer[1]));
                }
            }
            Console.WriteLine("\n\n");
            Console.WriteLine("1. Edit username");
            Console.WriteLine("2. Edit password");
            Console.WriteLine("0. Exit");
        }

        public static string EditUsername(string username)
        {
            string[] customers = File.ReadAllLines("../../../Customers.csv");
            List<string> customerList = new List<string>();
            bool uniqueUser;
            string? uniqueName = string.Empty;
            string? newUsername = string.Empty;
            do
            {
                uniqueUser = true;
                Console.Clear();
                Console.WriteLine("Enter new username");
                newUsername = Console.ReadLine();

                foreach (string customer in customers)
                {
                    string[] customerSplit = customer.Split(",");
                    if (customerSplit[0] == newUsername)
                    {
                        uniqueUser = false;
                    }
                }
                if (!uniqueUser)
                {
                    Console.WriteLine("Username already exists.");
                    Thread.Sleep(1000);
                }
                else
                {
                    uniqueName = newUsername;
                }
            } while (!uniqueUser);

            foreach (string customer in customers)
            {
                string[] customerSplit = customer.Split(",");
                if (customerSplit[0] == username)
                {
                    customerSplit[0] = uniqueName;
                }
                customerList.Add(customerSplit[0] + "," + customerSplit[1]);
            }
            File.WriteAllLines("../../../Customers.csv", customerList);
            return newUsername;
        }
        public static void EditPassword(string username)
        {
            string[] customers = File.ReadAllLines("../../../Customers.csv");
            List<string> customerList = new List<string>();
            Console.Clear();
            Console.WriteLine("Enter new password");
            string? newPassword = Console.ReadLine();

            foreach (string customer in customers)
            {
                string[] customerSplit = customer.Split(",");
                if (customerSplit[0] == username)
                {
                    customerSplit[1] = newPassword;
                }
                customerList.Add(customerSplit[0] + "," + customerSplit[1]);
            }
            File.WriteAllLines("../../../Customers.csv", customerList);
        }
    }
}