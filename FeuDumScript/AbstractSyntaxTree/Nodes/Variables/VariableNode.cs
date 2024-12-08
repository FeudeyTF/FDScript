namespace FeuDumScript.AbstractSyntaxTree.Nodes.Variables
{
    internal abstract class VariableNode : Node
    {
        public string Name { get; }

        public VariableNode(string name)
        {
            Name = name;
        }

        public override string ToString() => "(VAR)" + Name;
    }
}
