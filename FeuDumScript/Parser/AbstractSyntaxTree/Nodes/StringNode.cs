
namespace FeuDumScript.Parser.AbstractSyntaxTree.Nodes
{
    internal class StringNode : Node
    {
        public string Value { get; }

        public StringNode(string value)
        {
            Value = value;
        }

        public override object? Run(List<Variable> variables)
        {
            return Value.Replace("\"", "");
        }

        public override string ToString() => "(STRING)" + Value;
    }
}
