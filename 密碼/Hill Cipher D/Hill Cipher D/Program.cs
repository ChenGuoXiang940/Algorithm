// See https://aka.ms/new-console-template for more information
namespace Hill_Cipher_D
{
    class Program
    {
        public static int gcd(int a, int b)
        {
            if (a == 1) return b;
            return a % b == 0 ? b : gcd(b, a % b);
        }
        public static int[,] key = new int[3, 3];
        public static int getval() => key[0, 0] * (key[1, 1] * key[2, 2] - key[1, 2] * key[2, 1]) - key[0, 1] * (key[1, 0] * key[2, 2] - key[1, 2] * key[2, 0]) + key[0, 2] * (key[1, 0] * key[2, 1] - key[1, 1] * key[2, 0]);
        public static int createkey(string s2)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    key[i, j] = (s2[i * 3 + j] - 'A');
                }
            }
            return getval() % 26;
        }
        public static int fmod(int val)
        {
            if (val % 26 >= 0) return val % 26;
            return val % 26 + 26;
        }
        static void Main(string[] args)
        {
            //密文:EXVGWMFNPAIBHDSCLSKDA
            //密鑰:GYBNQKURP
            while (true)
            {
                Console.Write("請輸入密文(長度為三的倍數):");
                string s = Console.ReadLine() + "";
                Console.Write("輸入密鑰(長度為九且可逆):");
                string s2 = Console.ReadLine() + "";
                if (s2.Length != 9)
                {
                    Console.WriteLine("密鑰字串長度必須是九!");
                    break;
                }
                int D_Inverse = createkey(s2);
                if (gcd(D_Inverse, 26) != 1)
                {
                    Console.WriteLine("請確認密鑰是可逆的!");
                    break;
                }
                int a = key[0, 0], b = key[0, 1], c = key[0, 2], d = key[1, 0], e = key[1, 1], f = key[1, 2], g = key[2, 0], h = key[2, 1], i = key[2, 2];
                int[,] Inverse = new int[3, 3] { {
                    (e * i - f * h), -(b * i - c * h), (b * f - c * e) },
                    { -(d * i - f * g), (a * i - c * g), -(a * f - c * d) },
                    { (d * h - e * g), -(a * h - b * g), (a * e - b * d) } };
                for(int i2 = 0; i2 < 3; i2++)
                {
                    for(int j = 0; j < 3; j++)
                    {
                        Inverse[i2, j] *= D_Inverse;
                    }
                }
                string result = "";
                for(int i2 = 0; i2 < s.Length; i2 += 3)
                {
                    int[] ans = new int[3];
                    int[] num = new int[3] { s[i2] - 'A', s[i2 + 1] - 'A', s[i2 + 2] - 'A' };
                    for(int j = 0; j < 3; j++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            ans[j] += num[k] * Inverse[j, k];
                        }
                    }
                    result += string.Join("", ans.Select(x => Convert.ToChar('A' + fmod(x))));
                }
                Console.WriteLine("明文:" + result);
                break;
            }
            Console.ReadKey();
        }
    }
}
