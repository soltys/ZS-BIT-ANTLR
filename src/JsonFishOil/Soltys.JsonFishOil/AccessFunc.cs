using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Soltys.JsonFishOil;

public class AccessFunc : JsonFunc
{
    public AccessFunc()
    {
    }

    public string ElementName
    {
        get; set;
    }

    public int? ArrayIndex
    {
        get; set;
    }

    public AccessFunc SubAccess
    {
        get; set;
    }

    public override string Execute(FishOilContext context)
    {
        if (ElementName == null)
        {
            // case where input is '.'
            return context.Current.ToString();
        }

        if (context.Current[ElementName] == null)
        {
            throw new InvalidOperationException($"{ElementName} does not exist");
        }

        JToken newCurrentToken;

        if (ArrayIndex.HasValue)
        {
            if (context.Current[ElementName].Type != JTokenType.Array)
            {
                throw new InvalidOperationException($"{ElementName} is not a array");
            }

            newCurrentToken = context.Current[ElementName];
            newCurrentToken = newCurrentToken.ElementAt(ArrayIndex.Value);
        }
        else
        {
            newCurrentToken = context.Current[ElementName];
        }

        if (SubAccess != null)
        {
            return SubAccess.Execute(FishOilContext.Create(newCurrentToken));
        }
        else
        {

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);

            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;

                newCurrentToken.WriteTo(writer);
            }

            return sb.ToString();
        }
    }
}
