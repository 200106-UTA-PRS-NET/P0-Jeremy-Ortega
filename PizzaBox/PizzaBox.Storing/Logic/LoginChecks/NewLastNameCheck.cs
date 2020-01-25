using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PizzaBox.Storing.Logic.LoginChecks
{
    class NewLastNameCheck
    {
        public static string NewLastNameChecker()
        {
            string namePattern = RegexAndLoginExpressions.nameRegex();
            Match rxLname = Regex.Match("", namePattern);
            string lname="";
            while (!rxLname.Success)
            {
                // Last Name
                Console.Clear();
                Console.WriteLine("\n ---- last name up to 15 characters ----");
                RegexAndLoginExpressions.quitPrompt();
                lname = Console.ReadLine();
                if (lname.Equals("quit"))
                {
                    return "quit";
                }
                rxLname = Regex.Match(lname, namePattern);
            }
            return lname;
        }
    }
}
