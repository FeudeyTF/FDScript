using FeuDumScript.Program;

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
                    FeuDumScriptProgram program = new();
                    var exitCode = program.Execute(File.ReadAllText(file));
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
