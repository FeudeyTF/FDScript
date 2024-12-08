namespace FeuDumScript.Program.Variables.Types
{
    internal class BooleanVariableType : VariableType
    {
        public override string Name => "bool";
        
        public override bool TryCast(object inValue, out object? outValue)
        {
            outValue = default;
            if (inValue is string str)
            {
                var value = str.ToLower();
                if (value == "true")
                {
                    outValue = true;
                    return true;
                }
                else if (value == "false")
                {
                    outValue = false;
                    return true;
                }
            }
            else if (inValue is int num)
            { 
                if (num == 0)
                {
                    outValue = false;
                    return true;
                }
                else
                {
                    outValue = true;
                    return true;
                }
            }
            return false;
        }
    }
}
