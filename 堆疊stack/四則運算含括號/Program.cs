namespace 四則運算含括號
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> cmp = new Dictionary<char, int> { { '+', 1 }, { '-', 1 }, { '*', 2 }, { '/', 2 }, { '(', -1 } };
            Dictionary<char, Func<int, int, int>> figure = new Dictionary<char, Func<int, int, int>>
            {
                { '+', (a, b) => a + b },{ '-', (a, b) => a - b },{ '*', (a, b) => a * b },{ '/', (a, b) => b != 0 ? a / b : 0 }
            };
            string text = "((1+9*1)*10)+10+((2*1+1+3*2+1)*(5+5))";
            text += ")";
            Stack<int> number = new Stack<int>();
            List<char> op = new List<char>();
            string data = "";
            foreach (char ch in text)
            {
                switch (ch)
                {
                    case '(':
                        op.Add('(');
                        break;
                    case ')':
                        if (data != "") number.Push(int.Parse(data));
                        data = "";
                        while (op.Count != 0 && op.Last() != '(')
                        {
                            if (figure.TryGetValue(op.Last(), out var oper))
                            {
                                number.Push(oper(number.Pop(), number.Pop()));
                                op.RemoveAt(op.Count - 1);
                            }
                        }
                        if (op.Count > 1) op.RemoveAt(op.Count - 1);//移除左括號
                        break;
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                        if (data != "") number.Push(int.Parse(data));
                        data = "";
                        while (op.Count != 0 && cmp[ch] <= cmp[op.Last()])
                        {
                            if (figure.TryGetValue(op.Last(), out var oper))
                            {
                                number.Push(oper(number.Pop(), number.Pop()));
                                op.RemoveAt(op.Count - 1);
                            }
                        }
                        op.Add(ch);
                        break;
                    default:
                        data += ch;
                        break;
                }
            }
            Console.WriteLine($"Result:{number.Peek()}");
            Console.ReadKey();
        }
    }
}