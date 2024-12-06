namespace FeuDumScript.Lexer.TokenParsers.Characters
{
    internal class OpenFunctionTokenParser : CharacterTokenParser
    {
        public override LexerTokenType TokenType => LexerTokenType.OpenFunction;

        protected override char Char => '(';
    }
}
