namespace FeuDumScript.Lexer
{
    internal enum LexerTokenType
    {
        Name,
        Operation,
        EndOfLine,
        Number,
        String,
        Boolean,
        Type,
        Assignment,
        OpenFunction,
        CloseFunction,
        Comma
    }
}
