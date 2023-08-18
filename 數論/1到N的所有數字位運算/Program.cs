namespace _1到N的所有數字位運算
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //時間複雜度是 O(log N)
            long N = long.Parse(Console.ReadLine());
            long powerOfTwo = 1;
            long totalBits = 0;
            while (powerOfTwo <= N)
            {
                long quotient = N / (powerOfTwo << 1); //計算商
                long remainder = N % (powerOfTwo << 1);//計算餘數
                Console.WriteLine($"商:{quotient}\t餘:{remainder} 2:{powerOfTwo}");
                totalBits += quotient * powerOfTwo;    //各個二進制位（從個位、十位、百位等）上1的總數
                /*處理特殊情況*/
                //高位超過powerOfTwo Ex1.15%2=7...1 少算15。 Ex2.14%4=3...2 少算14。 Ex3.14%8=1...6 少算12、13、14
                if (remainder >= powerOfTwo)totalBits += remainder - powerOfTwo + 1;
                powerOfTwo <<= 1;
            }
            Console.WriteLine(totalBits);
            Console.ReadKey();
        }
    }
}