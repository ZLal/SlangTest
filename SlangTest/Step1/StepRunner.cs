
namespace SlangTest.Step1
{
    public class StepRunner : IStepRunner
    {
        public void Run()
        {
            Exp expr = new BinaryExp(new NumericConstant(5),
                new NumericConstant(10),
                Operator.Mul);

            Console.WriteLine(expr.Evaluate(null!));

            expr = new UnaryExp(
                new BinaryExp(
                    new NumericConstant(10),
                    new BinaryExp(
                        new NumericConstant(30),
                        new NumericConstant(50),
                        Operator.Plus),
                    Operator.Plus),
                Operator.Minus);

            Console.WriteLine(expr.Evaluate(null!));
        }
    }
}
