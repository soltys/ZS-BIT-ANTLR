namespace Soltys.JsonFishOil;

public class ConstValueFunc : JsonFunc
{
    public ConstValueFunc(string value)
    {
        Value = value;
    }

    public string Value
    {
        get; set;
    }

    public override string Execute(FishOilContext context)
    {
        return Value;
    }
}
