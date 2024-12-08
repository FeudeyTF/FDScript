using FeuDumScript.Lexer;
using FeuDumScript.Program;

namespace FeuDumScript.AbstractSyntaxTree.Nodes.TypeNodes
{
    internal class BooleanNode : TypeNode
    {
        public override string TypeName => "bool";

        public LexerToken Bool { get; }

        public BooleanNode(LexerToken boolean)
        {
            Bool = boolean;
        }

        public override object? Run(FeuDumScriptProgram program)
        {
            return Bool.Value == "true";
        }
    }
}
