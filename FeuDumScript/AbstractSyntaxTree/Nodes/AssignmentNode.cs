using FeuDumScript.Lexer;
using FeuDumScript.Program;

namespace FeuDumScript.AbstractSyntaxTree.Nodes
{
    internal class AssignmentNode : Node
    {
        public VariableNode LeftNode;

        public Node RightNode;

        public AssignmentNode(LexerToken assignment, VariableNode leftNode, Node rightNode)
        {
            LeftNode = leftNode;
            RightNode = rightNode;
        }

        public override object? Run(FeuDumScriptProgram program)
        {
            var result = RightNode.Run(program);
            foreach (var variable in program.Variables)
            {
                if(variable.Name == LeftNode.Name)
                {
                    variable.Value = result;
                    return result;
                }
            }
            program.Variables.Add(new(LeftNode.Name, result));
            return result;
        }

        public override string ToString() => LeftNode + " = " + RightNode;
    }
}
