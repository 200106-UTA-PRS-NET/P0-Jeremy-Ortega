using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PizzaBox.Storing.Logic.LoginChecks
{
    class PassCheck
    {
        public static string NewPassChecker()
        {
            // password
            string passCheck = RegexAndLoginExpressions.passRegex();

            // phone pattern complete
            string password = "";
            Match rxPass = Regex.Match("", passCheck);
            while (!rxPass.Success)
            {
                // First Name
                Console.Clear();
                Console.WriteLine("\n ---- password ----");
                RegexAndLoginExpressions.quitPrompt();
                password = Console.ReadLine();
                if (password.Equals("quit"))
                {
                    return "quit";
                }
                rxPass = Regex.Match(password, passCheck);
            }
            return password;
        }
    }
}
