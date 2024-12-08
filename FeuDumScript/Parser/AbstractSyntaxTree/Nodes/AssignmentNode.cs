using FeuDumScript.Lexer;

namespace FeuDumScript.Parser.AbstractSyntaxTree.Nodes
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

        public override object? Run(List<Variable> variables)
        {
            var result = RightNode.Run(variables);
            foreach (var variable in variables)
            {
                if(variable.Name == LeftNode.Name)
                {
                    variable.Value = result;
                    return result;
                }
            }
            variables.Add(new(LeftNode.Name, result));
            return result;
        }

        public override string ToString() => LeftNode + " = " + RightNode;
    }
}
