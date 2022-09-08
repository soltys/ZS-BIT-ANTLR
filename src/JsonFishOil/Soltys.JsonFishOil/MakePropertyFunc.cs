namespace Soltys.JsonFishOil;

public class MakePropertyFunc : JsonFunc
{
    public string PropertyName
    {
        get; set;
    }

    public JsonFunc ValueFunc
    {
        get; set;
    }

    public override string Execute(FishOilContext context)
    {
        return $"\"{PropertyName}\": {ValueFunc.Execute(context)}";
    }
}
