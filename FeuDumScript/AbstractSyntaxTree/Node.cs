using FeuDumScript.Program;

namespace FeuDumScript.AbstractSyntaxTree
{
    public abstract class Node
    {
        public abstract object? Run(FeuDumScriptProgram program);
    }
}
