﻿using FeuDumScript.Lexer.TokenParsers;

namespace FeuDumScript.Lexer
{
    internal class LanguageLexer
    {
        private static readonly List<ILexerTokenParser> Parsers;

        static LanguageLexer()
        {
            Parsers = [
                new AssignmentTokenParser(),
                new MathOperationsTokenParser(),
                new NameTokenParser(),
                new NumberTokenParser(),
                new StringTokenParser(),
                ];
        }

        private readonly List<LexerToken> _tokens;

        private readonly string _sourceCode;

        private int _position;

        public LanguageLexer(string code)
        {
            _sourceCode = code;
            _tokens = [];
            _position = 0;
        }

        public List<LexerToken> Parse()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Initial code: ");
            Console.ResetColor(); 
            Console.WriteLine(_sourceCode);
            while (ParseNextToken(out var token))
            {
                if (token != null)
                {
                    _tokens.Add(token);
                    _position += token.Value.Length;
                }
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Lexer result: ");
            Console.ResetColor();
            Console.WriteLine(string.Join("\n", _tokens));
            return _tokens;
        }

        private bool ParseNextToken(out LexerToken? token)
        {
            token = null;
            for (int i = _position; i < _sourceCode.Length; i++)
            {
                foreach (var parser in Parsers)
                {
                    if (parser.TryParse(_sourceCode[i..], out var value) && value != default)
                    {
                        token = new(parser.TokenType, value, new(0, _position));
                        return true;
                    }
                }
                _position++;
            }
            /// TODO: Throw here error "Can't find parser"
            return false;
        }
    }
}
