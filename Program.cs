using FeuDumScript.Lexer;

namespace FeuDumScript
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LanguageLexer lexer = new("testString = \"Test\"");
            var result = lexer.Parse();
        }
    }
}
