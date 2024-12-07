namespace FeuDumScript.Lexer.TokenParsers.Characters
{
    internal class CommaTokenParser : CharacterTokenParser
    {
        public override LexerTokenType TokenType => LexerTokenType.Comma;

        protected override char Char => ',';
    }
}
