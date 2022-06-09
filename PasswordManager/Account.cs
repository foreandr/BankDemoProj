using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json; // JsonConvert class
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema; // JSchema class
namespace PasswordManager
{
    public class Account
    {
        public string Description = "";
        public string UserId;
        public string LoginUrl;
        public string AccountNum;
        public string Password;

        
        public JObject convert_to_json()
        {
            string test_string = string.Format("{{\n\t\"properties\": {{\n\t\t\"Description\": \"{0}\",\n\t\t\"UserId\": \"{1}\",\n\t\t\"LoginUrl\": \"{2}\",\n\t\t\"AccountNum\": \"{3}\",\n\t\t\"Password\": \"{4}\"\n\t}}\n}}", Description, UserId, LoginUrl, AccountNum, Password);
            //string test_string = "";
            //Console.WriteLine(test_string);
            
            JObject data = JObject.Parse(test_string);
            return data;
        }
        public string convert_to_string()
        {
            string test_string = string.Format("{{\n\t\"properties\": {{\n\t\t\"Description\": \"{0}\",\n\t\t\"UserId\": \"{1}\",\n\t\t\"LoginUrl\": \"{2}\",\n\t\t\"AccountNum\": \"{3}\",\n\t\t\"Password\": \"{4}\"\n\t}}\n}}", Description, UserId, LoginUrl, AccountNum, Password);

            return test_string;
        }

        public void wipe_account()
        {
            Description = "";
            UserId = "";
            LoginUrl = "";
            AccountNum = "";
            Password = "";
        }
        
    }


}
