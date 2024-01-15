namespace 柵欄密碼
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s;
            while (!string.IsNullOrEmpty(s = Console.ReadLine() + ""))
            {
                char[,] arr = new char[5, s.Length];
                bool fg = false;
                int cnt = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    arr[cnt, i] = s[i];
                    if (cnt == 0) fg = false;
                    if (cnt == 4) fg = true;
                    cnt= fg ? cnt - 1 : cnt + 1;
                }
                string res = "";
                for(int i = 0; i < 5; i++)
                {
                    for(int j = 0; j < s.Length; j++)
                    {
                        Console.Write(arr[i, j] != '\0' ? arr[i, j] : " ");
                        res += arr[i, j];
                    }
                    Console.WriteLine();
                }
                Console.WriteLine($"密文:{res}");
            }
        }
    }
}
