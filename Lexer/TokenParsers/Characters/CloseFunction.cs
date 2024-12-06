namespace FeuDumScript.Lexer.TokenParsers.Characters
{
    internal class CloseFunctionTokenParser : CharacterTokenParser
    {
        public override LexerTokenType TokenType => LexerTokenType.CloseFunction;

        protected override char Char => ')';
    }
}
