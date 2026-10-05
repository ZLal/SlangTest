
namespace SlangTest.Step2
{
    public class Lexer(string Expr)
    {
        string IExpr = Expr;
        int index = 0;
        int length = Expr.Length;
        double number;

        public Token GetToken()
        {
            Token tok = Token.ILLEGAL_TOKEN;
            ////////////////////////////////////////////////////////////
            //
            // Skip the white space
            //
            while (index < length &&
            (IExpr[index] == ' ' || IExpr[index] == '\t'))
                index++;
            //////////////////////////////////////////////
            //
            // End of string ? return NULL;
            //
            if (index == length)
                return Token.TOK_NULL;
            /////////////////////////////////////////////////
            //
            //
            //
            switch (IExpr[index])
            {
                case '+':
                    tok = Token.TOK_PLUS;
                    index++;
                    break;
                case '-':
                    tok = Token.TOK_SUB;
                    index++;
                    break;
                case '/':
                    tok = Token.TOK_DIV;
                    index++;
                    break;
                case '*':
                    tok = Token.TOK_MUL;
                    index++;
                    break;
                case '(':
                    tok = Token.TOK_OPAREN;
                    index++;
                    break;
                case ')':
                    tok = Token.TOK_CPAREN;
                    index++;
                    break;
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    {
                        string str = "";
                        while (index < length &&
                        (IExpr[index] == '0' ||
                        IExpr[index] == '1' ||
                        IExpr[index] == '2' ||
                        IExpr[index] == '3' ||
                        IExpr[index] == '4' ||
                        IExpr[index] == '5' ||
                        IExpr[index] == '6' ||
                        IExpr[index] == '7' ||
                        IExpr[index] == '8' ||
                        IExpr[index] == '9'))
                        {
                            str += Convert.ToString(IExpr[index]);
                            index++;
                        }
                        number = Convert.ToDouble(str);
                        tok = Token.TOK_DOUBLE;
                    }
                    break;
                default:
                    Console.WriteLine("Error While Analyzing Tokens");
                    throw new Exception();
            }
            return tok;
        }
        public double GetNumber() { return number; }
    }
}
