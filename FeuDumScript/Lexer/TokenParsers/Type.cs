using FeuDumScript.Program.Variables;

namespace FeuDumScript.Lexer.TokenParsers
{
    internal class TypeTokenParser : ILexerTokenParser
    {
        public LexerTokenType TokenType => LexerTokenType.Type;

        public bool TryParse(string code, out string? value)
        {
            foreach(var type in VariableType.TYPES)
                if(code.StartsWith(type.Name + " "))
                {
                    value = type.Name;
                    return true;
                }
            value = null;
            return false;
        }
    }
}
