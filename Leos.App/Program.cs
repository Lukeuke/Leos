using Leos.App.Parsers;

var t = new Lexer();

var tokens = t.Tokenize("var madzia = 3");

foreach (var token in tokens)
{
    Console.WriteLine(token);
}