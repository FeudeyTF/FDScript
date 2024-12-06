using FeuDumScript.Lexer;

namespace FeuDumScript
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LanguageLexer lexer = new("testString = \"Test\"; Console.WriteLine(`test`);");
            var result = lexer.Parse();
            Console.WriteLine(string.Join("\n", result));
        }
    }
}
