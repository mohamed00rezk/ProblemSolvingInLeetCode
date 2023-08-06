// See https://aka.ms/new-console-template for more information
using ProblemSolvingInLeetCode.solutions;

Console.WriteLine("Hello, World!");



///// ValidParentheses
//String s = "([])"; // "(([]){})"; // "{[]})("; // "(("; // "()";
//ValidParentheses v = new ValidParentheses();
//var res = v.IsValid(s);
//Console.WriteLine("res: " + res);

// TwoSum
TwoSum s = new TwoSum();
int[] nums = new[] {0, 4, 3, 0 };
int[] res = s.TwoSum_0(nums, 0);
Console.WriteLine("res: " + res.First() + " , " + res.Last());