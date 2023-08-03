// See https://aka.ms/new-console-template for more information
using ProblemSolvingInLeetCode.solutions;

Console.WriteLine("Hello, World!");


/// ValidParentheses
//   String s = "[([]])"; // "(([]){})"; // "{[]})("; // "(("; // "()";
//   ValidParentheses v = new ValidParentheses();
//   var res = v.IsValid(s);
//   Console.WriteLine("res: " +  res);

// TwoSum
TwoSum s = new TwoSum();
int[] nums = new[] { 1, 3, 4, 2 };
int[] res = s.TwoSum_1(nums, 6);
Console.WriteLine("res: " + res.First() + " , " + res.Last());