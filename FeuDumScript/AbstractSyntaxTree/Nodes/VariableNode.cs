using FeuDumScript.Program;

namespace FeuDumScript.AbstractSyntaxTree.Nodes
{
    internal class VariableNode : Node
    {
        public string Name { get; }

        public VariableNode(string name)
        {
            Name = name;
        }

        public override object? Run(FeuDumScriptProgram program)
        {
            foreach (var variable in program.Variables)
                if (variable.Name == Name)
                    return variable.Value;
            program.Variables.Add(new(Name, default));
            return default;
        }

        public override string ToString() => "(VAR)" + Name;
    }
}
