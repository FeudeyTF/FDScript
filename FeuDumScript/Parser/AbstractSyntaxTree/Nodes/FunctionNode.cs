namespace FeuDumScript.Parser.AbstractSyntaxTree.Nodes
{
    internal class FunctionNode : Node
    {
        public string Name;

        public List<Node> Arguments = [];

        public FunctionNode(string name, List<Node> arguments)
        {
            Name = name;
            Arguments = arguments;
        }

        public override string ToString() => Name + "(" + string.Join(", ", Arguments) + ")";
    }
}
