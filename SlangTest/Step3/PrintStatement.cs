using SlangTest.Step1;

namespace SlangTest.Step3
{
    public class PrintStatement(Exp expr) : Stmt
    {
        public override bool Execute(RUNTIME_CONTEXT context)
        {
            double result = expr.Evaluate(context);
            Console.Write(result.ToString());
            return true;
        }
    }
}
