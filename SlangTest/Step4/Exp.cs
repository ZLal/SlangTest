namespace SlangTest.Step4
{
    public abstract class Exp
    {
        public abstract SymbolInfo Evaluate(RUNTIME_CONTEXT cont);
        public abstract TypeInfo TypeCheck(COMPILATION_CONTEXT cont);
        public abstract TypeInfo get_type();
    }
}
