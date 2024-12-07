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
                    LanguageParser parser = new(File.ReadAllText(file));
                    var tree = parser.ParseCode();
                    Console.WriteLine(tree);
                    fileOpenedCounter++;
                }
            }

            Console.WriteLine($"Found {fileOpenedCounter} files!");
            while(true)
            {
                var command = Console.ReadLine();
                if (command == "exit")
                    Environment.Exit(0);
            }
        }
    }
}
