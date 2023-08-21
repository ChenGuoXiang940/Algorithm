namespace 預測網站留言的情感
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var sampleData = new MLModel1.ModelInput()
                {
                    SentimentText = Console.ReadLine() + "",
                    LoggedIn = true
                };
                var result = MLModel1.Predict(sampleData);
                var sentiment = result.PredictedLabel == 1 ? "Positive" : "Negative";
                Console.WriteLine($"Text: {sampleData.SentimentText}\nSentiment: {sentiment}");
            }
        }
    }
}