// See https://aka.ms/new-console-template for more information
using ProblemSolvingInLeetCode.solutions;

Console.WriteLine("Hello, World!");



String s = "[([]])"; // "(([]){})"; // "{[]})("; // "(("; // "()";
ValidParentheses v = new ValidParentheses();
var res = v.IsValid(s);
Console.WriteLine("res: " +  res);


//TwoSum s = new TwoSum();
//int[] nums = new[] { 2, 7, 11, 15 };
//int[] res = s.TwoSum_1(nums, 9);
//Console.WriteLine("res: " + res.First() + " , " + res.Last());