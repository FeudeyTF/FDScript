using FeuDumScript.Program;

namespace FeuDumScript.AbstractSyntaxTree.Nodes.TypeNodes
{
    internal class StringNode : TypeNode
    {
        public override string TypeName => "string";

        public string Value { get; }

        public StringNode(string value)
        {
            Value = value;
        }

        public override object? Run(FeuDumScriptProgram program)
        {
            return Value.Replace("\"", "");
        }

        public override string ToString() => "(STRING)" + Value;
    }
}
