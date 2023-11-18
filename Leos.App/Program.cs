using System.Diagnostics;
using Leos.App.Runtime;
using Leos.App.Runtime.Domain;
using Leos.App.Runtime.Helpers;
using Leos.App.Sdk.Parsers;
using static System.Console;
using Environment = System.Environment;

var time = new Stopwatch();
time.Start();

var t = new TokenParser();
var env = new Leos.App.Runtime.Environment();

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
        
        var result = Interpreter.Evaluate(program, env);
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
        
        var result = Interpreter.Evaluate(program, env);
        WriteLine(result.RuntimeValueToString());
    }
}
time.Stop();
WriteLine("Execution time:");
ForegroundColor = ConsoleColor.Magenta;
WriteLine(time.Elapsed.ToString(@"m\:ss\.fff"));
ResetColor();