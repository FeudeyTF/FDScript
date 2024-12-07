namespace FeuDumScript.Lexer
{
    internal struct CodePosition
    {
        public int Column;

        public int Raw;

        public CodePosition(int column, int raw)
        {
            Column = column;
            Raw = raw;
        }
    }
}
