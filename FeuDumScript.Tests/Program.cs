using FeuDumScript.Parser;

namespace FeuDumScript.Tests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LanguageParser parser = new("testName='sas';");
            var tree = parser.ParseCode();
            Console.WriteLine(tree);
        }
    }
}
