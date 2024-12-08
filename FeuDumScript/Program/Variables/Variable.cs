namespace FeuDumScript.Program.Variables
{
    internal class Variable
    {
        public string Name { get; }

        public VariableType Type { get; private set; }

        public object? Value { get; set; }

        public Variable(string name, object? value, string typeName)
        {
            Name = name;
            Value = value;
            var type = VariableType.GetType(typeName);
            if (type != null)
                Type = type;
            else
                throw new Exception("Can't find type " + typeName);
        }
    }
}
