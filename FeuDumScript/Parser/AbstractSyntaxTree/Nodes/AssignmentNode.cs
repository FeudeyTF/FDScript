using FeuDumScript.Lexer;

namespace FeuDumScript.Parser.AbstractSyntaxTree.Nodes
{
    internal class AssignmentNode : Node
    {
        public Node LeftNode;

        public Node RightNode;

        public AssignmentNode(LexerToken assignment, Node leftNode, Node rightNode)
        {
            LeftNode = leftNode;
            RightNode = rightNode;
        }

        public override string ToString() => LeftNode + " = " + RightNode;
    }
}
