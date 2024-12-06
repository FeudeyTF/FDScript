namespace FeuDumScript.Parser.AbstractSyntaxTree
{
    internal class HeadNode : Node
    {
        public readonly List<Node> Nodes;

        public HeadNode()
        {
            Nodes = [];
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