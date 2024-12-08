namespace FeuDumScript.Parser.AbstractSyntaxTree.Nodes
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

        public override object? Run(List<Variable> variables)
        {
            var args = Arguments.Select(a => a.Run(variables)).ToList();
            foreach (var arg in args)
                if (arg == null)
                    throw new Exception("The variable does't exists!");
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
