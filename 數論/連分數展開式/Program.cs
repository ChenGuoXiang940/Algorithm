namespace 連分數展開式
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                List<int> col = new List<int>();
                if (b == 0)
                {
                    Console.WriteLine("錯誤：b 不能為 0！");
                    continue;
                }
                while (b != 0)
                {
                    col.Add(a / b);
                    int temp = a % b;
                    a = b;
                    b = temp;
                }
                string str = string.Join(",", col);
                int index = str.IndexOf(",");
                if (index != -1)
                {
                    str = str.Remove(index, 1).Insert(index, ":");
                }
                Console.WriteLine(str);
            }
        }
    }
}
/*  a / b 連分數表示法  */