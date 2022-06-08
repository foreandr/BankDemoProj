/*
 * Program:         PasswordManager.exe
 * Module:          PasswordManager.cs
 * Date:            June 7
 * Author:          Andre Foreman
 * Description:     Some free starting code for INFO-3138 project 1, the Password Manager
 *                  application. All it does so far is demonstrate how to obtain the system date 
 *                  and how to use the PasswordTester class provided.
 */

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
            string path = "C:/Users/forea/Downloads/Project 1 Starting Code (revised)/PasswordManager/PasswordManager/";
            string data_text = System.IO.File.ReadAllText(path + "demo_data.json"); // CHANGE THIS TO BE USER INPUT TO VALIDATE
            string data_schema = System.IO.File.ReadAllText(path + "demo_schema.json");

            List<Account> accounts = new List<Account>();

            Account demo_account = my_helper.create_demo_account(data_text, data_schema);
            Account test_account1 = my_helper.create_account(data_schema);
            accounts.Add(demo_account);
            accounts.Add(test_account1);

            //Account test_account1 = my_helper.create_account();
            //Account test_account2 = my_helper.create_account();
            //Console.WriteLine(test_account1.AccountNum);

            //accounts.Add(test_account1);
            //accounts.Add(test_account2);

            my_helper.print_accounts(accounts);

            // bool answer = my_helper.validate_data(data_schema, data_text);
            // Console.WriteLine(answer);

        }
        
    } // end class
}
