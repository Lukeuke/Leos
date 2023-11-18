using Leos.App.Sdk.Domain;
using Leos.App.Sdk.Domain.Exceptions;
using Leos.App.Sdk.Domain.AbstractSyntaxTree;
using Leos.App.Sdk.Enums;
using Leos.App.Sdk.Helpers;

namespace Leos.App.Sdk.Parsers;

public class TokenParser
{
    private List<Token> _tokens = null!;

    public Domain.AbstractSyntaxTree.Program CreateAst(string sourceCode)
    {
        _tokens = Lexer.Tokenize(sourceCode).ToList();
        var program = new Domain.AbstractSyntaxTree.Program
        {
            Body = new List<IStmt>()
        };

        while (IsEOF())
        {
            program.Body.Add(ParseStmt());
        }

        return program;
    }

    private bool IsEOF()
    {
        return _tokens[0].TokenType != ETokenType.EOF;
    }

    private Token Next()
    {
        var prev = _tokens.Shift();

        return prev;
    }

    private IStmt ParseStmt()
    {
        return ParseExpr();
    }

    private IStmt ParseExpr()
    {
        return ParseAdditiveExpr();
    }

    private IStmt ParseAdditiveExpr()
    {
        var left = ParseMultiplExpr();

        while (_tokens[0].Value is "+" or "-")
        {
            var @operator = Next().Value;
            var right = ParseMultiplExpr();
            left = new BinaryExpr((IExpr)left, (IExpr)right, @operator);
        }

        return left;
    }

    private IStmt ParseMultiplExpr()
    {
        var left = ParsePrimaryExpr();

        while (_tokens[0].Value is "*" or "/" or "%")
        {
            var @operator = Next().Value;
            var right = ParsePrimaryExpr();
            left = new BinaryExpr((IExpr)left, (IExpr)right, @operator);
        }

        return left;
    }
    
    private IStmt ParsePrimaryExpr()
    {
        switch (_tokens[0].TokenType)
        {
            case ETokenType.Number:
                return new NumericLiteral(float.Parse(Next().Value));
            case ETokenType.Identifier:
                return new Identifier(Next().Value);
            case ETokenType.Null:
                Next();
                return new NullLiteral();
            case ETokenType.OpenParen:
                Next();
                var value = ParseExpr();
                Expect(ETokenType.CloseParen, "Expected closing parentheses.");
                return value;
            default:
                throw new UnexpectedTokenException(_tokens[0]);
        }

        return null!;
    }

    private Token Expect(ETokenType type, string errorMsg)
    {
        var prev = _tokens.Shift();

        if (prev is null || prev.TokenType != type)
        {
            throw new TokenExpectedException($"{errorMsg} \n {prev} \n Expected: {type}");
        }

        return prev;
    }
}