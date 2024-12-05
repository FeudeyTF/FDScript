namespace FeuDumScript.Lexer.TokenParsers
{
    internal class NameTokenParser : ILexerTokenParser
    {
        public LexerTokenType TokenType => LexerTokenType.Name;

        private const string ALPHABET = "0123456789QWERTYUIOPASDFGHJKLZXCVBNM";

        public bool TryParse(string code, out string? value)
        {
            string variableName = "";
            if (!int.TryParse(code[0].ToString(), out _))
            {
                for (int i = 0; i < code.Length; i++)
                {
                    if (ALPHABET.Contains(code[i].ToString(), StringComparison.CurrentCultureIgnoreCase))
                        variableName += code[i];
                    else
                        break;
                }
            }

            if (!string.IsNullOrEmpty(variableName))
            {
                value = variableName;
                return true;
            }
            else
            {
                value = null;
                return false;
            }
        }
    }
}
