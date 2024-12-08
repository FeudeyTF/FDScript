namespace FeuDumScript.Program.Variables
{
    internal abstract class VariableType
    {
        public static List<VariableType> TYPES;

        static VariableType()
        {
            TYPES = [];
            Utils.FillClassCollection(ref TYPES);
        }

        public static VariableType? GetType(string name) 
            => TYPES.SingleOrDefault(v  => v.Name == name);

        public abstract string Name { get; }

        public abstract bool TryCast(object value, out object? outVar);
    }
}
