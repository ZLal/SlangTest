
namespace SlangTest.Step4
{
    public abstract class Stmt
    {
        public abstract SymbolInfo Execute(RUNTIME_CONTEXT context);
    }

    public class PrintStatement(Exp expr) : Stmt
    {
        public override SymbolInfo Execute(RUNTIME_CONTEXT context)
        {
            SymbolInfo result = expr.Evaluate(context);
            string dataStr = result.Type switch
            {
                TypeInfo.TYPE_NUMERIC => result.dbl_val.ToString(),
                TypeInfo.TYPE_BOOL => result.bool_val.ToString(),
                TypeInfo.TYPE_STRING => result.str_val,
                _ => throw new Exception("Invalid type"),
            };
            Console.Write(dataStr);
            return result;
        }
    }

    public class PrintLineStatement(Exp expr) : Stmt
    {
        public override SymbolInfo Execute(RUNTIME_CONTEXT context)
        {
            SymbolInfo result = expr.Evaluate(context);
            string dataStr = result.Type switch
            {
                TypeInfo.TYPE_NUMERIC => result.dbl_val.ToString(),
                TypeInfo.TYPE_BOOL => result.bool_val.ToString(),
                TypeInfo.TYPE_STRING => result.str_val,
                _ => throw new Exception("Invalid type"),
            };
            Console.WriteLine(dataStr);
            return result;
        }
    }
}
