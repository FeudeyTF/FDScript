namespace FeuDumScript.Lexer.TokenParsers
{
    internal abstract class CharacterTokenParser : ILexerTokenParser
    {
        protected abstract char Char { get; }

        public abstract LexerTokenType TokenType { get; }

        public bool TryParse(string code, out string? value)
        {
            if (code[0] == Char)
            {
                value = Char.ToString();
                return true;
            }
            value = null;
            return false;
        }
    }
}
