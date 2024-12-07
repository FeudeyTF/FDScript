namespace FeuDumScript.Lexer.TokenParsers.Characters
{
    internal class EndOfLineTokenParser : CharacterTokenParser
    {
        public override LexerTokenType TokenType => LexerTokenType.EndOfLine;

        protected override char Char => ';';
    }
}
