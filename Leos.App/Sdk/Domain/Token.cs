using System.Text;
using Leos.App.Sdk.Enums;
using Newtonsoft.Json;

namespace Leos.App.Sdk.Domain;

public class Token
{
    public Token(string value, ETokenType type)
    {
        Value = value;
        TokenType = type;
    }
    
    public string Value { get; }
    public ETokenType TokenType { get; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
        
        var sb = new StringBuilder();

        sb.Append("{ value: ");
        sb.Append('"');
        sb.Append(Value);
        sb.Append("\", type: ");
        sb.Append(TokenType);
        sb.Append(" }");

        return sb.ToString();
    }
}