using System.Collections;

namespace SlangTest.Step3
{
    public class StepRunner : IStepRunner
    {
        public void Run()
        {
            string a = "PRINTLINE 2*10;" + "\r\n" + "PRINTLINE 10;\r\n PRINT 2*10;\r\n";
            RDParser p = new RDParser(a);
            ArrayList arr = p.Parse();
            foreach (object obj in arr)
            {
                Stmt s = obj as Stmt;
                s.Execute(null);
            }

            string a2 = "PRINTLINE -2*10;" + "\r\n" + "PRINTLINE -10*-1;\r\n PRINT 2*10;\r\n";
            RDParser p2 = new RDParser(a2);
            ArrayList arr2 = p2.Parse();
            foreach (object obj in arr2)
            {
                Stmt s = obj as Stmt;
                s.Execute(null);
            }
        }
    }
}
