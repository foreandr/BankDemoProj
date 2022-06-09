/*
 * Program:         PasswordManager.exe
 * Module:          PasswordManager.cs
 * Date:            June 7
 * Author:          Andre Foreman
 * Description:     Some free starting code for INFO-3138 project 1, the Password Manager
 *                  application. All it does so far is demonstrate how to obtain the system date 
 *                  and how to use the PasswordTester class provided.
 */

// NOTE, I COULD NOT FIGURE OUT HOW TO HAVE THE JSONS IN ONE FILE, I KEPT GETTING SCHEMA ERRORS.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;            // File class
using Newtonsoft.Json; // JsonConvert class
using Newtonsoft.Json.Schema; // JSchema class
using Newtonsoft.Json.Linq;
namespace PasswordManager
{
    class Program
    {

        static void Main(string[] args)
        {
            Helper my_helper = new Helper();

            // my_helper.print_stuff();
            string path = "C:/Users/forea/Downloads/Project 1 Starting Code (revised)/PasswordManager/PasswordManager/JSONFILES/";
            string data_text = System.IO.File.ReadAllText(path + "demo_data.json");     // CHANGE THIS TO BE USER INPUT TO VALIDATE
            string data_schema = System.IO.File.ReadAllText(path + "demo_schema.json"); //
            // string muti_demo = System.IO.File.ReadAllText(path + "muti_demo.json"); // 

            List<Account> accounts = new List<Account>();


            // CHECKING ADD
            Account demo_account = my_helper.create_demo_account(data_text, data_schema);
            accounts.Add(demo_account);
            
            my_helper.print_accounts(accounts);

            bool loop_holder = true;
            string chosen_option = "";
            while (loop_holder)
            {
                chosen_option = my_helper.introduction_menu();
                if (chosen_option == "0")
                {
                    Console.WriteLine("[0] Quit");
                    Console.WriteLine("Thanks for playin");
                    Environment.Exit(0);
                }
                else if (chosen_option == "1")
                {
                    Console.WriteLine("[1] List all fields for a user");
                    my_helper.print_accounts(accounts); // this may need to change
                    my_helper.write_to_file(path, accounts);
                }
                else if (chosen_option == "2")
                {
                    Console.WriteLine("[2] Create User");
                    my_helper.print_accounts(accounts); // this may need to change
                    Account test_account1 = my_helper.create_account(data_schema);
                    accounts.Add(test_account1);
                    my_helper.write_to_file(path, accounts);
                }
                else if (chosen_option == "3")
                {
                    Console.WriteLine("[3] Remove User");
                    Console.WriteLine("Choose a user to remove");
                    string chosen_user = Console.ReadLine();
                    //chosen_user = "foreandr";
                    accounts = my_helper.delete_account(chosen_user, accounts);
                    my_helper.print_accounts(accounts); // this may need to change
                    my_helper.write_to_file(path, accounts);
                }
                else if (chosen_option == "4")
                {
                    Console.WriteLine("[4] Update Password");
                    Console.WriteLine("Choose a user to update password");
                    string chosen_user = Console.ReadLine();
                    //chosen_user = "foreandr";
                    my_helper.update_password("foreandr", accounts);
                    my_helper.print_accounts(accounts);
                    my_helper.write_to_file(path, accounts);

                }
                else if (chosen_option == "5")
                {
                    Console.WriteLine("[5] Update Anything");
                    Console.WriteLine("Choose a user to update");
                    string chosen_user = Console.ReadLine();
                    //chosen_user = "foreandr";
                    my_helper.update_account(chosen_user, accounts);
                    my_helper.write_to_file(path, accounts);
                }
            }
            
           

        }

    } // end class
}
