namespace FeuDumScript.Parser.AbstractSyntaxTree.Nodes
{
    internal class BinOperator : Node
    {
        public string Operator { get; }

        public Node LeftNode { get; }

        public Node RightNode { get; }

        public BinOperator(string oper, Node leftNode, Node rightNode)
        {
            Operator = oper;
            LeftNode = leftNode;
            RightNode = rightNode;
        }

        public override string ToString()
        {
            return LeftNode + " " + Operator + " " + RightNode;
        }
    }
}
