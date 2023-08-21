namespace 機器學習訓練
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var sampleData = new MLModel1.ModelInput()
                {
                    Col0 = Console.ReadLine() + ""
                };
                var result = MLModel1.Predict(sampleData);
                var sentiment = result.PredictedLabel == 1 ? "Positive" : "Negative";
                Console.WriteLine($"Text: {sampleData.Col0}\nSentiment: {sentiment}");
            }
        }
    }
}