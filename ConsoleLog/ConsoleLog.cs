namespace ConsoleLog
{
    using ILog;
    public class ConsoleLog : ILog
    {
        public void Print(string[] str)
        {
            Console.Write("\t");
            foreach (string text in str)
                Console.Write(text);
            Console.WriteLine();
        }
    }
}
