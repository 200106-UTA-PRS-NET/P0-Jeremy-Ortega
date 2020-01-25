using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing.Logic.LoginChecks
{
    class RegexAndLoginExpressions
    {
        public static string emailRegex()
        {
            return @"^[a-zA-Z0-9_]{1,15}[@][a-zA-Z0-9_]{1,15}[.][a-zA-Z]{2,3}$";
        }
        public static string nameRegex()
        {
            return @"^[a-zA-Z]{1,15}$";
        }
        public static string passRegex()
        {
            return @"^[a-zA-Z0-9_]{1,15}$";
        }
        public static string phoneRegex()
        {
            return @"^[0-9]{3}[\-]?[0-9]{3}[\-]?[0-9]{4}$";
        }
        public static void quitPrompt()
        {
            Console.WriteLine(" ---- type \'quit\' to quit ----");
        }
        public static bool safeWord(string check)
        {
            return check.Equals("quit");
        }
    }
}
