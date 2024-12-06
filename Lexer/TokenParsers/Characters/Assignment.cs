namespace FeuDumScript.Lexer.TokenParsers
{
    internal class AssignmentTokenParser : CharacterTokenParser
    {
        public override LexerTokenType TokenType => LexerTokenType.Assignment;

        protected override char Char => '='; 
    }
}
