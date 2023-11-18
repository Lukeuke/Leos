using Leos.App.Runtime.Domain;
using Leos.App.Runtime.Domain.Exceptions;

namespace Leos.App.Runtime;

public class Environment
{
    private Environment? _parent;
    private Dictionary<string, IRuntimeValue> _variables;
    private List<string> _constants;

    public Environment(Environment? parent = null)
    {
        _parent = parent;
        _variables = new Dictionary<string, IRuntimeValue>();
        _constants = new List<string>();
    }

    public IRuntimeValue DeclareVariable(string variableName, IRuntimeValue value, bool constant)
    {
        if (_variables.ContainsKey(variableName))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine($"Already defined variable: '{variableName}'");
            Console.ResetColor();
            System.Environment.Exit(1);
        }
        
        _variables.Add(variableName, value);

        if (constant)
        {
            _constants.Add(variableName);
        }
        
        return value;
    }
    
    public IRuntimeValue AssignVariable(string variableName, IRuntimeValue value)
    {
        var env = Resolve(variableName);
        
        if (env._variables.ContainsKey(variableName))
        {
            if (env._constants.Contains(variableName))
            {
                throw new ConstantAssignmentException("Cannot assign to a constant variable.");
            }
            env._variables[variableName] = value;
        }

        return value;
    }

    public IRuntimeValue LookupVariable(string variableName)
    {
        var env = Resolve(variableName);
        return env._variables[variableName];
    }
    
    private Environment Resolve(string variableName)
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