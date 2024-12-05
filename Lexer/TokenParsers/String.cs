namespace FeuDumScript.Lexer.TokenParsers
{
    internal class StringTokenParser : ILexerTokenParser
    {
        public LexerTokenType TokenType => LexerTokenType.String;

        public bool TryParse(string code, out string? value)
        {
            string result = "";
            if (code[0] == '"')
            {
                for (int i = 0; i < code.Length; i++)
                {
                    result += code[i];
                    if (i > 0 && i == '"')
                        break;
                }
            }

            if (result.StartsWith('"') && result.EndsWith('"'))
            {
                value = result;
                return true;
            }
            value = null;
            return false;
        }
    }
}