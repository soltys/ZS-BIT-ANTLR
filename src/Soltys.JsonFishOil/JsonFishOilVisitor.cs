using Antlr4.Runtime.Misc;

namespace Soltys.JsonFishOil;

public class JsonFishOilVisitor : JsonFishOilBaseVisitor<JsonFunc>
{
 
    public override JsonFunc VisitObjMake([NotNull] JsonFishOilParser.ObjMakeContext context)
    {
        var objMakeFunc = new MakeObjectFunc();

        foreach (var propertyExpr in context.propertyExpr())
        {
            objMakeFunc.PropertyFuncs.Add(Visit(propertyExpr) as MakePropertyFunc);
        }

        return objMakeFunc;
    }

    public override JsonFunc VisitPropertyExpr([NotNull] JsonFishOilParser.PropertyExprContext context)
    {
        var makePropertyFunc = new MakePropertyFunc();
        makePropertyFunc.PropertyName = context.NAME().GetText();
        makePropertyFunc.ValueFunc = Visit(context.jsonValue());
        return makePropertyFunc;
    }

    public override JsonFunc VisitJsonValue([NotNull] JsonFishOilParser.JsonValueContext context)
    {
        if (context.NUMBER() != null)
        {
            return new ConstValueFunc { Value = context.NUMBER().GetText() };
        }
        else if (context.STRING() != null)
        {
            return new ConstValueFunc { Value = context.STRING().GetText() };
        }
        return VisitChildren(context);        
    }

    public override JsonFunc VisitAccessChain([NotNull] JsonFishOilParser.AccessChainContext context)
    {
        var accessFunc = Visit(context.access()) as AccessFunc;
 
        if (context.accessChain() != null)
        {
            accessFunc.SubAccess = Visit(context.accessChain()) as AccessFunc;
        }

        return accessFunc;
    }

    public override JsonFunc VisitAccess([NotNull] JsonFishOilParser.AccessContext context)
    {
        AccessFunc access = new AccessFunc();

        var name = context.NAME();
        if (name != null)
        {
            access.ElementName = name.GetText();
        }

        var arrayIndex = context.NUMBER();
        if (arrayIndex != null)
        {
            access.ArrayIndex = int.Parse(arrayIndex.GetText());
        }

        return access;
    }

    public override JsonFunc VisitArrMake([NotNull] JsonFishOilParser.ArrMakeContext context)
    {
        var makeArrayFunc = new MakeArrayFunc();

        foreach (var jsonValue in context.jsonValue())
        {
            makeArrayFunc.ValueFuncs.Add(Visit(jsonValue));
        }

        return makeArrayFunc;
    }
}
