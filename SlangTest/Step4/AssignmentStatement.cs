
namespace SlangTest.Step4
{
    public class AssignmentStatement : Stmt
    {
        private Variable variable;
        private Exp expr;
        public AssignmentStatement(Variable var, Exp e)
        {
            variable = var;
            expr = e;
        }
        public AssignmentStatement(SymbolInfo sInfo, Exp e)
        {
            variable = new Variable(sInfo);
            expr = e;
        }

        public override SymbolInfo Execute(RUNTIME_CONTEXT context)
        {
            SymbolInfo symbolInfo = expr.Evaluate(context);
            context.TABLE.Assign(variable, symbolInfo);
            return null;
        }
    }
}
