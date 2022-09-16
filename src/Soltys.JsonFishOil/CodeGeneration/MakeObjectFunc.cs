using System.Text;

namespace Soltys.JsonFishOil;

public class MakeObjectFunc : JsonFunc
{
    public List<MakePropertyFunc> PropertyFuncs
    {
        get;
    } = new List<MakePropertyFunc>();

    public override string Execute(FishOilContext context)
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("{");
        sb.Append(string.Join(",", PropertyFuncs.Select(x => x.Execute(context))));
        sb.AppendLine("}");

        return sb.ToString();
    }
}
