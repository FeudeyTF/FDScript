namespace FeuDumScript.Parser.AbstractSyntaxTree
{
    internal class HeadNode : Node
    {
        public readonly List<Node> Nodes;

        public HeadNode()
        {
            Nodes = [];
        }

        public override object Run(List<Variable> variables)
        {
            foreach (var node in Nodes)
                node.Run(variables);
            return 0;
        }

        public override string ToString()
        {
            string result = string.Empty;
            foreach (var node in Nodes)
            {
                result += node.ToString() + '\n';
            }
            return result;
        }
    }
}