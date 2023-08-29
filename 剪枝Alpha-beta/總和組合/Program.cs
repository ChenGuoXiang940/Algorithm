namespace 總和組合
{
    internal class Program
    {
        //回溯法function，用於遞迴搜尋可能的解
        public static void combinationSumHelper(int[]candidates,int target,int start,Stack<int> combination)
        {
            if (target < 0) return;
            else if (target == 0)
            {
                //輸出找到的符合條件的組合
                Console.WriteLine(string.Join(" ", combination));
                return;
            }
            for(int i = start; i < candidates.Length; i++)
            {
                combination.Push(candidates[i]);
                combinationSumHelper(candidates, target - candidates[i], i, combination);
                combination.Pop();
            }
        }
        static void Main(string[] args)
        {
            //使用回溯法(遞迴)和剪枝(不計算接下來不可能的解)
            //想提高執行效率請查看硬幣組合(DP)
            int[] candidates = new int[] { 4, 3, 2, 7 };
            int target = 7;
            combinationSumHelper(candidates, target, 0, new Stack<int>());
            Console.ReadKey();
        }
    }
}