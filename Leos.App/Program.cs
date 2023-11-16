using Leos.App.Runtime;
using Leos.App.Runtime.Helpers;
using Leos.App.Sdk.Parsers;
using static System.Console; 

var t = new TokenParser();

if (args.Length > 0)
{
    if (args[0] is "-i" or "--input")
    {
        var path = args[1];

        if (!path.EndsWith(".leos"))
        {
            WriteLine("Wrong file extension"); 
            Environment.Exit(1);
        }

        var sourceCode = File.ReadAllText(path);
        
        var program = t.CreateAst(sourceCode);
        
        var result = Interpreter.Evaluate(program);
        WriteLine(result.RuntimeValueToString());
    }
    else
    {
        WriteLine("Invalid arguments.");
        Environment.Exit(1);
    }
}
else
{
    WriteLine("Leos command line v1.0");

    while (true)
    {
        Write("> ");

        var input = ReadLine();

        if (input is null || input.Contains("exit"))
        {
            Environment.Exit(0);
        }

        var program = t.CreateAst(input);
        WriteLine(program);
        
        var result = Interpreter.Evaluate(program);
        WriteLine(result.RuntimeValueToString());
    }
}
