namespace FeuDumScript.Lexer
{
    internal interface ILexerTokenParser
    {
        public LexerTokenType TokenType { get; }

        public bool TryParse(string code, out string? value);
    }
}
