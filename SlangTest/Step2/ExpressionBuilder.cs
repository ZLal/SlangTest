
using SlangTest.Step1;

namespace SlangTest.Step2
{
    public class ExpressionBuilder(string expr)
    {
        public Exp GetExpression()
        {
            try
            {
                RDParser p = new(expr);
                return p.CallExpr();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
