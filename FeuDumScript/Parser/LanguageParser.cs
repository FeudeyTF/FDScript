using FeuDumScript.Exceptions;
using FeuDumScript.Lexer;
using FeuDumScript.Parser.AbstractSyntaxTree;
using FeuDumScript.Parser.AbstractSyntaxTree.Nodes;

namespace FeuDumScript.Parser
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
            {
                return ParseObject();
            }
        }

        private Node ParseObject()
        {
            var token = GetNextToken(LexerTokenType.Number, LexerTokenType.String, LexerTokenType.Name);
            if (token != null)
            {
                switch (token.Type)
                {
                    case LexerTokenType.Number:
                        return new NumberNode(token);
                    case LexerTokenType.Name:
                        return new VariableNode(token.Value);
                    case LexerTokenType.String:
                        return new StringNode(token.Value);
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
            var start = GetNextToken(LexerTokenType.Name);
            if (start != null)
            {
                var nextToken = GetNextToken(LexerTokenType.Assignment, LexerTokenType.OpenFunction);
                if(nextToken != null)
                {
                    if (nextToken.Type == LexerTokenType.Assignment)
                    {
                        return new AssignmentNode(nextToken, new VariableNode(start.Value), ParseExpression());
                    }
                    else
                    {
                        List<Node> args = [];
                        ParseFunctionArguments(args);
                        return new FunctionNode(start.Value, args);
                    }
                }
            }
            throw new ExceptionAtLine("You need to invoke method or assign variable!",  _position);
        }

        public Node ParseCode()
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