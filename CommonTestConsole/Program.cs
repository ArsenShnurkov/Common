namespace CommonTestConsole
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using Common.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            using (StreamWriter file = new System.IO.StreamWriter(@"output.csv"))
            {
                //TextWriter writer = Console.Out;
                TextWriter writer = file;

                int maxN = 1500000;
                int minN = 100000;
                int step = 100000;

                bool doDelete = true;
                bool doFind = true;
                bool doDepth = false;

                int repititions = 2;

                int n = minN;
                while (n <= maxN)
                {
                    for (int j = 1; j <= repititions; ++j)
                    {
                        CompareTrees(rng, n, writer, doDelete, doFind, doDepth);
                        Console.WriteLine("{0:hh:mm:ss} - Finished {1} - Iteration {2}", DateTime.Now, n, j);
                    }
                    n += step;
                }
            }
        }

        private static void CompareTrees(Random rng, int n, TextWriter file, bool doDelete, bool doFind, bool doDepth)
        {
            int nFind = n / 10;

            int[] numbers = GetUniqueRandomNumbers(rng, n, 0, Int32.MaxValue);
            int[] randomIndexes = GetUniqueRandomNumbers(rng, nFind, 0, n);

            IDictionary<string, double> iterativeBstTimes = new Dictionary<string, double>();
            IDictionary<string, double> recursiveBstTimes = new Dictionary<string, double>();
            IDictionary<string, double> redBlackTimes = new Dictionary<string, double>();
            IDictionary<string, double> avlTimes = new Dictionary<string, double>();

            IBinarySearchTree<int> iterativeBst = new SafeBinarySearchTree<int>();
            IBinarySearchTree<int> recursiveBst = new BinarySearchTree<int>();
            IBinarySearchTree<int> redBlackTree = new RedBlackTree<int>();
            IBinarySearchTree<int> avlTree = new AVLTree<int>();

            iterativeBstTimes["insert"] = BuildAndCheckTree(iterativeBst, numbers);
            recursiveBstTimes["insert"] = BuildAndCheckTree(recursiveBst, numbers);
            redBlackTimes["insert"] = BuildAndCheckTree(redBlackTree, numbers);
            avlTimes["insert"] = BuildAndCheckTree(avlTree, numbers);

            if (doFind)
            {
                iterativeBstTimes["find"] = FindValuesInTree(iterativeBst, numbers, randomIndexes);
                recursiveBstTimes["find"] = FindValuesInTree(recursiveBst, numbers, randomIndexes);
                redBlackTimes["find"] = FindValuesInTree(redBlackTree, numbers, randomIndexes);
                avlTimes["find"] = FindValuesInTree(avlTree, numbers, randomIndexes);
            }

            if (doDepth)
            {
                iterativeBstTimes["depth"] = DepthOfValuesInTree(iterativeBst, numbers, randomIndexes);
                recursiveBstTimes["depth"] = DepthOfValuesInTree(recursiveBst, numbers, randomIndexes);
                redBlackTimes["depth"] = DepthOfValuesInTree(redBlackTree, numbers, randomIndexes);
                avlTimes["depth"] = DepthOfValuesInTree(avlTree, numbers, randomIndexes);
            }

            if (doDelete)
            {
                iterativeBstTimes["delete"] = DeleteValuesInTree(iterativeBst, numbers, randomIndexes);
                recursiveBstTimes["delete"] = DeleteValuesInTree(recursiveBst, numbers, randomIndexes);
                redBlackTimes["delete"] = DeleteValuesInTree(redBlackTree, numbers, randomIndexes);
                avlTimes["delete"] = DeleteValuesInTree(avlTree, numbers, randomIndexes);
            }

            file.Write("{0},", n);
            WriteStats(iterativeBstTimes, file);
            WriteStats(recursiveBstTimes, file);
            WriteStats(redBlackTimes, file);
            WriteStats(avlTimes, file);
            file.WriteLine();
        }

        private static void WriteStats(IDictionary<string, double> times, TextWriter file)
        {
            if (times.ContainsKey("insert"))
                file.Write("{0:F10},", times["insert"]);

            if (times.ContainsKey("delete"))
                file.Write("{0:F10},", times["delete"]);

            if (times.ContainsKey("find"))
                file.Write("{0:F10},", times["find"]);

            if (times.ContainsKey("depth"))
                file.Write("{0:F10},", times["depth"]);
        }

        private static double DeleteValuesInTree(IBinarySearchTree<int> bst, int[] numbers, int[] randomIndexes)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            TimeSpan time = new TimeSpan();
            for (int i = 0; i < randomIndexes.Count(); ++i)
            {
                stopwatch.Restart();
                bst.Delete(numbers[randomIndexes[i]]);
                time += stopwatch.Elapsed;
            }

            bst.AssertValidTree();

            return time.TotalMilliseconds / numbers.Count();
        }

        private static double FindValuesInTree(IBinarySearchTree<int> bst, int[] numbers, int[] randomIndexes)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            TimeSpan time = new TimeSpan();
            for (int i = 0; i < randomIndexes.Count(); ++i)
            {
                stopwatch.Restart();
                bst.Find(numbers[randomIndexes[i]]);
                time += stopwatch.Elapsed;
            }
            return time.TotalMilliseconds / numbers.Count();
        }

        private static double DepthOfValuesInTree(IBinarySearchTree<int> bst, int[] numbers, int[] randomIndexes)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            TimeSpan time = new TimeSpan();
            for (int i = 0; i < randomIndexes.Count(); ++i)
            {
                stopwatch.Restart();
                bst.Depth(numbers[randomIndexes[i]]);
                time += stopwatch.Elapsed;
            }
            return time.TotalMilliseconds / numbers.Count();
        }

        private static double BuildAndCheckTree(IBinarySearchTree<int> bst, int[] numbers)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            TimeSpan time = new TimeSpan();
            for (int i = 0; i < numbers.Count(); ++i)
            {
                stopwatch.Restart();
                bst.Insert(numbers[i]);
                time += stopwatch.Elapsed;
            }

            bst.AssertValidTree();

            if (bst.Count != numbers.Count())
                throw new InvalidOperationException();

            return time.TotalMilliseconds / numbers.Count();
        }

        private static int[] GetUniqueRandomNumbers(Random rng, int n, int min, int max)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>(n);
            while (numbers.Count < n)
            {
                int num = rng.Next(min, max);
                numbers[num] = num;
            }

            int[] keys = numbers.Keys.ToArray();
            numbers = null;

            if (keys.Count() != n)
                throw new InvalidOperationException();

            return keys;
        }
    }
}
