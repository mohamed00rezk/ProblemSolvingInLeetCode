using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolvingInLeetCode.solutions
{
    public class MergeTwoSortedLists
    {
        public LinkedListNode<int> MergeTwoLists(LinkedListNode<int> list1, LinkedListNode<int> list2)
        {
            if ((list1 == null || list1.List.Count == 0) && (list2 == null || list2.List.Count == 0) )
            {
                return null;
            }
            if (list1 == null || list1.List.Count == 0) 
            {
                return list2;
            }
            if (list2 == null || list2.List.Count == 0)
            {
                return list1;
            }

            return mergeTowLists(list1,list2);

        }

        private LinkedListNode<int> mergeTowLists(LinkedListNode<int> list1, LinkedListNode<int> list2)
        {
            LinkedListNode<int>? mergeList = null;

            if (list1.Value > list2.Value)
            {
                mergeList.Value = list2.Value;
                mergeTowLists(list1 ,list2.Next);
            }
            else
            {
                mergeList.Value = list1.Value;
                mergeTowLists(list1.Next, list2);
            }

            return mergeList;
        }
    }
}
