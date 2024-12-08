using FeuDumScript.Program.Variables;

namespace FeuDumScript.Program
{
    public class FeuDumScriptProgram
    {
        internal List<Variable> Variables { get; private set; }

        private bool _executing;

        public FeuDumScriptProgram()
        {
            Variables = [];
            _executing = false;
        }

        public int Execute(string code)
        {
            _executing = true;
            LanguageParser parser = new(code);
            var tree = parser.ParseCode();
            var result = (int?)tree.Run(this);
            StopExecuting();
            if (result != null)
                return result.Value;
            else
                return -1;
        }

        public void StopExecuting()
        {
            if (_executing)
            {
                _executing = false;
                Variables = [];
            }
        }
    }
}
