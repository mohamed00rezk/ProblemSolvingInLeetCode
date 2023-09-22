using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolvingInLeetCode.solutions
{
    public class MaxProfitSolution
    {
        // solution 0
        public int MaxProfit(int[] prices)
        {
            int minVal = prices[0];
            return  prices.Max(p => {
                minVal = Math.Min(minVal, p);
                return (p - minVal);
            });
        }

        // solution 0
        public int MaxProfit_00(int[] prices)
        {
            int maxProfit = 0;
            int minVal = prices[0];

            for (int i = 0; i < prices.Length; i++)
            {
                minVal = Math.Min(minVal, prices[i]);
                int val = prices[i] - minVal;
                maxProfit = val > maxProfit ? val : maxProfit;
            }

            return maxProfit;
        }

        // solution 2
        // Time Limit Exceeded
        public int maxProfit_2(int[] prices) {
            int maxProfit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                int buy = prices[i];
                int[]  newPrices = prices.Skip(i).ToArray();
                for (int j = 0 ; j < newPrices.Length ; j++)
                {
                    int val = newPrices[j] - prices[i];
                    maxProfit = val > maxProfit ? val : maxProfit;
                }
            }
            return maxProfit;
        }

        // solution 1 
        // out of memory with large amount of data
        public int maxProfit_1(int[] prices)
        {
            return maxProfit_1(0, prices , prices.Skip(1).ToArray() , 0);
        }
        private int maxProfit_1(int profit, int[] prices_buy, int[] prices_sell , int count)
        {
            if (prices_buy.Length > 0)
            {
              profit = maxProfit_1(profit, prices_buy[0], prices_sell , count);
              
                if (prices_buy.Length > 1 && prices_sell.Length > 1)
                  return maxProfit_1(profit, prices_buy.Skip(1).ToArray(), prices_sell.Skip(1).ToArray() , count);
            }
            return profit;
        }
        private int maxProfit_1(int profit, int buy, int[] prices_sell , int count)
        {
            count += 1;
            Console.WriteLine(count + 1);
            if (prices_sell.Length > 0)
            {
                profit = ((prices_sell[0] - buy) > profit) ? (prices_sell[0] - buy) : profit;
                
                if (prices_sell.Length > 1)
                    return maxProfit_1(profit, buy, prices_sell.Skip(1).ToArray() , count);
            }
            return profit;
        }
    }
}
