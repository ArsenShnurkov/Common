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
                TextWriter writer = Console.Out;
                //TextWriter writer = file;

                int maxN = 2000000;
                int minN = 1000000;
                int step = 200000;

                bool doDelete = false;
                bool doFind = false;

                int repititions = 3;

                int n = minN;
                while (n <= maxN)
                {
                    for (int j = 1; j <= repititions; ++j)
                    {
                        CompareCollections(rng, n, writer, doDelete, doFind);
                        Console.WriteLine("{0:hh:mm:ss} - Finished {1} - Iteration {2}", DateTime.Now, n, j);
                    }
                    n += step;
                }
            }
        }

        private static void CompareCollections(Random rng, int n, TextWriter file, bool doDelete, bool doFind)
        {
            int nFind = n / 10;

            int[] numbers = GetUniqueRandomNumbers(rng, n, 0, Int32.MaxValue);
            int[] randomIndexes = GetUniqueRandomNumbers(rng, nFind, 0, n);

            IDictionary<string, double> iterativeBstTimes = new Dictionary<string, double>();
            IDictionary<string, double> redBlackTimes = new Dictionary<string, double>();
            IDictionary<string, double> avlTimes = new Dictionary<string, double>();
            IDictionary<string, double> skipListTimes = new Dictionary<string, double>();

            ICollection<int> iterativeBst = new BinarySearchTree<int>();
            ICollection<int> redBlackTree = new RedBlackTree<int>();
            ICollection<int> avlTree = new AVLTree<int>();
            ICollection<int> skipList = new SkipList<int>();

            bool doIterative = true;
            bool doRedBlack = true;
            bool doAvl = true;
            bool doSkipList = false;

            if (doIterative)
                iterativeBstTimes["insert"] = BuildAndCheckCollection(iterativeBst, numbers);

            if (doRedBlack)
                redBlackTimes["insert"] = BuildAndCheckCollection(redBlackTree, numbers);

            if (doAvl)
                avlTimes["insert"] = BuildAndCheckCollection(avlTree, numbers);

            if (doSkipList)
                skipListTimes["insert"] = BuildAndCheckCollection(skipList, numbers);

            if (doFind)
            {
                if (doIterative)
                    iterativeBstTimes["find"] = FindValuesInCollection(iterativeBst, numbers, randomIndexes);
                
                if (doRedBlack)
                    redBlackTimes["find"] = FindValuesInCollection(redBlackTree, numbers, randomIndexes);
                
                if (doAvl)
                    avlTimes["find"] = FindValuesInCollection(avlTree, numbers, randomIndexes);
                
                if (doSkipList)
                    skipListTimes["find"] = FindValuesInCollection(skipList, numbers, randomIndexes);
            }

            if (doDelete)
            {
                if (doIterative)
                    iterativeBstTimes["delete"] = DeleteValuesInCollection(iterativeBst, numbers, randomIndexes);

                if (doRedBlack)
                    redBlackTimes["delete"] = DeleteValuesInCollection(redBlackTree, numbers, randomIndexes);

                if (doAvl)
                    avlTimes["delete"] = DeleteValuesInCollection(avlTree, numbers, randomIndexes);

                if (doSkipList)
                    skipListTimes["delete"] = DeleteValuesInCollection(skipList, numbers, randomIndexes);
            }

            file.Write("{0},", n);

            if (doIterative)
                WriteStats(iterativeBstTimes, file);

            if (doRedBlack)
                WriteStats(redBlackTimes, file);

            if (doAvl)
                WriteStats(avlTimes, file);

            if (doSkipList)
                WriteStats(skipListTimes, file);

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
        }

        private static double DeleteValuesInCollection(ICollection<int> collection, int[] numbers, int[] randomIndexes)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            TimeSpan time = new TimeSpan();
            for (int i = 0; i < randomIndexes.Count(); ++i)
            {
                stopwatch.Restart();
                collection.Remove(numbers[randomIndexes[i]]);
                time += stopwatch.Elapsed;
            }


            return time.TotalMilliseconds / numbers.Count();
        }

        private static double FindValuesInCollection(ICollection<int> collection, int[] numbers, int[] randomIndexes)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            TimeSpan time = new TimeSpan();
            for (int i = 0; i < randomIndexes.Count(); ++i)
            {
                stopwatch.Restart();
                collection.Contains(numbers[randomIndexes[i]]);
                time += stopwatch.Elapsed;
            }
            return time.TotalMilliseconds / numbers.Count();
        }

        private static double BuildAndCheckCollection(ICollection<int> collection, int[] numbers)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            TimeSpan time = new TimeSpan();
            for (int i = 0; i < numbers.Count(); ++i)
            {
                stopwatch.Restart();
                collection.Add(numbers[i]);
                time += stopwatch.Elapsed;
            }

            if (collection.Count != numbers.Count())
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
