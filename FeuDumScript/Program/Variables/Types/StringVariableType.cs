namespace FeuDumScript.Program.Variables.Types
{
    internal class StringVariableType : VariableType
    {
        public override string Name => "string";

        public override bool TryCast(object inVar, out object? outVar)
        {
            outVar = inVar.ToString();
            return true;
        }
    }
}
