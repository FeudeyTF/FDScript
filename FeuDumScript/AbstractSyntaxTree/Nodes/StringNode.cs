using FeuDumScript.Program;

namespace FeuDumScript.AbstractSyntaxTree.Nodes
{
    internal class StringNode : Node
    {
        public string Value { get; }

        public StringNode(string value)
        {
            Value = value;
        }

        public override object? Run(FeuDumScriptProgram program)
        {
            return Value.Replace("\"", "");
        }

        public override string ToString() => "(STRING)" + Value;
    }
}
