
namespace SlangTest.Step4
{
    public class UnaryPlus : Exp
    {
        private Exp exp1;
        TypeInfo _type;

        public UnaryPlus(Exp e1)
        {
            exp1 = e1;
        }

        public override SymbolInfo Evaluate(RUNTIME_CONTEXT cont)
        {
            SymbolInfo eval_left = exp1.Evaluate(cont);
            if (eval_left.Type == TypeInfo.TYPE_NUMERIC)
            {
                SymbolInfo ret_val = new()
                {
                    dbl_val = eval_left.dbl_val,
                    Type = TypeInfo.TYPE_NUMERIC,
                    SymbolName = ""
                };
                return ret_val;
            }
            else
            {
                throw new Exception("Type mismatch");
            }
        }

        public override TypeInfo TypeCheck(COMPILATION_CONTEXT cont)
        {
            TypeInfo eval_left = exp1.TypeCheck(cont);

            if (eval_left == TypeInfo.TYPE_NUMERIC)
            {
                _type = eval_left;
                return _type;
            }
            else
            {
                throw new Exception("Type mismatch failure");
            }
        }
        public override TypeInfo get_type()
        {
            return _type;
        }
    }

    public class UnaryMinus : Exp
    {
        private Exp exp1;
        TypeInfo _type;

        public UnaryMinus(Exp e1)
        {
            exp1 = e1;
        }

        public override SymbolInfo Evaluate(RUNTIME_CONTEXT cont)
        {
            SymbolInfo eval_left = exp1.Evaluate(cont);
            if (eval_left.Type == TypeInfo.TYPE_NUMERIC)
            {
                SymbolInfo ret_val = new()
                {
                    dbl_val = -eval_left.dbl_val,
                    Type = TypeInfo.TYPE_NUMERIC,
                    SymbolName = ""
                };
                return ret_val;
            }
            else
            {
                throw new Exception("Type mismatch");
            }
        }

        public override TypeInfo TypeCheck(COMPILATION_CONTEXT cont)
        {
            TypeInfo eval_left = exp1.TypeCheck(cont);

            if (eval_left == TypeInfo.TYPE_NUMERIC)
            {
                _type = eval_left;
                return _type;
            }
            else
            {
                throw new Exception("Type mismatch failure");
            }
        }
        public override TypeInfo get_type()
        {
            return _type;
        }
    }
}
