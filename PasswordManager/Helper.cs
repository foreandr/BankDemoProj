using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.IO;
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
                Console.WriteLine("INVALID: Error in account creation, no account created");
                new_account.wipe_account();
                return new_account;

            }
            else
            {
                Console.WriteLine("VALID: Account created");

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
                Console.WriteLine("INVALID: Error in account creation, no account created");
                account.wipe_account();
                return account;

            }
            else
            {
                Console.WriteLine("VALID: Account created");

                // CHECK VALIDATE ACCOUNT
                return account;
            }

        }
        public List<Account> create_multi_demo_account(string data_string, string schema)
        {
            List<Account> accounts = new List<Account>();


            //JObject data = JObject.Parse(data_string);

            Environment.Exit(0);


            return accounts;
        }
        public List<Account> delete_account(string wanted_user_id, List<Account> accounts)
        {
            Console.WriteLine("\nCHECKING DELETE");

            Account wanted_account = new Account();
            //wanted_user_id = "foreandr";
          
            foreach (Account account in accounts.ToList())
            {
                if (account.UserId == wanted_user_id)
                {
                    wanted_account = account;
                }
                // exists validation
                if (wanted_account.Description == "")
                {
                    Console.WriteLine("\nUSER DOES NOT EXIST, RETURNING TO MAIN");
                    return accounts;
                }
                accounts.Remove(wanted_account);
            }
            return accounts;
        }
        public List<Account> update_account(string wanted_user_id, List<Account> accounts)
        {
            Console.WriteLine("\nCHECKING UPDATE");
            Account wanted_account = new Account();
            bool loop_holder = true;
            foreach (Account account in accounts.ToList())
            {
                if (account.UserId == wanted_user_id)
                {
                    wanted_account = account;
                }
            }

            // exists validation
            if (wanted_account.Description == "")
            {
                Console.WriteLine("\nUSER DOES NOT EXIST, RETURNING TO MAIN");
                return accounts;
            }
            
            while (true)
            {
                
                Console.WriteLine("Pick the number that corresponds to what you want to edit:");
                Console.WriteLine("[1] Description");
                Console.WriteLine("[2] UserId");
                Console.WriteLine("[3] LoginUrl");
                Console.WriteLine("[4] AccountNum");
                Console.WriteLine("[5] Password");
                Console.WriteLine("[6] EXIT UPDATE\n");

                string wanted_change = Console.ReadLine();
                switch (wanted_change)
                {
                    case "1":
                        Console.WriteLine("Change the DESCRPTION to :");
                        string wanted_desc = Console.ReadLine();
                        wanted_account.Description = wanted_desc;
                        break;
                    case "2":
                        Console.WriteLine("Change the UserId to :");
                        string wanted_UserId = Console.ReadLine();
                        wanted_account.UserId = wanted_UserId;
                        break;
                    case "3":
                        Console.WriteLine("Change the LoginUrl to :");
                        string wanted_LoginUrl = Console.ReadLine();
                        wanted_account.LoginUrl = wanted_LoginUrl;
                        break;
                    case "4":
                        Console.WriteLine("Change the AccountNum to :");
                        string wantedAccountNum = Console.ReadLine();
                        wanted_account.AccountNum = wantedAccountNum;
                        break;
                    case "5":
                        string wanted_Password = get_password();
                        wanted_account.Password = wanted_Password;
                        break;
                    case "6":
                        Console.WriteLine("EXITING OUT OF UPDATE:");
                        loop_holder = false;
                        return accounts;
                    default:
                        Console.WriteLine();
                        break;
                }
            }
            
        }
        public List<Account> update_password(string wanted_user_id, List<Account> accounts)
        {
            Account wanted_account = new Account();
            foreach (Account account in accounts.ToList())
            {
                if (account.UserId == wanted_user_id)
                {
                    wanted_account = account;
                }

            }
            // exists validation
            if (wanted_account.Description == "")
            {
                Console.WriteLine("\nUSER DOES NOT EXIST, RETURNING TO MAIN");
                return accounts;
            }

            Console.WriteLine("UPDATING PASSWORD");
            string wanted_change = get_password();
            wanted_account.Password = wanted_change;
            return accounts;
        }
        public void write_to_file(string path, List<Account> accounts)
        {
            foreach (Account account in accounts)
            {
                string data = (string)account.convert_to_string();               
                File.WriteAllText(path + account.AccountNum + ".json", data);
            }
        }
        public string introduction_menu()
        {

            Console.WriteLine("\nWELCOME TO ANDRE'S PROJECT");
            Console.WriteLine("Pick your option");
            Console.WriteLine("[1] List all fields for a user");
            Console.WriteLine("[2] Create User");
            Console.WriteLine("[3] Remove User");
            Console.WriteLine("[4] Update Password");
            Console.WriteLine("[5] Update Anything");
            Console.WriteLine("[0] Quit");


            string chosen_option = Console.ReadLine();
            return chosen_option;      
        }
    }
}

/*
public List<Account> add_account(List<Account> accounts, Account account)
{
    return accounts;
}
*/