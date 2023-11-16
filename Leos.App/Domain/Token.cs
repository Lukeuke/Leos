﻿using System.Text;
using Leos.App.Enums;

namespace Leos.App.Domain;

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