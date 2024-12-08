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

        public override object? Run(List<Variable> variables)
        {
            return int.Parse(Number.Value);
        }

        public override string ToString() => "(NUMBER)" + Number.Value;
    }
}
