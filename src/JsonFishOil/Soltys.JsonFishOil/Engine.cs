using Antlr4.Runtime;
using Newtonsoft.Json;

namespace Soltys.JsonFishOil;
public class Engine
{
    public static string RunFishOil(string input, string json)
    {
        var inputStream = new AntlrInputStream(input);
        var lexer = new JsonFishOilLexer(inputStream);
        var tokens = new CommonTokenStream(lexer);
        var parser = new JsonFishOilParser(tokens);

        var tree = parser.fishOil();
        var visitor = new JsonFishOilVisitor();
        var jsonFunc =  visitor.Visit(tree);
        var fishOilOutput = jsonFunc.Execute(FishOilContext.Create(json));
        return FormatJson(fishOilOutput);
    }

    private static string FormatJson(string json)
    {
        dynamic parsedJson = JsonConvert.DeserializeObject(json);
        return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
    }
}
