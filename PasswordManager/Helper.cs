using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    public class Helper
    {
        public void print_stuff()
        {
            Console.WriteLine("hello");
        }
        public bool validate_data(string data_schema, string data_text)
        {
            //string path = "C:/Users/forea/Downloads/Project 1 Starting Code (revised)/PasswordManager/PasswordManager/";
            //string data_text = System.IO.File.ReadAllText(path + "demo_data.json");
            Console.WriteLine(data_text);
            
           // string data_schema = System.IO.File.ReadAllText(path + "demo_schema.json");
            //Console.WriteLine(data_schema);
            
            JSchema schema = JSchema.Parse(data_schema);
            JObject team = JObject.Parse(data_text);

            bool isValid = team.IsValid(schema);
            //Console.WriteLine(isValid);
            return isValid;

        }
        public string get_password()
        {
            // System date demonstration          
            DateTime dateNow = DateTime.Now;
            Console.Write("PASSWORD MANAGEMENT SYSTEM (STARTING CODE), " + dateNow.ToShortDateString());
            bool done;
            do
            {
                Console.Write("\n\nEnter a password: ");
                string pwText = Console.ReadLine();

                try
                {
                    // PasswordTester class demonstration
                    PasswordTester pw = new PasswordTester(pwText);
                    Console.WriteLine("That password is " + pw.StrengthLabel);
                    Console.WriteLine("That password has a strength of " + pw.StrengthPercent + "%");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("ERROR: Invalid password format");
                }

                Console.Write("\nTest another password? (y/n): ");
                done = Console.ReadKey().KeyChar != 'y';
                if (done == true) {
                    Console.WriteLine("\n");
                    return pwText;
                }
                

            } while (!done);return "";
        }
        public Account create_account(string schema)
        {

            Console.Write("Creating an Account:");
            Account new_account = new Account();

            Console.Write("\nEnter a Description: ");
            new_account.Description = Console.ReadLine();

            Console.Write("Enter a UserId: ");
            new_account.UserId = Console.ReadLine();

            Console.Write("Enter a LoginUrl: ");
            new_account.LoginUrl = Console.ReadLine();

            Console.Write("Enter a AccountNum: ");
            new_account.AccountNum = Console.ReadLine();

            Console.Write("Enter a Password: ");
            new_account.Password = get_password();


            JObject new_data = new_account.convert_to_json();
            JSchema schema_for_test = JSchema.Parse(schema);

            bool isValid = new_data.IsValid(schema_for_test);
            
            //Console.WriteLine(isValid);
            if (!isValid)
            {
                Console.WriteLine("Error in account creation, no account created");
                new_account.wipe_account();
                return new_account;

            }
            else
            {
                Console.WriteLine("Account created");

                // CHECK VALIDATE ACCOUNT
                return new_account;
            }
        }
        public void print_accounts(List<Account> accounts)
        {
            foreach (Account account in accounts)
            {
                Console.WriteLine("\nAccount:-----: [" + account.UserId + "]");
                Console.WriteLine(account.Description);
                Console.WriteLine(account.UserId);
                Console.WriteLine(account.LoginUrl);
                Console.WriteLine(account.AccountNum);
                Console.WriteLine(account.Password);
                Console.WriteLine("---------------------\n");
            }

        }
        public Account create_demo_account(string data_string, string schema)
        {
            Account account = new Account();

            //Console.WriteLine(data);
            JObject data = JObject.Parse(data_string);
            
            //Console.WriteLine(data["properties"]["Description"]);
            //Console.WriteLine(data["properties"]["UserId"]);
            //Console.WriteLine(data["properties"]["LoginUrl"]);
            //Console.WriteLine(data["properties"]["AccountNum"]);
            //Console.WriteLine(data["properties"]["Password"]);

            account.Description = (string)data["properties"]["Description"];
            account.UserId = (string)data["properties"]["UserId"];
            account.LoginUrl = (string)data["properties"]["LoginUrl"];
            account.AccountNum = (string)data["properties"]["AccountNum"];
            account.Password = (string)data["properties"]["Password"];


            
            JObject new_data = account.convert_to_json();
            
            JSchema schema_for_test = JSchema.Parse(schema);

            bool isValid = new_data.IsValid(schema_for_test);
            //Console.WriteLine(isValid);
            if (!isValid)
            {
                Console.WriteLine("Error in account creation, no account created");
                account.wipe_account();
                return account;

            }
            else
            {
                Console.WriteLine("Account created");

                // CHECK VALIDATE ACCOUNT
                return account;
            }

        }

    }
}

/*
public List<Account> add_account(List<Account> accounts, Account account)
{
    return accounts;
}
*/