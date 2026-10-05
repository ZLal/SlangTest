using SlangTest.Step1;

namespace SlangTest.Step2
{
    public class RDParser(string expr) : Lexer(expr)
    {
        Token CurrentToken;

        public Exp CallExpr()
        {
            CurrentToken = GetToken();
            return Expr();
        }

        public Exp Expr()
        {
            Token ltoken;
            Exp retValue = Term();
            while (CurrentToken == Token.TOK_PLUS || CurrentToken == Token.TOK_SUB)
            {
                ltoken = CurrentToken;
                CurrentToken = GetToken();
                Exp el = Expr();
                retValue = new BinaryExp(retValue, el,
                    ltoken == Token.TOK_PLUS ? Operator.Plus : Operator.Minus);
            }
            return retValue;
        }

        public Exp Term()
        {
            Token ltoken;
            Exp retValue = Factor();
            while (CurrentToken == Token.TOK_MUL || CurrentToken == Token.TOK_DIV)
            {
                ltoken = CurrentToken;
                CurrentToken = GetToken();
                Exp el = Term();
                retValue = new BinaryExp(retValue, el,
                    ltoken == Token.TOK_MUL ? Operator.Mul : Operator.Div);
            }
            return retValue;
        }

        public Exp Factor()
        {
            Token ltoken;
            Exp RetValue = null;
            if (CurrentToken == Token.TOK_DOUBLE)
            {
                RetValue = new NumericConstant(GetNumber());
                CurrentToken = GetToken();
            }
            else if (CurrentToken == Token.TOK_OPAREN)
            {
                CurrentToken = GetToken();
                RetValue = Expr();
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
                RetValue = Factor();
                RetValue = new UnaryExp(RetValue,
                     ltoken == Token.TOK_PLUS ? Operator.Plus : Operator.Minus);
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
