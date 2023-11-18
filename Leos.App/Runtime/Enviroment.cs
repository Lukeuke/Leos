using Leos.App.Runtime.Domain;

namespace Leos.App.Runtime;

public class Enviroment
{
    private Enviroment? _parent;
    private Dictionary<string, IRuntimeValue> _variables;

    public Enviroment(Enviroment? parent = null)
    {
        _parent = parent;
        _variables = new Dictionary<string, IRuntimeValue>();
    }

    public IRuntimeValue DeclareVariable(string variableName, IRuntimeValue value)
    {
        if (_variables.ContainsKey(variableName))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine($"Already defined variable: '{variableName}'");
            Console.ResetColor();
            System.Environment.Exit(1);
        }
        
        _variables.Add(variableName, value);

        return value;
    }
    
    public IRuntimeValue AssignVariable(string variableName, IRuntimeValue value)
    {
        var env = Resolve(variableName);
        
        if (env._variables.ContainsKey(variableName))
        {
            env._variables[variableName] = value;
        }

        return value;
    }

    public IRuntimeValue LookupVariable(string variableName)
    {
        var env = Resolve(variableName);
        return env._variables[variableName];
    }
    
    private Enviroment Resolve(string variableName)
    {
        if (_variables.ContainsKey(variableName))
        {
            return this;
        }

        if (_parent == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine($"Cannot resolve: '{variableName}'.");
            Console.ResetColor();
            System.Environment.Exit(1);
        }

        return _parent.Resolve(variableName);
    }
}