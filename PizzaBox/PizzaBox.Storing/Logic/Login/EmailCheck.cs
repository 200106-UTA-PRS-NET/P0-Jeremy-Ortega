using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PizzaBox.Storing.Logic.LoginChecks

{
    class EmailCheck
    {
        public static string NewEmailChecker()
        {
            string emailChk = RegexAndLoginExpressions.emailRegex();
            Match mxEmail = Regex.Match("", emailChk);
            string email = "";
            while (!mxEmail.Success)
            {
                // Email
                Console.Clear();
                Console.WriteLine("\n  ---- email ----");
                RegexAndLoginExpressions.quitPrompt();
                email = Console.ReadLine();
                if (email.Equals("quit"))
                {
                    return "quit";
                }
                mxEmail = Regex.Match(email, emailChk);
            }
            return email;
        }
    }
}
