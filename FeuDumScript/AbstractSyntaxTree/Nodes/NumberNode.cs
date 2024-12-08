using FeuDumScript.Lexer;
using FeuDumScript.Program;

namespace FeuDumScript.AbstractSyntaxTree.Nodes
{
    internal class NumberNode : Node
    {
        public LexerToken Number { get; }

        public NumberNode(LexerToken number)
        {
            Number = number;
        }

        public override object? Run(FeuDumScriptProgram program)
        {
            return int.Parse(Number.Value);
        }

        public override string ToString() => "(NUMBER)" + Number.Value;
    }
}
