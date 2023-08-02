using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolvingInLeetCode.solutions
{
    public class TwoSum 
    {
        // solution 1 O(n)
        public int[] TwoSum_1(int[] nums, int target)
        {
            int[] res = new int[2];
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                map.Add(i, nums[i]);
            }

            for (int i = 0; i < nums.Length; i++)
            { 
                int x = map.Where(x => x.Value + nums[i] == target).Select(res => res.Key).FirstOrDefault();
                if (x != 0)
                {
                    res[0] = i;
                    res[1] = x;
                    return res;
                }
            }

            return new int[0];
        }

        // solution 2 O(n2)
        public int[] TwoSum_2(int[] nums, int target)
        {
            int[] res = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    int sum = nums[i] + nums[j];
                    if (sum == target)
                    {
                        res[0] = i;
                        res[1] = j;
                        return res;
                    }
                }
            }
            return new int[0];
        }
    }
}
