namespace Soltys.JsonFishOil.Test;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        Engine engine = new Engine();

        var query = "{ mySuperName: .data.people[2].name, age: 42, constValue: \"zsbit\", subObj: { secret: 420 } }";
        var json = File.ReadAllText("data.json");
        var func = Engine.RunFishOil(query, json);
    }
}
