
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

        public override object? Run(List<Variable> variables)
        {
            return 0;
        }


        public override string ToString() => Operator + "(" + Node + ")";
    }
}
