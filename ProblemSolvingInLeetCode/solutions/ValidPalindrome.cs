using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProblemSolvingInLeetCode.solutions
{
    public class ValidPalindrome
    {
        // solution 0 
        public bool isPalindrome(string s)
        {
            for (int i = 0 ,  j = s.Length - 1;  j > i;)
            {
                if (!char.IsLetterOrDigit(s[i]))
                {
                    i++;
                    continue;
                }

                if (!char.IsLetterOrDigit(s[j]))
                {
                    j--;
                    continue;
                }

                if (char.ToLower(s[i]) != char.ToLower(s[j]))
                {
                    return false;
                }

                i++;
                j--;
            }
            return true;
        }

        // solution 0 
        public bool isPalindrome_0(string s)
        {
            if (s == null) return false;
            s = s.Replace(" ", string.Empty).ToLower();
            if (s.Length == 0) return true;

            String normalized = "";
            for (int i = 0; i < s.Length; i++)
            {
                char ricghChar = s[i];
                if (char.IsLetterOrDigit(ricghChar))
                {
                    normalized = normalized + s[i];
                }
            }

            if (normalized.Length == 0) return true;

            var length = normalized.Length %2 == 1 ? 
                ( (normalized.Length + 1 ) / 2 ) : ( normalized.Length / 2 );
            int acumlatorNumber = normalized.Length % 2 == 1 ?  1 : 0;
            
            var right = normalized.Substring(0, length);
            var left = normalized.Substring(length - acumlatorNumber).ToCharArray();
            Array.Reverse(left);
            string reversedStr = new string(left);

            if (right == reversedStr)
            {
                return true;
            }

            return false;
        }


    }
}
