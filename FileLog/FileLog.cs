namespace FileLog
{
    using ILog;
    public class FileLog : ILog
    {
        public void Print(string[] str)
        {
            StreamWriter fileWriter = new StreamWriter("Storage Medium.txt", true);
            foreach (string text in str)
                fileWriter.Write(text);
            fileWriter.WriteLine();
            fileWriter.Close();
        }
    }
}
