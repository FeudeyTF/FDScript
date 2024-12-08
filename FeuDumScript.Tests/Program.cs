using FeuDumScript.Parser;

namespace FeuDumScript.Tests
{
    internal class Program
    {
        public const string FILE_EXTENSION = ".fds";

        static void Main(string[] args)
        {
            int fileOpenedCounter = 0;
            foreach(var file in Directory.GetFiles(Environment.CurrentDirectory))
            {
                if(file.EndsWith(FILE_EXTENSION))
                {
                    Console.WriteLine($"Found {Path.GetFileName(file)}!");
                    LanguageParser parser = new(File.ReadAllText(file));
                    var exitCode = parser.RunCode();
                    Console.WriteLine("Program exit with code " + exitCode);
                    fileOpenedCounter++;
                }
            }

            while(true)
            {
                var command = Console.ReadLine();
                if (command == "exit")
                    Environment.Exit(0);
            }
        }
    }
}
