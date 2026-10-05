using SlangTest.Step1;

namespace SlangTest.Step2
{
    public class StepRunner : IStepRunner
    {
        public void Run()
        {
            ExpressionBuilder b = new ExpressionBuilder("-2*(3+3)");
            Exp e = b.GetExpression();
            Console.WriteLine(e.Evaluate(null));
        }
    }
}
