using System.Collections;

namespace SlangTest.Step4
{
    public class RDParser(string expr) : Lexer(expr)
    {
        Token CurrentToken;
        Token LastToken;

        public void GetNext()
        {
            CurrentToken = GetToken();
        }

        public ArrayList Parse(COMPILATION_CONTEXT context)
        {
            GetNext(); // Get next token

            return StatementList(context);
        }

        public ArrayList StatementList(COMPILATION_CONTEXT context)
        {
            ArrayList arr = new ArrayList();
            while (CurrentToken != Token.TOK_NULL)
            {
                Stmt temp = Statement(context);
                if (temp != null)
                {
                    arr.Add(temp);
                }
            }
            return arr;
        }

        public Stmt Statement(COMPILATION_CONTEXT context)
        {
            Stmt retVal = null;
            switch (CurrentToken)
            {
                case Token.TOK_COMMENT:
                    GetNext();
                    break;
                case Token.TOK_VAR_BOOL:
                case Token.TOK_VAR_NUMBER:
                case Token.TOK_VAR_STRING:
                    retVal = ParseVariableDeclStatement(context);
                    GetNext();
                    break;
                case Token.TOK_PRINT:
                    retVal = ParsePrintStatement(context);
                    GetNext();
                    break;
                case Token.TOK_PRINTLN:
                    retVal = ParsePrintLnStatement(context);
                    GetNext();
                    break;
                case Token.TOK_UNQUOTED_STRING:
                    retVal = ParseAssigmentStatement(context);
                    GetNext();
                    break;
                default:
                    throw new Exception("Invalid Statement");
            }
            return retVal;
        }

        public Stmt ParseVariableDeclStatement(COMPILATION_CONTEXT ctx)
        {

            //--- Save the Data type 
            Token tok = CurrentToken;
            // --- Skip to the next token , the token ought 
            // to be a Variable name ( UnQouted String )
            GetNext();
            if (CurrentToken == Token.TOK_UNQUOTED_STRING)
            {
                SymbolInfo symb = new SymbolInfo();
                symb.SymbolName = LastStr;
                symb.Type = tok switch
                {
                    Token.TOK_VAR_BOOL => TypeInfo.TYPE_BOOL,
                    Token.TOK_VAR_NUMBER => TypeInfo.TYPE_NUMERIC,
                    _ => TypeInfo.TYPE_STRING
                };
                //symb.Type = (tok == Token.TOK_VAR_BOOL) ?
                //TypeInfo.TYPE_BOOL : (tok == Token.TOK_VAR_NUMBER) ?
                //TypeInfo.TYPE_NUMERIC : TypeInfo.TYPE_STRING;
                //---------- Skip to Expect the SemiColon

                GetNext();
                if (CurrentToken == Token.TOK_SEMI)
                {
                    // ----------- Add to the Symbol Table
                    // for type analysis 
                    ctx.TABLE.Add(symb);
                    // --------- return the Object of type
                    // --------- VariableDeclStatement
                    // This will just store the Variable name
                    // to be looked up in the above table
                    return new VariableDeclStatement(symb);
                }
                else
                {
                    Console.WriteLine("; expected");
                    throw new Exception(", or ; expected");
                }
            }
            else
            {
                Console.WriteLine("invalid variable declaration");
                throw new Exception(", or ; expected");
            }
        }

        public Stmt ParseAssigmentStatement(COMPILATION_CONTEXT context)
        {
            string variable = LastStr;
            SymbolInfo symbol = context.TABLE.Get(variable);
            if (symbol == null)
            {
                Console.WriteLine("Variable not found " + LastStr);
                throw new Exception("Variable not found");
            }
            
            GetNext();
            if (CurrentToken != Token.TOK_ASSIGN)
            {
                Console.WriteLine("= expected");
                throw new Exception("= expected");
            }
            
            GetNext();
            Exp exp = Expr(context);

            if (exp.TypeCheck(context) != symbol.Type)
            {
                throw new Exception("Type mismatch in assigment");
            }

            if (CurrentToken != Token.TOK_SEMI)
            {
                Console.WriteLine("; expected");
                throw new Exception("; expected");
            }
            return new AssignmentStatement(symbol, exp);
        }

        public Stmt ParsePrintStatement(COMPILATION_CONTEXT context)
        {
            GetNext();
            Exp expr = Expr(context);
            if (CurrentToken != Token.TOK_SEMI)
            {
                throw new Exception("; is excepted");
            }
            return new PrintStatement(expr);
        }

        public Stmt ParsePrintLnStatement(COMPILATION_CONTEXT context)
        {
            GetNext();
            Exp expr = Expr(context);
            if (CurrentToken != Token.TOK_SEMI)
            {
                throw new Exception("; is excepted");
            }
            return new PrintLineStatement(expr);
        }

        public Exp CallExpr(COMPILATION_CONTEXT context)
        {
            CurrentToken = GetToken();
            return Expr(context);
        }

        public Exp Expr(COMPILATION_CONTEXT context)
        {
            Token ltoken;
            Exp retValue = Term(context);
            while (CurrentToken == Token.TOK_PLUS || CurrentToken == Token.TOK_SUB)
            {
                ltoken = CurrentToken;
                CurrentToken = GetToken();
                Exp el = Expr(context);
                retValue = ltoken == Token.TOK_PLUS ?
                    new BinaryPlus(retValue, el) :
                    new BinaryMinus(retValue, el);
            }
            return retValue;
        }

        public Exp Term(COMPILATION_CONTEXT context)
        {
            Token ltoken;
            Exp retValue = Factor(context);
            while (CurrentToken == Token.TOK_MUL || CurrentToken == Token.TOK_DIV)
            {
                ltoken = CurrentToken;
                CurrentToken = GetToken();
                Exp el = Term(context);
                retValue = ltoken == Token.TOK_MUL ?
                    new BinaryMul(retValue, el) :
                    new BinaryDiv(retValue, el);
            }
            return retValue;
        }

        public Exp Factor(COMPILATION_CONTEXT context)
        {
            Token ltoken;
            Exp RetValue = null;
            if (CurrentToken == Token.TOK_NUMERIC)
            {
                RetValue = new NumericConstant(GetNumber());
                CurrentToken = GetToken();
            }
            else if (CurrentToken == Token.TOK_STRING)
            {
                RetValue = new StringConstant(LastStr);
                CurrentToken = GetToken();
            }
            else if (CurrentToken == Token.TOK_BOOL_TRUE || CurrentToken == Token.TOK_BOOL_FALSE)
            {
                RetValue = new BooleanConstant(CurrentToken == Token.TOK_BOOL_TRUE);
                CurrentToken = GetToken();
            }
            else if (CurrentToken == Token.TOK_OPAREN)
            {
                CurrentToken = GetToken();
                RetValue = Expr(context);
                if (CurrentToken != Token.TOK_CPAREN)
                {
                    Console.WriteLine("Missing Closing Parenthesis\n");
                    throw new Exception();
                }
                CurrentToken = GetToken();
            }
            else if (CurrentToken == Token.TOK_PLUS || CurrentToken == Token.TOK_SUB)
            {
                ltoken = CurrentToken;
                CurrentToken = GetToken();
                RetValue = Factor(context);
                RetValue = ltoken == Token.TOK_PLUS ?
                    new UnaryPlus(RetValue) :
                    new UnaryMinus(RetValue);
            }
            else if (CurrentToken == Token.TOK_UNQUOTED_STRING)
            {
                SymbolInfo symbol = context.TABLE.Get(LastStr);
                if (symbol == null)
                {
                    throw new Exception("Undefined symbol");
                }
                GetNext();
                RetValue = new Variable(symbol);
            }
            else
            {
                Console.WriteLine("Illegal Token");
                throw new Exception();
            }
            return RetValue;
        }
    }
}
