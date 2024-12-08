using FeuDumScript.Program;

namespace FeuDumScript.AbstractSyntaxTree
{
    internal class HeadNode : Node
    {
        public readonly List<Node> Nodes;

        public HeadNode()
        {
            Nodes = [];
        }

        public override object Run(FeuDumScriptProgram program)
        {
            foreach (var node in Nodes)
                node.Run(program);
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