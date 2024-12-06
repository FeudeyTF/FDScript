namespace FeuDumScript.Lexer.TokenParsers.Characters
{
    internal class CloseFunctionTokenParser : CharacterTokenParser
    {
        public override LexerTokenType TokenType => LexerTokenType.OpenFunction;

        protected override char Char => ')';
    }
}
