using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Duplicate Encoder
 * 
 * The goal of this exercise is to convert a string to a new string where each character in the new string is 
 * "(" if that character appears only once in the original string, 
 * or ")" if that character appears more than once in the original string. 
 * Ignore capitalization when determining if a character is a duplicate.*/

namespace Practice_Coding
{
    internal class Duplicate_Encoder
    {
        public string newStr = string.Empty;

        static void Main(string[] args)
        {
            Duplicate_Encoder myClass = new Duplicate_Encoder();
            string str = "recede";

            myClass.Duplicate_Encode(str);
            Console.ReadKey();
        }

        public void Duplicate_Encode(string str)
        {
            string temp = string.Empty;
            foreach (var s in str.ToLower())
            {
                int cnt = 0;
                foreach (var newS in str.ToLower())
                    if (newS == s)
                        cnt++;

                if (cnt > 1) temp += ")";
                else temp += "(";
            }
            Console.WriteLine(temp);
        }
    }
}

/*
 * The best solution
 
 public static string DuplicateEncode(string word)
  {  
    return new string(word.ToLower().Select(ch => word.ToLower().Count(innerCh => ch == innerCh) == 1 ? '(' : ')').ToArray());
  }

 */
