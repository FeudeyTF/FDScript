using FeuDumScript.AbstractSyntaxTree;
using FeuDumScript.AbstractSyntaxTree.Nodes;
using FeuDumScript.AbstractSyntaxTree.Nodes.TypeNodes;
using FeuDumScript.AbstractSyntaxTree.Nodes.Variables;
using FeuDumScript.Exceptions;
using FeuDumScript.Lexer;

namespace FeuDumScript
{
    public class LanguageParser
    {
        private readonly List<LexerToken> _tokens;

        private readonly LanguageLexer _lexer;

        private int _position;

        public LanguageParser(string code)
        {
            _tokens = [];
            _position = 0;
            _lexer = new(code);
            _tokens = _lexer.Parse();
        }

        private Node ParseExpressionPart()
        {
            if (GetNextToken(LexerTokenType.OpenFunction) != null)
            {
                var node = ParseExpression();
                Require(LexerTokenType.CloseFunction);
                return node;
            }
            else
                return ParseObject();
        }

        private Node ParseObject()
        {
            var token = GetNextToken(LexerTokenType.Number, LexerTokenType.String, LexerTokenType.Name, LexerTokenType.Boolean);
            if (token != null)
            {
                switch (token.Type)
                {
                    case LexerTokenType.Number:
                        return new NumberNode(token);
                    case LexerTokenType.Name:
                        if (GetNextToken(LexerTokenType.OpenFunction) != null)
                            return ParseFunctionCall(token.Value);
                        return new VariableCallNode(token.Value);
                    case LexerTokenType.String:
                        return new StringNode(token.Value);
                    case LexerTokenType.Boolean:
                        return new BooleanNode(token);
                }
            }
            throw new ExceptionAtLine("Invalid object!", _position);
        }

        private Node ParseExpression()
        {
            var leftNode = ParseExpressionPart();
            var oper = GetNextToken(LexerTokenType.Operation);
            while(oper != null)
            {
                var rightNode = ParseExpressionPart();
                leftNode = new BinOperator(oper.Value, leftNode, rightNode);
                oper = GetNextToken(LexerTokenType.Operation);
            }
            return leftNode;
        }

        private List<Node> ParseFunctionArguments(List<Node> args)
        {
            var node = ParseExpression();
            args.Add(node);
            var getNextToken = GetNextToken(LexerTokenType.Comma, LexerTokenType.CloseFunction);
            if (getNextToken != null)
            {
                if (getNextToken.Type == LexerTokenType.CloseFunction)
                    return args;
                else
                    return ParseFunctionArguments(args);
            }
            throw new ExceptionAtLine("Function arguments parse failed!", _position);
        }

        private Node ParseLine()
        {
            var typeToken = GetNextToken(LexerTokenType.Type);
            if(typeToken != null)
            {
                var variableName = Require(LexerTokenType.Name);
                var isAssign = GetNextToken(LexerTokenType.Assignment);
                if (isAssign != null)
                    return new AssignmentNode(isAssign, new VariableDefineNode(variableName.Value, typeToken.Value), ParseExpression());
                else
                    return new VariableDefineNode(variableName.Value, typeToken.Value);
            }
            else
            {
                var name = GetNextToken(LexerTokenType.Name);
                if(name != null)
                {
                    if (GetNextToken(LexerTokenType.OpenFunction) != null)
                        return ParseFunctionCall(name.Value);
                    else
                    {
                        var assign = Require(LexerTokenType.Assignment);
                        return new AssignmentNode(assign, new VariableCallNode(name.Value), ParseExpression());
                    }
                }
               
            }
            throw new ExceptionAtLine("You need to invoke method or assign variable!",  _position);
        }

        private FunctionCallNode ParseFunctionCall(string name)
        {
            if (GetNextToken(LexerTokenType.CloseFunction) != null)
                return new FunctionCallNode(name, []);
            List<Node> args = [];
            ParseFunctionArguments(args);
            return new FunctionCallNode(name, args);
        }

        internal HeadNode ParseCode()
        {
            HeadNode head = new();
            while(_position < _tokens.Count)
            {
                var lineNode = ParseLine();
                Require(LexerTokenType.EndOfLine);
                head.Nodes.Add(lineNode);
            }
            return head;
        }

        private LexerToken? GetNextToken(params List<LexerTokenType> requirements)
        {
            if (_position < _tokens.Count)
            {
                var currentToken = _tokens[_position];
                if (requirements.Any(t => t == currentToken.Type))
                {
                    _position++;
                    return currentToken;
                }
            }
            return null;
        }

        private LexerToken Require(params List<LexerTokenType> requirements)
        {
            if (_position < _tokens.Count)
            {
                var currentToken = GetNextToken(requirements);
                if (currentToken != null)
                    return currentToken;
            }
            throw new ExceptionAtLine($"{string.Join(", ", requirements)} is require", _position);
        }
    }
}