using FeuDumScript.Program.Variables;

namespace FeuDumScript.Lexer.TokenParsers
{
    internal class NameTokenParser : ILexerTokenParser
    {
        public LexerTokenType TokenType => LexerTokenType.Name;

        private const string ALPHABET = "0123456789QWERTYUIOPASDFGHJKLZXCVBNM_";

        public bool TryParse(string code, out string? value)
        {
            string name = "";
            if (!int.TryParse(code[0].ToString(), out _))
            {
                for (int i = 0; i < code.Length; i++)
                {
                    if (ALPHABET.Contains(code[i].ToString(), StringComparison.CurrentCultureIgnoreCase))
                        name += code[i];
                    else
                        break;
                }
            }

            if (!string.IsNullOrEmpty(name) && !VariableType.TYPES.Any(v => v.Name == name) && !BooleanTokenParser.STATES.Contains(name))
            {
                value = name;
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
