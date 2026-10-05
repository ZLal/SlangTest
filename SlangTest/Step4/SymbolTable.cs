using System.Collections;

namespace SlangTest.Step4
{
    public class SymbolTable
    {
        Hashtable dt = new Hashtable();

        public bool Add(SymbolInfo s)
        {
            dt[s.SymbolName] = s;
            return true;
        }

        public SymbolInfo Get(string name)
        {
            return dt[name] as SymbolInfo;
        }

        public void Assign(Variable var, SymbolInfo value)
        {
            value.SymbolName = var.Name;
            dt[var.Name] = value;
        }

        public void Assign(string var, SymbolInfo value)
        {
            dt[var] = value;
        }
    }
}
