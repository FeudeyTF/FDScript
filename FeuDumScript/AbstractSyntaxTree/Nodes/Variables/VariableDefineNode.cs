using FeuDumScript.Program;
using FeuDumScript.Program.Variables;

namespace FeuDumScript.AbstractSyntaxTree.Nodes.Variables
{
    internal class VariableDefineNode : VariableNode
    {
        public string TypeName { get; }

        public VariableDefineNode(string name, string typeName) : base(name)
        {
            TypeName = typeName;
        }

        public override object? Run(FeuDumScriptProgram program)
        {
            foreach (var variable in program.Variables)
                if (variable.Name == Name)
                    throw new Exception("Variable " + Name + " is already defined!");
            Variable var = new(Name, default, TypeName);
            program.Variables.Add(var);
            return var;
        }
    }
}
