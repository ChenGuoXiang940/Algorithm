namespace _1到N的所有數字位運算
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //時間複雜度是 O(log N)
            long N = long.Parse(Console.ReadLine() + "");
            long powerOfTwo = 1;
            long totalBits = 0;
            while (powerOfTwo <= N)
            {
                long quotient = N / (powerOfTwo << 1); //計算商
                long remainder = N % (powerOfTwo << 1);//計算餘數
                Console.WriteLine($"商:{quotient}\t餘:{remainder}\t2:{powerOfTwo}");
                totalBits += quotient * powerOfTwo;    //各個二進制位（從個位、十位、百位等）上1的總數
                /*處理特殊情況*/
                //高位超過powerOfTwo Ex1.10/(2^2)=2...2 少算10(10'1'0) Ex2.10/(2^4)=0...16 少算8,9,10('1'000,'1'001,'1'010)
                if (remainder >= powerOfTwo)
                {
                    totalBits += remainder - powerOfTwo + 1;
                    Console.WriteLine($"{remainder - powerOfTwo + 1}");
                }
                powerOfTwo <<= 1;
            }
            Console.WriteLine($"total:{totalBits}");
            Console.ReadKey();
        }
    }
}
/*
10  ( 0000,0001,0010,0011,0100,0101,0110,0111,1000,1001,1010 共 17 個 '1')
商:5    餘:0    2:1   5x1=5
商:2    餘:2    2:2   2x2=4
1
商:1    餘:2    2:4   1x4=4
商:0    餘:10   2:8   0x8=0
3
total:5+4+1+4+0+3=17

 */