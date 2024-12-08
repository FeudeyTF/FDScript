using FeuDumScript.AbstractSyntaxTree.Nodes.Variables;
using FeuDumScript.Program;
using FeuDumScript.Program.Variables;

namespace FeuDumScript.AbstractSyntaxTree.Nodes
{
    internal class FunctionCallNode : Node
    {
        public string Name;

        public List<Node> Arguments = [];

        public FunctionCallNode(string name, List<Node> arguments)
        {
            Name = name;
            Arguments = arguments;
        }

        public override object? Run(FeuDumScriptProgram program)
        {
            List<object?> args = [];
            foreach(var arg in Arguments)
            {
                var result = arg.Run(program) ?? throw new Exception("Some of argument is null!");
                if (result is Variable var)
                {
                    if(var.Value == null)
                        throw new Exception("Variable " + var.Name + " is null!");
                    args.Add(var.Value);
                }
                else
                    args.Add(result);
            }
            switch (Name)
            {
                case "printf":
                    if (args.Count == 1)
                        Console.WriteLine(args.First());
                    else if (args.Count > 1)
                        Console.WriteLine(args.First().ToString(), arg: [.. args[1..]]);
                    else
                        Console.WriteLine();
                    return args;
                case "rand":
                    return Random.Shared.Next();
                default:
                    throw new Exception("Invalid function!");
            }
        }

        public override string ToString() => Name + "(" + string.Join(", ", Arguments) + ")";
    }
}
