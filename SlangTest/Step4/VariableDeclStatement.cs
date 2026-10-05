
namespace SlangTest.Step4
{
    public class VariableDeclStatement(SymbolInfo info) : Stmt
    {
        Variable variable = null;

        public override SymbolInfo Execute(RUNTIME_CONTEXT context)
        {
            context.TABLE.Add(info);
            variable = new Variable(info);
            return info;
        }
    }
}
