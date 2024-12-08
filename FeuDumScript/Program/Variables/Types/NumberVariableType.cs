namespace FeuDumScript.Program.Variables.Types
{
    internal class NumberVariableType : VariableType
    {
        public override string Name => "int"; 
        
        public override bool TryCast(object inValue, out object? outValue)
        {
            outValue = default;
            if (inValue is string str)
            {
                if (int.TryParse(str, out var number))
                {
                    outValue = number;
                    return true;
                }
            }
            return false;
        }
    }
}
