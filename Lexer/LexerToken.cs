namespace FeuDumScript.Lexer
{
    internal class LexerToken
    {
        public LexerTokenType Type;

        public string Value;

        public CodePosition Position;

        public LexerToken(LexerTokenType type, string value, CodePosition position)
        {
            Type = type;
            Value = value;
            Position = position;
        }

        public override string ToString() => Type + " " + Value;
    }
}
