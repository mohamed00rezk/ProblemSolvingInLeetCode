using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProblemSolvingInLeetCode.solutions
{
    public class ValidParentheses
    {
        private static string PATTERN = "(){}[]";
        private static string PATTERNOFOPEN = "({[";
        private static string PATTERNOFCLOSE = ")}]";

        private static string PATTERN_1 = "()";
        private static string PATTERN_2 = "{}";
        private static string PATTERN_3 = "[]";
        public bool IsValid(string input)
        {
            List<Char> outputCharArray = new List<Char>();
            var charArray = input.ToList();
            if (charArray.Count%2 == 1)
            {
                return false;
            }
            if (checkIfALLInputIsOpenOrClose(charArray))
            {
                return false;
            }
            foreach (char ch in charArray )
            {
                if (!PATTERN.Contains(ch))
                {
                    return false;
                }
                outputCharArray.Add(ch); 
                if (PATTERNOFCLOSE.Contains(ch))
                {
                    char openCh = getTheOpenOfTheCloseChar(ch);
                    if (!isOutputCharArrayContainOpenCh(outputCharArray, openCh))
                    {
                        return false;
                    }
                    int orderShift = getOrderShift(outputCharArray, openCh);
                    if (!isOrderTrue(outputCharArray, openCh, ch , orderShift))
                    {
                        return false;
                    }
                    outputCharArray = remove(outputCharArray, openCh, ch , orderShift);
                }
                
            }
            if (outputCharArray.Count > 0)
            {
                return false;
            }
            return true;
        }

        private List<char> remove(List<char> outputCharArray, char openCh, char ch , int orderShift)
        {
            //int openChIndex = outputCharArray.FindLastIndex(o => o.Equals(openCh));
            int closeChIndex = outputCharArray.FindLastIndex(o => o.Equals(ch));
            outputCharArray.RemoveAt(closeChIndex);
            outputCharArray.RemoveAt(closeChIndex - orderShift);
            return outputCharArray;
        }

        private int getOrderShift(List<Char> outputCharArray, char openCh )
        {
            List<Char> tempArray  = new List<char>();
            tempArray.AddRange(outputCharArray);
            int openChIndex = tempArray.FindLastIndex(o => o.Equals(openCh));
            tempArray.RemoveRange(0 , openChIndex);
            int shiftCount = tempArray.Where(o => o!= openCh && PATTERNOFOPEN.Contains(o)).Count();
            return shiftCount!= 0 ? (shiftCount * 2) + 1 : 1;
        }

        private bool checkIfALLInputIsOpenOrClose(List<char> charArray)
        {
           return charArray.Where(ch => PATTERNOFOPEN.Contains(ch)).Count() == charArray.Count ||
                  charArray.Where(ch => PATTERNOFCLOSE.Contains(ch)).Count() == charArray.Count ;
        }

        private bool isOutputCharArrayContainOpenCh(List<char> outputCharArray, char openCh)
        {
            return outputCharArray.Contains(openCh);
        }

        private Char getTheOpenOfTheCloseChar(char ch)
        {
            Char x ;
            if (PATTERN_1.Contains(ch))
            {
                x =  PATTERN_1.ToArray()[0];
            }
            else if (PATTERN_2.Contains(ch))
            {
                x = PATTERN_2.ToArray()[0];
            } 
            else 
                x = PATTERN_3.ToArray()[0];

            return x;
        }

        private bool isOrderTrue(List<char> outputCharArray, char openCh, char closeCh ,  int orderShift)
        {
            var openChIndex = outputCharArray.FindLastIndex(o => o.Equals(openCh));   // 1  // 2
            var closeChIndex = outputCharArray.FindIndex(o => o.Equals(closeCh)); // 4  // 3
            if (closeChIndex == openChIndex + orderShift)
            {
                return true;
            }
            return false;
        }
    }
}
