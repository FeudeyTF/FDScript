using FeuDumScript.Program;

namespace FeuDumScript.AbstractSyntaxTree.Nodes.Variables
{
    internal class VariableCallNode : VariableNode
    {
        public VariableCallNode(string name) : base(name)
        {
        }

        public override object? Run(FeuDumScriptProgram program)
        {
            foreach (var variable in program.Variables)
                if (variable.Name == Name)
                    return variable;
            throw new Exception("Variable " + Name + " not defined!");
        }

        public override string ToString() => "(CALL VAR)" + Name;
    }
}
