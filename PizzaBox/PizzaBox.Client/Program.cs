using System;

namespace PizzaBox.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            SignIn();
        }



        private static void SignIn()
        {
            int signInChoice = 1;
            while (signInChoice != 0)
            {
                Console.WriteLine("1\tSign In?");
                Console.WriteLine("2\tCreate New Account?");
                Console.WriteLine("0\t<Close Program>");
                signInChoice = Convert.ToInt32(Console.ReadLine());
                if (signInChoice == 1)
                {
                    Console.WriteLine("You Chose 1!");
                    break;
                }
                else if (signInChoice == 2)
                {
                    Console.WriteLine("You chose 2!");
                }
            }
            Console.WriteLine("Thank you come again!");
            System.Threading.Thread.Sleep(3000);
            
        }
    }


    

}
