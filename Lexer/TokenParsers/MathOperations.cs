namespace FeuDumScript.Lexer.TokenParsers
{
    internal class MathOperationsTokenParser : ILexerTokenParser
    {
        private static readonly List<char> _operations = [ '*', '/', '+', '-'];

        public LexerTokenType TokenType => LexerTokenType.Operation;

        public bool TryParse(string code, out string? value)
        {
            if (_operations.Contains(code[0]))
            {
                value = code[0].ToString();
                return true;
            }
            value = null;
            return false;
        }
    }
}
