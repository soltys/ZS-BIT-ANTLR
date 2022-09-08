namespace Soltys.JsonFishOil;

public class ConstValueFunc : JsonFunc
{
    public string Value
    {
        get; set;
    }

    public override string Execute(FishOilContext context)
    {
        return Value;
    }
}
