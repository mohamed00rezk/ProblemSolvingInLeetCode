using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolvingInLeetCode.solutions
{
    public class MaxProfit
    {
        public int maxProfit(int[] prices)
        {
            return maxProfit(0, prices , prices.Skip(1).ToArray());
        }
        private int maxProfit(int profit, int[] prices_buy, int[] prices_sell)
        {
            if (prices_buy.Length > 0)
            {
              profit = maxProfit(profit, prices_buy[0], prices_sell);
              if (prices_buy.Length > 1 && prices_sell.Length > 1)
              {
                  return maxProfit(profit, prices_buy.Skip(1).ToArray(), prices_sell.Skip(1).ToArray());
              }
                else
                    return profit;
            }
            return profit;
        }
        private int maxProfit(int profit , int buy , int[] prices_sell)
        {
            if (prices_sell.Length > 0)
            {
                profit = ((prices_sell[0] - buy) > profit) ? (prices_sell[0] - buy) : profit;
                if (prices_sell.Length > 1)
                {
                    return maxProfit(profit, buy, prices_sell.Skip(1).ToArray());
                }
                else
                    return profit;
            }
            return profit;
        }
    }
}
