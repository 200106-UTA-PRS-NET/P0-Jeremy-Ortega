using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PizzaBox.Storing.Logic.LoginChecks
{
    class NewPhoneCheck
    {
        public static string NewPhoneChecker()
        {
            // phone pattern complete
            string phonePattern = RegexAndLoginExpressions.phoneRegex();
            Match rxPhone = Regex.Match("", phonePattern);
            string phone = "";
            while (!rxPhone.Success)
            {
                // Phone Number
                Console.Clear();
                Console.WriteLine("\n ---- Phone 10 digits not starting with 0 ----");
                RegexAndLoginExpressions.quitPrompt();
                phone = Console.ReadLine();
                if (phone.Equals("quit"))
                {
                    return "quit";
                }
                rxPhone = Regex.Match(phone, phonePattern);
                phone = Regex.Replace(phone, "[/-]", "");
                if (phone.StartsWith("0"))
                {
                    rxPhone = Regex.Match("123", phonePattern);
                }
            }
            phone = Regex.Replace(phone, "[/-]", "");
            return phone;
        }
    }
}
