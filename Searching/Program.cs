using Searching.SymbolTables;
using System.Security.AccessControl;

namespace Searching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var l1 = new ListNode(1);
            var l2 = new ListNode(2);
            AddTwoNumbers(l1, l2);
            var c = MaxSlidingWindow(new int[] { -5769, -7887, -5709, 4600, -7919, 9807, 1303, -2644, 1144, -6410, -7159, -2041, 9059, -663, 4612, -257, 2870, -6646, 8161, 3380, 6823, 1871, -4030, -1758, 4834, -5317, 6218, -4105, 6869, 8595, 8718, -4141, -3893, -4259, -3440, -5426, 9766, -5396, -7824, -3941, 4600, -1485, -1486, -4530, -1636, -2088, -5295, -5383, 5786, -9489, 3180, -4575, -7043, -2153, 1123, 1750, -1347, -4299, -4401, -7772, 5872, 6144, -4953, -9934, 8507, 951, -8828, -5942, -3499, -174, 7629, 5877, 3338, 8899, 4223, -8068, 3775, 7954, 8740, 4567, 6280, -7687, -4811, -8094, 2209, -4476, -8328, 2385, -2156, 7028, -3864, 7272, -1199, -1397, 1581, -9635, 9087, -6262, -3061, -6083, -2825, -8574, 5534, 4006, -2691, 6699, 7558, -453, 3492, 3416, 2218, 7537, 8854, -3321, -5489, -945, 1302, -7176, -9201, -9588, -140, 1369, 3322, -7320, -8426, -8446, -2475, 8243, -3324, 8993, 8315, 2863, -7580, -7949, 4400 }, 6);
            var a = FindMedianSortedArrays(new int[0], new int[] { 1, 2, 3, 4, 5 });
            CarFleet(12, new[] { 10, 8, 0, 5, 3 }, new[] { 12, 4, 1, 1, 3 });
            DailyTemperatures(new int[] { 73, 74, 75, 71, 69, 72, 76, 73 });
            var sst = new SequentialSearchST<int, int>();

            sst.Add(1, 2);
            sst.Add(3, 4);
            sst.Add(5, 6);
            sst.Add(6, 7);
            sst.Add(7, 8);
            sst.Add(8, 9);


            foreach (int i in sst)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var merged = new int[nums1.Length + nums2.Length];
            int k = 0;
            int p = 0;
            int q = 0;
            while (k < merged.Length)
            {
                if (p >= nums1.Length && q < nums2.Length)
                {
                    merged[k] = nums2[q];
                    q++;
                }
                else if (p < nums1.Length && q >= nums2.Length)
                {
                    merged[k] = nums1[p];
                    p++;
                }
                else if (nums1[p] <= nums2[q])
                {
                    merged[k] = nums1[p];
                    p++;
                }
                else if (q < nums2.Length)
                {
                    merged[k] = nums2[q];
                    q++;
                }
                k++;
            }

            int m = merged.Length % 2;
            int v = merged.Length / 2;
            if (m > 0) return (double)merged[v];

            return ((double)merged[v] + (double)merged[v - 1]) / 2;
        }
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var stack = new Stack<string>();
            var curr = l1;
            while (curr != null)
            {
                stack.Push(curr.val.ToString());
                curr = curr.next;
            }
            string firstValue = "";
            while (stack.Count > 0)
            {
                firstValue += stack.Pop();
            }
            curr = l2;
            while (curr != null)
            {
                stack.Push(curr.val.ToString());
                curr = curr.next;
            }
            string secondValue = "";
            while (stack.Count > 0)
            {
                secondValue += stack.Pop();
            }

            int finalValue = int.Parse(firstValue) + int.Parse(secondValue);

            string finalValueString = finalValue.ToString();

            var n = new ListNode();
            curr = n;
            for (int i = finalValueString.Length - 1; i >= 0; i--)
            {
                var nn = new ListNode((int)char.GetNumericValue(finalValueString[i]));
                curr.next = nn;
                curr = curr.next;
            }
            return n;

        }
        public static int[] MaxSlidingWindow(int[] nums, int k)
        {
            int n = nums.Length;
            int[] windows = new int[n];
            Array.Fill(windows, int.MinValue);
            List<int> result = new List<int>();
            int l = 0;
            for (int r = 0; r < nums.Length; r++)
            {
                if (r - l < k)
                {
                    windows[r] = nums[r];
                }
                else
                {
                    result.Add(windows.Max());
                    windows[l] = int.MinValue;
                    l++;
                    windows[r] = nums[r];
                }
            }
            result.Add(windows.Max());
            return result.ToArray();
        }

        public static int CarFleet(int target, int[] position, int[] speed)
        {
            var map = new (int, int)[position.Length];
            var stack = new Stack<double>();
            for (int i = 0; i < position.Length; i++)
            {
                map[i] = (position[i], speed[i]);
            }

            foreach (var c in map.OrderByDescending(x => x.Item1))
            {
                var t = target / c.Item2;
                if (stack.Count == 0 || stack.Peek() < t) stack.Push(t);
            }
            return stack.Count;

        }
        public static int[] DailyTemperatures(int[] temperatures)
        {
            var res = new int[temperatures.Length];
            var stack = new Stack<(int, int)>();
            for (int i = 0; i < temperatures.Length; i++)
            {
                while (stack.Count() > 0 && (stack.Peek().Item2 < temperatures[i]))
                {
                    var r = stack.Pop();
                    res[r.Item1] = i - r.Item1;
                }
                stack.Push((i, temperatures[i]));
            }
            return res;
        }
    }
}