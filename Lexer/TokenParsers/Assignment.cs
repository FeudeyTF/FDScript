namespace FeuDumScript.Lexer.TokenParsers
{
    internal class AssignmentTokenParser : ILexerTokenParser
    {
        public LexerTokenType TokenType => LexerTokenType.Assignment;

        public bool TryParse(string code, out string? value)
        {
            if (code[0] == '=')
            {
                value = "=";
                return true;
            }
            value = null;
            return false;
        }
    }
}
