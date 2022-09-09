using System.Text;

namespace Soltys.JsonFishOil;

public class MakeArrayFunc : JsonFunc
{
    public List<JsonFunc> ValueFuncs
    {
        get;
    } = new List<JsonFunc>();

    public override string Execute(FishOilContext context)
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("[");
        sb.Append(string.Join(",", ValueFuncs.Select(x => x?.Execute(context))));
        sb.AppendLine("]");

        return sb.ToString();
    }
}
