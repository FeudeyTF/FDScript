using FeuDumScript.AbstractSyntaxTree.Nodes.Variables;
using FeuDumScript.Lexer;
using FeuDumScript.Program;
using FeuDumScript.Program.Variables;

namespace FeuDumScript.AbstractSyntaxTree.Nodes
{
    internal class AssignmentNode : Node
    {
        public LexerToken Assignment;

        public VariableNode LeftNode;

        public Node RightNode;

        public AssignmentNode(LexerToken assignment, VariableNode leftNode, Node rightNode)
        {
            Assignment = assignment;
            LeftNode = leftNode;
            RightNode = rightNode;
        }

        public override object? Run(FeuDumScriptProgram program)
        {
            var result = RightNode.Run(program);
            var variable = LeftNode.Run(program);

            if (variable != null && variable is Variable var)
            {
                if (result != null)
                {
                    if (var.Type.TryCast(result, out var value) && value != null)
                    {
                        var.Value = value;
                        return null;
                    }
                    throw new Exception("Can't cast " + result + " to type " + var.Type.Name);

                }
                else
                    var.Value = null;
            }
            throw new Exception("Variable " + LeftNode.Name + " not defined!");
        }

        public override string ToString() => LeftNode + " = " + RightNode;
    }
}
