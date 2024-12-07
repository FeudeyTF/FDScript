namespace FeuDumScript.Lexer.TokenParsers
{
    internal class NumberTokenParser : ILexerTokenParser
    {
        public LexerTokenType TokenType => LexerTokenType.Number;

        public bool TryParse(string code, out string? value)
        {
            string stringNumber = "";
            for (int i = 0; i < code.Length; i++)
            {
                var c = code[i].ToString();
                if (int.TryParse(c, out var num))
                    stringNumber += c;
                else
                    break;
            }

            if (!string.IsNullOrEmpty(stringNumber))
            {
                value = stringNumber;
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
