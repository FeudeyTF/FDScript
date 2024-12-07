using FeuDumScript.Lexer;

namespace FeuDumScript.Parser.AbstractSyntaxTree.Nodes
{
    internal class NumberNode : Node
    {
        public LexerToken Number { get; }

        public NumberNode(LexerToken number)
        {
            Number = number;
        }

        public override string ToString() => "(NUMBER)" + Number.Value;
    }
}
