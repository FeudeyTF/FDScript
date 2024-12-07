namespace FeuDumScript.Parser.AbstractSyntaxTree.Nodes
{
    internal class StringNode : Node
    {
        public string Value { get; }

        public StringNode(string value)
        {
            Value = value;
        }

        public override string ToString() => "(STRING)" + Value;
    }
}
