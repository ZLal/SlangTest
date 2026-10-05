using System;
using System.Collections.Generic;
using System.Text;

namespace SlangTest.Step1
{
    public class BinaryExp(Exp exp1, Exp exp2, Operator op) : Exp
    {
        public override double Evaluate(RUNTIME_CONTEXT context)
        {
            return op switch
            {
                Operator.Plus => exp1.Evaluate(context) + exp2.Evaluate(context),
                Operator.Minus => exp1.Evaluate(context) - exp2.Evaluate(context),
                Operator.Mul => exp1.Evaluate(context) * exp2.Evaluate(context),
                Operator.Div => exp1.Evaluate(context) / exp2.Evaluate(context),
                _ => Double.NaN
            };
        }
    }
}
