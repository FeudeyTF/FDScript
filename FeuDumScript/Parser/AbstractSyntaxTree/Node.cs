namespace FeuDumScript.Parser.AbstractSyntaxTree
{
    public abstract class Node
    {
        public abstract object? Run(List<Variable> variables);
    }
}
