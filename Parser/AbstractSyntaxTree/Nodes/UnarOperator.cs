namespace FeuDumScript.Parser.AbstractSyntaxTree.Nodes
{
    internal class UnarOperator : Node
    {
        public string Operator { get; }

        public Node Node { get; }

        public UnarOperator(string oper, Node node)
        {
            Operator = oper;
            Node = node;
        }

        public override string ToString() => Operator + "(" + Node + ")";
    }
}
