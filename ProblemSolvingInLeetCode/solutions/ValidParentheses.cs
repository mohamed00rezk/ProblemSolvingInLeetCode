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

        private static Dictionary<char, char> PATTERN_MAP = new Dictionary<char, char>() {{ '(', ')' } , { '{', '}' } , { '[', ']' } };


        public bool IsValid(string input)
        {
            
            List<Char> chars = input.ToList();

            if (chars.Count % 2 == 1)
            {
                return false;
            }
            if (checkIfALLInputIsOpenOrClose(chars)) // "({[   ]})"
            {
                return false;
            }

            Dictionary<int, char> map = new Dictionary<int, char>();
            for (int i = 0; i < chars.Count; i++)
            {
                map.Add(i , chars[i]);
            }
            Dictionary<int, char> outputCharMap = new Dictionary<int, char>();

            foreach (KeyValuePair<int ,char> ch in map)
            {
                if (!PATTERN.Contains(ch.Value))
                {
                    return false;
                }

                outputCharMap.Add(outputCharMap.Count(), ch.Value);     

                if (PATTERNOFCLOSE.Contains(ch.Value))
                {
                    char openCh = PATTERN_MAP.FirstOrDefault(o => o.Value.Equals(ch.Value)).Key;                  
                    if (!outputCharMap.ContainsValue(openCh))
                    {
                        return false;
                    }
                    
                    int orderShift = getOrderShift(outputCharMap, openCh);

                    if (!isOrderTrue(outputCharMap, openCh, ch.Value, orderShift))
                    {
                        return false;
                    }

                    outputCharMap = remove(outputCharMap, ch.Value, orderShift);

                }

            }
            if (outputCharMap.Count > 0)
            {
                return false;
            }
            return true;
        }
        private int getOrderShift(Dictionary<int, char> outputCharMap, char openCh)
        {
            int openChIndex = outputCharMap.LastOrDefault(o => o.Value.Equals(openCh)).Key;

            Dictionary<int, char> tempArray = new Dictionary<int, char>();
            tempArray =  outputCharMap;

            var tempArrayX = tempArray.SkipWhile(o => o.Key < openChIndex);

            int shiftCount = tempArrayX.Where(o => o.Value != openCh && PATTERNOFOPEN.Contains(o.Value)).Count();

            return shiftCount != 0 ? (shiftCount * 2) + 1 : 1;
        }
        private bool isOrderTrue(Dictionary<int, char> outputCharMap, char openCh, char closeCh, int orderShift)
        {
            int openChIndex  = outputCharMap.LastOrDefault(o => o.Value.Equals(openCh)).Key;   // 1  // 2
            int closeChIndex = outputCharMap.LastOrDefault(o => o.Value.Equals(closeCh)).Key; ; // 4  // 3
            if (closeChIndex == openChIndex + orderShift)
            {
                return true;
            }
            return false;
        }
        private Dictionary<int, char> remove(Dictionary<int, char> outputCharMap, char ch, int orderShift)
        {
            int closeChIndex = outputCharMap.LastOrDefault(o => o.Value.Equals(ch)).Key;
            outputCharMap.Remove(closeChIndex);
            outputCharMap.Remove(closeChIndex - orderShift);

            return outputCharMap;
        }
        private bool checkIfALLInputIsOpenOrClose(List<char> charArray)
        {
            return charArray.Where(ch => PATTERNOFOPEN.Contains(ch)).Count() == charArray.Count ||
                   charArray.Where(ch => PATTERNOFCLOSE.Contains(ch)).Count() == charArray.Count;
        }




        // solution with o(n2)
        private static string PATTERN_1_2 = "()";
        private static string PATTERN_2_2 = "{}";
        private static string PATTERN_3_2 = "[]";
        public bool IsValid_2(string input)
        {
            List<Char> outputCharArray = new List<Char>();
            var charArray = input.ToList();
            if (charArray.Count%2 == 1)
            {
                return false;
            }
            if (checkIfALLInputIsOpenOrClose_1(charArray))
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

        private int getOrderShift( List<Char> outputCharArray, char openCh )
        {
            List<Char> tempArray  = new List<char>();
            tempArray.AddRange(outputCharArray);

            int openChIndex = tempArray.FindLastIndex(o => o.Equals(openCh));

            tempArray.RemoveRange(0 , openChIndex);

            int shiftCount = tempArray.Where(o => o!= openCh && PATTERNOFOPEN.Contains(o)).Count();
            return shiftCount!= 0 ? (shiftCount * 2) + 1 : 1;
        }

        private bool checkIfALLInputIsOpenOrClose_1(List<char> charArray)
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
            if (PATTERN_1_2.Contains(ch))
            {
                x =  PATTERN_1_2.ToArray()[0];
            }
            else if (PATTERN_2_2.Contains(ch))
            {
                x = PATTERN_2_2.ToArray()[0];
            } 
            else 
                x = PATTERN_3_2.ToArray()[0];

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
