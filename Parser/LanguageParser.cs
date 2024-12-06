using FeuDumScript.Exceptions;
using FeuDumScript.Lexer;
using FeuDumScript.Parser.AbstractSyntaxTree;
using FeuDumScript.Parser.AbstractSyntaxTree.Nodes;

namespace FeuDumScript.Parser
{
    internal class LanguageParser
    {
        private List<LexerToken> _tokens;

        private int _position;

        private LanguageLexer _lexer;

        public LanguageParser(string code)
        {
            _tokens = [];
            _position = 0;
            _lexer = new(code);
            _tokens = _lexer.Parse();
        }

        public Node ParseExpressionPart()
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

        public Node ParseObject()
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
        
        public Node ParseExpression()
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


        public Node ParseLine()
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
                        var token = GetNextToken(LexerTokenType.String);
                        if (token != null)
                        {
                            Require(LexerTokenType.CloseFunction);
                            return new UnarOperator(start.Value, new StringNode(token.Value));
                        }
                        else
                        {
                            _position--;
                            return new UnarOperator(start.Value, ParseExpression());
                        }
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

        public LexerToken? GetNextToken(params List<LexerTokenType> requirements)
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

        public LexerToken Require(params List<LexerTokenType> requirements)
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