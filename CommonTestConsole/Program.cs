namespace CommonTestConsole
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common.Collections.Generic;

    class Program
    {
        static void Main(string[] args)
        {
            int n = 10000000;
            int freq = n / 100;

            Console.WriteLine("Building tree of {0}, with updates every {1}", n, freq);

            int[] numbers = GetUniqueRandomNumbers(n);

            IBinarySearchTree<int> bst = new AVLTree<int>();

            Console.WriteLine("Starting to build the tree");

            foreach (int num in numbers)
            {
                bst.Insert(num);
                if (num % freq == 0)
                    Console.Write(".");
            }

            Console.WriteLine();
            Console.WriteLine("Finished");
            Console.Write("Checking tree integrity");

            int previous = -1;
            foreach (int num in bst.InOrderIterator)
            {
                if (previous > num)
                    throw new InvalidOperationException();

                previous = num;
            }

            Console.WriteLine(" - Passed");
        }

        private static int[] GetUniqueRandomNumbers(int n)
        {
            Random rng = new Random();
            Dictionary<int, int> numbers = new Dictionary<int, int>(n);
            while (numbers.Count < n)
            {
                int num = rng.Next(0, int.MaxValue);
                if (!numbers.ContainsKey(num))
                    numbers.Add(num, num);
            }

            int[] keys = numbers.Keys.ToArray();
            numbers = null;
            return keys;
        }
    }
}
