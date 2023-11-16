using Leos.App.Parsers;
using static System.Console; 

var t = new TokenParser();

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
}