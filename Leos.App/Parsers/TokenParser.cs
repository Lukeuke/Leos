using Leos.App.Domain;
using Leos.App.Domain.AbstractSyntaxTree;
using Leos.App.Enums;
using Leos.App.Helpers;

namespace Leos.App.Parsers;

public class TokenParser
{
    private List<Token> _tokens;

    public TokenParser(List<Token> tokens)
    {
        _tokens = tokens;
    }
    
    public Domain.AbstractSyntaxTree.Program CreateAst(string sourceCode)
    {
        _tokens = new Lexer().Tokenize(sourceCode).ToList();
        var program = new Domain.AbstractSyntaxTree.Program();
        
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
        return ParsePrimaryExpr();
    }
    
    private IStmt ParsePrimaryExpr()
    {
        switch (_tokens[0].TokenType)
        {
            case ETokenType.Number:
                return new NumericLiteral(float.Parse(Next().Value));
            case ETokenType.Identifier:
                return new Identifier(Next().Value);
            case ETokenType.Equals:
                break;
            case ETokenType.OpenParen:
                break;
            case ETokenType.CloseParen:
                break;
            case ETokenType.BinaryOperator:
                break;
            case ETokenType.Var:
                break;
            case ETokenType.EOF:
                break;
            default:
                throw new UnexpectedTokenException(_tokens[0]);
        }

        return null!;
    }
}