
namespace SlangTest.Step4
{
    public class BooleanConstant(bool value) : Exp
    {
        SymbolInfo info = new SymbolInfo()
        {
            SymbolName = "Boolean",
            bool_val = value,
            Type = TypeInfo.TYPE_BOOL
        };

        public override SymbolInfo Evaluate(RUNTIME_CONTEXT cont)
        {
            return info;
        }

        public override TypeInfo get_type()
        {
            return info.Type;
        }

        public override TypeInfo TypeCheck(COMPILATION_CONTEXT cont)
        {
            return info.Type;
        }
    }

    public class NumericConstant(double value) : Exp
    {
        SymbolInfo info = new SymbolInfo()
        {
            SymbolName = "Numeric",
            dbl_val = value,
            Type = TypeInfo.TYPE_NUMERIC
        };

        public override SymbolInfo Evaluate(RUNTIME_CONTEXT cont)
        {
            return info;
        }

        public override TypeInfo get_type()
        {
            return info.Type;
        }

        public override TypeInfo TypeCheck(COMPILATION_CONTEXT cont)
        {
            return info.Type;
        }
    }

    public class StringConstant(string value) : Exp
    {
        SymbolInfo info = new SymbolInfo()
        {
            SymbolName = "String",
            str_val = value,
            Type = TypeInfo.TYPE_STRING
        };

        public override SymbolInfo Evaluate(RUNTIME_CONTEXT cont)
        {
            return info;
        }

        public override TypeInfo get_type()
        {
            return info.Type;
        }

        public override TypeInfo TypeCheck(COMPILATION_CONTEXT cont)
        {
            return info.Type;
        }
    }

    public class Variable : Exp
    {
        public string Name { get; set; }
        TypeInfo _type;

        public Variable(SymbolInfo inf)
        {
            Name = inf.SymbolName;
        }

        public Variable(COMPILATION_CONTEXT st, string name, double value)
        {
            SymbolInfo s = new SymbolInfo();
            s.SymbolName = name;
            s.Type = TypeInfo.TYPE_NUMERIC;
            s.dbl_val = value;
            st.TABLE.Add(s);
            Name = name;
        }

        public Variable(COMPILATION_CONTEXT st, string name, bool value)
        {
            SymbolInfo s = new SymbolInfo();
            s.SymbolName = name;
            s.Type = TypeInfo.TYPE_BOOL;
            s.bool_val = value;
            st.TABLE.Add(s);
            Name = name;
        }

        public Variable(COMPILATION_CONTEXT st, string name, string value)
        {
            SymbolInfo s = new SymbolInfo();
            s.SymbolName = name;
            s.Type = TypeInfo.TYPE_STRING;
            s.str_val = value;
            st.TABLE.Add(s);
            Name = name;
        }

        public override SymbolInfo Evaluate(RUNTIME_CONTEXT cont)
        {
            if (cont.TABLE == null)
            {
                return null;
            }
            else
            {
                SymbolInfo a = cont.TABLE.Get(Name);
                return a;
            }
        }

        public override TypeInfo get_type()
        {
            return _type;
        }

        public override TypeInfo TypeCheck(COMPILATION_CONTEXT cont)
        {
            if (cont.TABLE == null)
            {
                return TypeInfo.TYPE_ILLEGAL;
            }
            else
            {
                SymbolInfo a = cont.TABLE.Get(Name);
                if (a != null)
                {
                    _type = a.Type;
                    return _type;
                }
                return TypeInfo.TYPE_ILLEGAL;
            }
        }
    }
}
