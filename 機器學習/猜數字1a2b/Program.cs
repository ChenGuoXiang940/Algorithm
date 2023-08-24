
class Program
{
    public static Random rnd = new Random();
    public static bool check()
    {
        while(true)
        {
            Console.Write("是否要繼續?(y:是;n:否):");
            ConsoleKeyInfo info = Console.ReadKey();
            switch(info.Key)
            {
                case ConsoleKey.Y:
                    return true;
                case ConsoleKey.N:
                    return false;
                default:
                    continue;
            }
        }
    }
    /*
     * 猜數字 1a2b
     * 先列舉出所有的解(數字不能重複 最低 0123 到最高 9999 )
     * 以同樣的 NaNb 慢慢所縮小範圍直到 4a 結束
     * 鍵盤觸發事件判斷是否要繼續
     */
    static void Main(string[] args)
    {
        int answer;
        do
        {
            while (HasDuplicateDigits(answer = rnd.Next(0123, 10000))) { }
            Console.WriteLine($"隨機目標為:{answer.ToString().PadLeft(4, '0')}\r\n開始猜數字...");
            int attempts = 0;
            Queue<int> possibleGuesses = GenerateAllPossibleGuesses();
            while (attempts++ < 10)
            {
                int guess = possibleGuesses.Peek();
                int[] feedback = GetFeedback(answer, guess);
                Console.WriteLine($"{string.Join("", guess).PadLeft(4, '0')}\t{feedback[0]}A{feedback[1]}B\t{possibleGuesses.Count}");
                if (feedback[0] == 4) break;
                possibleGuesses = UpdatePossibleGuesses(possibleGuesses, guess, feedback);
            }
            Console.WriteLine($"Bingo!\t次數:{attempts}");
        } while (check());
    }
    static bool HasDuplicateDigits(int number)
    {
        int digitMask = 0;
        while (number > 0)
        {
            int digit = number % 10;
            int digitBit = 1 << digit;
            if ((digitMask & digitBit) != 0)
            {
                return true;
            }
            digitMask |= digitBit;
            number /= 10;
        }
        return false;
    }
    static Queue<int> GenerateAllPossibleGuesses()
    {
        Queue<int> possibleGuesses = new Queue<int>();
        for(int i = 0123; i < 10000; i++)
        {
            if (!HasDuplicateDigits(i)) possibleGuesses.Enqueue(i);
        }
        return possibleGuesses;
    }
    static int[] GetFeedback(int answer, int guess)
    {
        int[] feedback = new int[2];
        List<int> buffer = answer.ToString().ToCharArray().Select(item=>int.Parse(item.ToString())).ToList();
        for(int i = 0; i < 4; i++)
        {
            int answer_cur = answer % 10;
            int guess_cur = guess % 10;
            if (answer_cur == guess_cur)
            {
                feedback[0]++;
            }
            else if (buffer.Contains(guess_cur))
            {
                feedback[1]++;
            }
            answer /= 10;
            guess /= 10;
        }
        return feedback;
    }

    static Queue<int> UpdatePossibleGuesses(Queue<int> possibleGuesses, int guess, int[] feedback)
    {
        Queue<int> newPossibleGuesses = new Queue<int>();
        foreach (var possibleGuess in possibleGuesses)
        {
            int[] possibleFeedback = GetFeedback(possibleGuess, guess);
            if (possibleFeedback[0] == feedback[0] && possibleFeedback[1] == feedback[1])
            {
                newPossibleGuesses.Enqueue(possibleGuess);
            }
        }
        return newPossibleGuesses;
    }
}
