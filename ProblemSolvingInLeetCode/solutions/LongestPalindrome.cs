using System.Reflection.PortableExecutable;

public class LongestPalindrome
{

    public int longestPalindrome(string s)
    {
        int length = 0;

        var set = new HashSet<char>();
        foreach (char c in s)
        {
            if (set.Contains(c))
            {
                length += 2;
                set.Remove(c);
            }
            else
            {
               set.Add(c);
            }
        }


        return  length +  ( set.Count > 0 ? 1 : 0 );
    }

    public int longestPalindrome_0(string s)
    {
        String right = string.Empty;
        String left = string.Empty;
        String center = string.Empty;

        Dictionary<char, int> valuePairs = new Dictionary<char, int>();
        foreach (char ch in s)
        {
            if (valuePairs.ContainsKey(ch))
            {
                valuePairs[ch]++;
            }
            else
            {
                valuePairs[ch] = 1;
            }
        }

        for (int i = 0; i < valuePairs.Count; i++)
        {
            char currentChar = valuePairs.ElementAt(i).Key;
            if ((valuePairs.ElementAt(i).Value % 2) == 1)
            {
                for (int j = 0; j < (valuePairs.ElementAt(i).Value - 1) / 2; j++)
                {
                    right = right + currentChar;
                    left = currentChar + left;
                }

                if (center == string.Empty)
                {
                    center = currentChar.ToString();
                }
            }
            else if ((valuePairs.ElementAt(i).Value % 2) == 0)
            {
                for (int j = 0; j < valuePairs.ElementAt(i).Value / 2; j++)
                {
                    right = right + currentChar;
                    left = currentChar + left;
                }
            }
        }
        string res = right + center + left;
        return res.Length;
    }
};