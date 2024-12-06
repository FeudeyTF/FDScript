namespace FeuDumScript.Lexer.TokenParsers
{
    internal class StringTokenParser : ILexerTokenParser
    {
        public LexerTokenType TokenType => LexerTokenType.String;

        public static readonly List<char> STRING_START_CHARACTERS = ['"', '\'', '`'];

        public bool TryParse(string code, out string? value)
        {
            string result = "";
            if (STRING_START_CHARACTERS.Contains(code[0]))
            {
                char startChar = code[0];
                for (int i = 0; i < code.Length; i++)
                {
                    result += code[i];
                    if (i > 0 && code[i] == startChar)
                    {
                        value = result;
                        return true;
                    }
                }

            }

            value = null;
            return false;
        }
    }
}