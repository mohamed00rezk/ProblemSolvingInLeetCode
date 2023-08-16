using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolvingInLeetCode.solutions
{
    public class TwoSum 
    {

        public int[] TwoSum_0(int[] nums, int target)
        {
            int[] res = new int[2];
            Dictionary<int, int> map = new Dictionary<int, int>();
  
            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(target - nums[i]))
                {
                    return new int[] { map[target - nums[i]], i };
                }
                else
                {
                    map.TryAdd(nums[i] , i);
                }

            }

            return  new int[0];
        }


        // solution 2 O(n2)
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
                KeyValuePair<int, int> data = map.Where(x => (x.Value + nums[i] == target) && (i != x.Key) ).LastOrDefault();
                if (data.Key != 0)
                {
                    res[0] = i;
                    res[1] = data.Key;
                    return res;
                }

            }

            return new int[0];
        }
        // solution 1 O(n2)
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
