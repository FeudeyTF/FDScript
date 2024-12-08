namespace FeuDumScript.Lexer.TokenParsers
{
    internal class BooleanTokenParser : ILexerTokenParser
    {
        public static readonly List<string> STATES = ["true", "false"];

        public LexerTokenType TokenType => LexerTokenType.Boolean;

        public bool TryParse(string code, out string? value)
        {
            foreach (var state in STATES)
                if (code.StartsWith(state))
                {
                    value = state;
                    return true;
                }
            value = default;
            return false;
        }
    }
}
