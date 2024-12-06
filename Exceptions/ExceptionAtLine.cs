namespace FeuDumScript.Exceptions
{
    internal class ExceptionAtLine : Exception
    {
        public string Exception;

        public int Position;

        public ExceptionAtLine(string exception, int position) : base(exception + " Line: " + position)
        {
            Exception = exception;
            Position = position;
        }
    }
}
