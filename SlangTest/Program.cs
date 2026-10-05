
namespace SlangTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting");

            //IStepRunner runner = new Step1.StepRunner();
            //IStepRunner runner = new Step2.StepRunner();
            //IStepRunner runner = new Step3.StepRunner();
            IStepRunner runner = new Step4.StepRunner();
            runner.Run();

            Console.WriteLine("Press enter to exit");
        }
    }
}
