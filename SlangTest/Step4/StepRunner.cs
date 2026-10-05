using System.Collections;

namespace SlangTest.Step4
{
    public class StepRunner : IStepRunner
    {
        public void Run()
        {
            int programNo = 0;
            string[] programs = GetPrograms();
            foreach (var program in programs)
            {
                Console.WriteLine("Running program " + ++programNo);
                
                RDParser parser = new RDParser(program);
                COMPILATION_CONTEXT context = new COMPILATION_CONTEXT();
                ArrayList stmts = parser.Parse(context);
                
                RUNTIME_CONTEXT rContext = new RUNTIME_CONTEXT();
                foreach (object obj in stmts)
                {
                    Stmt stmt = obj as Stmt;
                    stmt.Execute(rContext);
                }

                Console.WriteLine();
                Console.WriteLine();
            }
            Console.WriteLine("Press enter to exit");
        }

        public static string[] GetPrograms()
        {
            string[] programs = [
                """
                ///////////////////////////////////
                //
                // A simple SLANG script
                //
                //    Sample #1
                //
                NUMERIC a;   // Declare a Numeric variable
                a = 2*3+5* 30 + -(4*5+3);  // Assign 
                PRINTLINE a;  // Dump a 
                //----- String concatenation
                PRINT "Hello " + "World";
                //-------------- Write a new line
                PRINTLINE "";
                //-------------- string data type
                STRING c;
                c = "Hello ";  // assignment to string 
                //---------------- assignment and concatenation
                c = c + "World";
                PRINTLINE c;
                //-------------- boolean variable 
                BOOLEAN d;
                d= TRUE;
                PRINTLINE d;
                d= FALSE;
                PRINTLINE d;
                
                """,
                """
                //////////////////////////////////////
                //
                // A slang script to test unary expression
                //
                //
                //
                Numeric a ;
                a = -1 ;
                a = -a;
                Print a;
                """,
                """
                ///////////////////////
                //
                //
                //
                //
                //
                Numeric a;
                String b;
                a = ---1;
                PrintLine a*4 + 10;
                """
                ];
            return programs;
        }
    }
}
