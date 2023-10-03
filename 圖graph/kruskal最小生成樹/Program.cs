namespace kruskal最小生成樹
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Data> col = new List<Data>();
            HashSet<char> set = new HashSet<char>();
            col.Add(new Data('A', 'B', 6));
            col.Add(new Data('A', 'F', 12));
            col.Add(new Data('A', 'E', 10));
            col.Add(new Data('B', 'F', 8));
            col.Add(new Data('B', 'D', 5));
            col.Add(new Data('B', 'C', 3));
            col.Add(new Data('D', 'C', 7));
            col.Add(new Data('E', 'D', 9));
            col.Add(new Data('F', 'D', 11));
            col = col.OrderBy(item => item.cost).ToList();
            int res = 0;
            foreach(var item in col)
            {
                if (set.Contains(item.s) && set.Contains(item.d)) continue;
                Console.WriteLine($"{item.s}-{item.d}");
                res += item.cost;
                set.Add(item.s);
                set.Add(item.d);
            }
            Console.WriteLine($"最小花費:{res}");
            Console.ReadKey();
        }
    }
    class Data
    {
        public char s, d;
        public int cost;
        public Data(char s, char d, int cost)
        {
            this.s = s;
            this.d = d;
            this.cost = cost;
        }
    }
}