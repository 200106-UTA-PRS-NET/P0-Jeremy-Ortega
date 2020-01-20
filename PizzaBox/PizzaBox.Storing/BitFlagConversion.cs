using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBox.Storing
{
    class BitFlagConversion
    {
        public BitFlagConversion(){
        }

        /// <summary>
        /// Converting the binary choices to integer to send over to a database
        /// </summary>
        /// <param name="charArr"></param>
        /// <returns></returns>
        public static int convertFlagArrayToInt(char[] charArr)
        {
            string str = new String(charArr);
            int Out = Convert.ToInt32(str, 2);
            return Out;
        }

        /// <summary>
        /// convert from int from the database to array of char "bit flags" to be used in the C# Business logic.
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public char[] convertIntToFlagArray(int b, int choiceLen)
        {
            // b is now boolean representation of int b, backwards
            string s = Convert.ToString(b, 2);
            // break apart the string into a char array of according size
            char[] charArr = s.ToCharArray();

            char[] newCharArr = new char[choiceLen]; // create a new array and reverse it
            int len = charArr.Length;
            int counter = 0;
            for (int i = 0; i < choiceLen; i++)
            {
                if (i >= choiceLen - len)
                {
                    // 
                    newCharArr[i] = charArr[counter];
                    counter++;
                }
                else
                {
                    newCharArr[i] = '0';
                }
            }
            return newCharArr;
        }
    }
}
