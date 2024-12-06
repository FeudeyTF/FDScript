namespace FeuDumScript.Lexer
{
    internal enum LexerTokenType
    {
        Name,
        Operation,
        EndOfLine,
        Number,
        String,
        Assignment,
        OpenFunction,
        CloseFunction,
    }
}
