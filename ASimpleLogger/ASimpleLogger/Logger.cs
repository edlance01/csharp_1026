namespace ASimpleLogger
{
    public class Logger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine($"[LOG]: {message}");
        }

    }
}
