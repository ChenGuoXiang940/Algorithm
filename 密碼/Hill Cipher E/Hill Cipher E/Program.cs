// See https://aka.ms/new-console-template for more information
namespace Hill_Cipher_E
{
    class Program
    {
        public static int gcd(int a,int b)
        {
            if (a == 1) return b;
            return a % b == 0 ? b : gcd(b, a % b);
        }
        public static int[,] key = new int[3, 3];
        public static int getval() => key[0, 0] * (key[1, 1] * key[2, 2] - key[1, 2] * key[2, 1]) - key[0, 1] * (key[1, 0] * key[2, 2] - key[1, 2] * key[2, 0]) + key[0, 2] * (key[1, 0] * key[2, 1] - key[1, 1] * key[2, 0]);
        public static bool createkey(string s2)
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    key[i, j] = (s2[i * 3 + j] - 'A');
                }
            }
            return gcd(getval() % 26, 26) == 1;
        }
        static void Main(string[] args)
        {
            //明文:ACT
            //密鑰:GYBNQKURP
            //密文:POH
            while (true)
            {
                Console.Write("請輸入明文(長度為三的倍數):");
                string s = Console.ReadLine() + "";
                if (s.Length % 3 != 0)
                {
                    Console.WriteLine("明文字串長度必須是三的倍數!");
                    break;
                }
                Console.Write("輸入密鑰(長度為九且可逆):");
                string s2 = Console.ReadLine() + "";
                if (s2.Length != 9)
                {
                    Console.WriteLine("密鑰字串長度必須是九!");
                    break;
                }
                if (!createkey(s2))
                {
                    Console.WriteLine("請確認密鑰是可逆的!");
                    break;
                }
                string result = "";
                for (int i = 0; i < s.Length; i += 3)
                {
                    int[] ans = new int[3];
                    int[] num = new int[3] { s[i] - 'A', s[i + 1] - 'A', s[i + 2] - 'A' };
                    for (int j = 0; j < 3; j++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            ans[j] += num[k] * (int)key[j, k];
                        }
                    }
                    result += String.Join("", ans.Select(x => Convert.ToChar('A' + (x % 26))));
                }
                Console.WriteLine("密文:" + result);
                break;
            }
            Console.ReadKey();
        }
    }
}
