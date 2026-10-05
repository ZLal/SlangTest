
namespace SlangTest.Step4
{
    public class BinaryPlus : Exp
    {
        private Exp exp1, exp2;
        TypeInfo _type;

        public BinaryPlus(Exp e1, Exp e2)
        {
            exp1 = e1;
            exp2 = e2;
        }

        public override SymbolInfo Evaluate(RUNTIME_CONTEXT cont)
        {
            SymbolInfo eval_left = exp1.Evaluate(cont);
            SymbolInfo eval_right = exp2.Evaluate(cont);
            if (eval_left.Type == TypeInfo.TYPE_STRING &&
                eval_right.Type == TypeInfo.TYPE_STRING)
            {
                SymbolInfo ret_val = new()
                {
                    str_val = eval_left.str_val + eval_right.str_val,
                    Type = TypeInfo.TYPE_STRING,
                    SymbolName = ""
                };
                return ret_val;
            }
            else if (eval_left.Type == TypeInfo.TYPE_NUMERIC &&
                eval_right.Type == TypeInfo.TYPE_NUMERIC)
            {
                SymbolInfo ret_val = new()
                {
                    dbl_val = eval_left.dbl_val + eval_right.dbl_val,
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
            TypeInfo eval_right = exp2.TypeCheck(cont);
            if (eval_left == eval_right && eval_left != TypeInfo.TYPE_BOOL)
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

    public class BinaryMinus : Exp
    {
        private Exp exp1, exp2;
        TypeInfo _type;

        public BinaryMinus(Exp e1, Exp e2)
        {
            exp1 = e1;
            exp2 = e2;
        }

        public override SymbolInfo Evaluate(RUNTIME_CONTEXT cont)
        {
            SymbolInfo eval_left = exp1.Evaluate(cont);
            SymbolInfo eval_right = exp2.Evaluate(cont);
            if (eval_left.Type == TypeInfo.TYPE_STRING &&
                eval_right.Type == TypeInfo.TYPE_STRING)
            {
                SymbolInfo ret_val = new()
                {
                    str_val = eval_left.str_val.Replace(eval_right.str_val, string.Empty),
                    Type = TypeInfo.TYPE_STRING,
                    SymbolName = ""
                };
                return ret_val;
            }
            else if (eval_left.Type == TypeInfo.TYPE_NUMERIC &&
                eval_right.Type == TypeInfo.TYPE_NUMERIC)
            {
                SymbolInfo ret_val = new()
                {
                    dbl_val = eval_left.dbl_val - eval_right.dbl_val,
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
            TypeInfo eval_right = exp2.TypeCheck(cont);
            if (eval_left == eval_right && eval_left == TypeInfo.TYPE_NUMERIC)
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

    public class BinaryMul : Exp
    {
        private Exp exp1, exp2;
        TypeInfo _type;

        public BinaryMul(Exp e1, Exp e2)
        {
            exp1 = e1;
            exp2 = e2;
        }

        public override SymbolInfo Evaluate(RUNTIME_CONTEXT cont)
        {
            SymbolInfo eval_left = exp1.Evaluate(cont);
            SymbolInfo eval_right = exp2.Evaluate(cont);
            if (eval_left.Type == TypeInfo.TYPE_NUMERIC &&
                eval_right.Type == TypeInfo.TYPE_NUMERIC)
            {
                SymbolInfo ret_val = new()
                {
                    dbl_val = eval_left.dbl_val * eval_right.dbl_val,
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
            TypeInfo eval_right = exp2.TypeCheck(cont);
            if (eval_left == eval_right && eval_left == TypeInfo.TYPE_NUMERIC)
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

    public class BinaryDiv : Exp
    {
        private Exp exp1, exp2;
        TypeInfo _type;

        public BinaryDiv(Exp e1, Exp e2)
        {
            exp1 = e1;
            exp2 = e2;
        }

        public override SymbolInfo Evaluate(RUNTIME_CONTEXT cont)
        {
            SymbolInfo eval_left = exp1.Evaluate(cont);
            SymbolInfo eval_right = exp2.Evaluate(cont);
            if (eval_left.Type == TypeInfo.TYPE_NUMERIC &&
                eval_right.Type == TypeInfo.TYPE_NUMERIC)
            {
                SymbolInfo ret_val = new()
                {
                    dbl_val = eval_left.dbl_val / eval_right.dbl_val,
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
            TypeInfo eval_right = exp2.TypeCheck(cont);
            if (eval_left == eval_right && eval_left == TypeInfo.TYPE_NUMERIC)
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
