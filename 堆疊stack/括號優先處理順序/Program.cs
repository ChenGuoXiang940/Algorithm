namespace 括號優先處理順序
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //括號內要先做
            string text = "((AB)C)D((EF)G)H";
            text += ")";
            Stack<char> sk = new Stack<char>();
            int count = 1;
            foreach(char ch in text)
            {
                switch (ch)
                {
                    case ')':
                        while(sk.Count != 0 && sk.Peek() != '(')
                        {
                            Console.WriteLine($"{count++}:{sk.Pop()}");
                        }
                        if (sk.Count > 0) sk.Pop();
                        break;
                    default:
                        sk.Push(ch);
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}