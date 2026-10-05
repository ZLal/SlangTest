
namespace SlangTest.Step1
{
    public class NumericConstant(double value) : Exp
    {
        public override double Evaluate(RUNTIME_CONTEXT context)
        {
            return value;
        }
    }
}
