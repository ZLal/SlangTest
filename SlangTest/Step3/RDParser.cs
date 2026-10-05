using SlangTest.Step1;
using System.Collections;

namespace SlangTest.Step3
{
    public class RDParser(string expr) : Step3.Lexer(expr)
    {
        Token CurrentToken;

        public void GetNext()
        {
            CurrentToken = GetToken();
        }

        public ArrayList Parse()
        {
            GetNext(); // Get next token

            return StatementList();
        }

        public ArrayList StatementList()
        {
            ArrayList arr = new ArrayList();
            while (CurrentToken != Token.TOK_NULL)
            {
                Stmt temp = Statement();
                if (temp != null)
                {
                    arr.Add(temp);
                }
            }
            return arr;
        }

        public Stmt Statement()
        {
            Stmt retVal = null;
            switch (CurrentToken)
            {
                case Token.TOK_PRINT:
                    retVal = ParsePrintStatement();
                    GetNext();
                    break;
                case Token.TOK_PRINTLN:
                    retVal = ParsePrintLnStatement();
                    GetNext();
                    break;
                default:
                    throw new Exception("Invalid Statement");
            }
            return retVal;
        }

        public Stmt ParsePrintStatement()
        {
            GetNext();
            Exp expr = Expr();
            if (CurrentToken != Token.TOK_SEMI)
            {
                throw new Exception("; is excepted");
            }
            return new PrintStatement(expr);
        }

        public Stmt ParsePrintLnStatement()
        {
            GetNext();
            Exp expr = Expr();
            if (CurrentToken != Token.TOK_SEMI)
            {
                throw new Exception("; is excepted");
            }
            return new PrintLineStatement(expr);
        }

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
