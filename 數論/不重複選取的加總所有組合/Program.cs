namespace 不重複選取的加總所有組合
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] num = { 4, 2, 2, 5 };
            Array.Sort(num);
            HashSet<int> set = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();
            set.Add(0);
            set2.Add(0);
            foreach(int i in num)
            {
                foreach(int j in set)
                {
                    set2.Add(i + j);
                }
                set = set2.ToHashSet();
            }
            set.Remove(0);
            Console.WriteLine($"共有:{set.Count}");
            Console.WriteLine(string.Join(" ", set.ToArray()));
            Console.ReadKey();
        }
    }
}