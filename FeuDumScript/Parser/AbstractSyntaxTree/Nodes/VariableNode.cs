
namespace FeuDumScript.Parser.AbstractSyntaxTree.Nodes
{
    internal class VariableNode : Node
    {
        public string Name { get; }

        public VariableNode(string name)
        {
            Name = name;
        }

        public override object? Run(List<Variable> variables)
        {
            foreach (var variable in variables)
                if (variable.Name == Name)
                    return variable.Value;
            variables.Add(new(Name, default));
            return default;
        }

        public override string ToString() => "(VAR)" + Name;
    }
}
