using SlangTest.Step1;

namespace SlangTest.Step3
{
    public class PrintLineStatement(Exp expr) : Stmt
    {
        public override bool Execute(RUNTIME_CONTEXT context)
        {
            double result = expr.Evaluate(context);
            Console.WriteLine(result.ToString());
            return true;
        }
    }
}
