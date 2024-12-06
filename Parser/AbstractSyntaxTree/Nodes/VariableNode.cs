namespace FeuDumScript.Parser.AbstractSyntaxTree.Nodes
{
    internal class VariableNode : Node
    {
        public string Name { get; }

        public VariableNode(string name)
        {
            Name = name;
        }

        public override string ToString() => Name;
    }
}
