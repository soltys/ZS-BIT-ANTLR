using Newtonsoft.Json.Linq;

namespace Soltys.JsonFishOil;

public class FishOilContext
{
    public JToken Current
    {
        get; set;
    }

    public static FishOilContext Create(string jsonData)
    {
        return new FishOilContext { Current = JToken.Parse(jsonData) };
    }

    public static FishOilContext Create(JToken jToken)
    {
        return new FishOilContext { Current = jToken };
    }
}
