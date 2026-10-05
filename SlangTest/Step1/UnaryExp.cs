
namespace SlangTest.Step1
{
    public class UnaryExp(Exp exp, Operator op) : Exp
    {
        public override double Evaluate(RUNTIME_CONTEXT context)
        {
            return op switch
            {
                Operator.Plus => exp.Evaluate(context),
                Operator.Minus => -exp.Evaluate(context),
                _ => Double.NaN
            };
        }
    }
}
