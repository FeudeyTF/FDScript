using FeuDumScript.Parser;

namespace FeuDumScript
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string code = "testString = 'sas' + 1; printf('sas'); printf(testString);";
            LanguageParser parser = new(code);
            var tree =  parser.ParseCode();
            Console.WriteLine(tree);
        }
    }
}
