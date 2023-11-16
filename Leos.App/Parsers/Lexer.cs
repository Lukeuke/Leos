using Leos.App.Enums;
using Leos.App.Helpers;
using Leos.App.Domain;

namespace Leos.App.Parsers;

public class Lexer
{
    private Dictionary<string, ETokenType> _keywords = new()
    {
        {
            "var",
            ETokenType.Var
        }
    };

    public IEnumerable<Token> Tokenize(string sourceCode)
    {
        var tokens = new List<Token>();
        var src = sourceCode.ToCharArray().ToList();

        while (src.Count > 0)
        {
            switch (src[0])
            {
                case '(':
                    tokens.Add(new Token(src.Shift().ToString(), ETokenType.OpenParen));
                    break;
                case ')':
                    tokens.Add(new Token(src.Shift().ToString(), ETokenType.CloseParen));
                    break;
                case '+': case '-': case '*': case '/':
                    tokens.Add(new Token(src.Shift().ToString(), ETokenType.BinaryOperator));
                    break;
                case '=':
                    tokens.Add(new Token(src.Shift().ToString(), ETokenType.Equals));
                    break;
                default:
                    if (src[0].IsInt())
                    {
                        var num = string.Empty;
                        while (src.Count > 0 && src[0].IsInt())
                        {
                            num += src.Shift();
                        }
                        
                        tokens.Add(new Token(num, ETokenType.Number));
                    }
                    else if (src[0].ToString().IsAlphabetic())
                    {
                        var identifier = string.Empty;
                        while (src.Count > 0 && src[0].ToString().IsAlphabetic())
                        {
                            identifier += src.Shift();
                        }

                        tokens.Add(_keywords.TryGetValue(identifier, out var reserved)
                            ? new Token(identifier, reserved)
                            : new Token(identifier, ETokenType.Identifier));
                    }
                    else if (src[0].ToString().CanSkip())
                    {
                        src.Shift();
                    }
                    else
                    {
                        throw new UnrecognisedCharacterException(src[0]);
                    }
                    break;
            }
        }
        
        tokens.Add(new Token("EndOfFile", ETokenType.EOF));
        return tokens;
    }
}