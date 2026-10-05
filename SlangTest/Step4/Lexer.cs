
namespace SlangTest.Step4
{
    public class ValueTable(Token tok, string val)
    {
        public Token token = tok;
        public string value = val;
    }

    public class Lexer(string Expr)
    {
        string IExpr = Expr;
        int index = 0;
        int length = Expr.Length;
        double number;
        public string LastStr;
        char currentChar => IExpr[index];
        readonly ValueTable[] vtList =
        [
            new ValueTable(Token.TOK_BOOL_FALSE, "FALSE"),
            new ValueTable(Token.TOK_BOOL_TRUE, "TRUE"),
            new ValueTable(Token.TOK_VAR_STRING, "STRING"),
            new ValueTable(Token.TOK_VAR_BOOL, "BOOLEAN"),
            new ValueTable(Token.TOK_VAR_NUMBER, "NUMERIC"),
            new ValueTable(Token.TOK_PRINT, "PRINT"),
            new ValueTable(Token.TOK_PRINTLN, "PRINTLINE")
        ];

        public Token GetToken()
        {
            Token tok = Token.ILLEGAL_TOKEN;
            ////////////////////////////////////////////////////////////
            //
            // Skip the white space
            //
            while (index < length &&
            (IExpr[index] == ' ' || IExpr[index] == '\t' ||
            IExpr[index] == '\r' || IExpr[index] == '\n'))
                index++;
            //////////////////////////////////////////////
            //
            // Handle comment
            //
            if (index < length &&
                index + 1 < length &&
                IExpr[index] == '/' &&
                IExpr[index + 1] == '/'
                )
            {
                while (!(IExpr[index] == '\r' || IExpr[index] == '\n'))
                {
                    index++;
                }
                return Token.TOK_COMMENT;
            }
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
                case '=':
                    tok = Token.TOK_ASSIGN;
                    index++;
                    break;
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
                case '"':
                    {
                        string str = "";
                        index++;
                        while (index < length && IExpr[index] != '"')
                        {
                            str += IExpr[index];
                            index++;
                        }
                        if (IExpr[index] == '"')
                        {
                            index++;
                            LastStr = str;
                            tok = Token.TOK_STRING;
                        }
                    }
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
                        tok = Token.TOK_NUMERIC;
                    }
                    break;
                case 'A':
                case 'B':
                case 'C':
                case 'D':
                case 'E':
                case 'F':
                case 'G':
                case 'H':
                case 'I':
                case 'J':
                case 'K':
                case 'L':
                case 'M':
                case 'N':
                case 'O':
                case 'P':
                case 'Q':
                case 'R':
                case 'S':
                case 'T':
                case 'U':
                case 'V':
                case 'W':
                case 'X':
                case 'Y':
                case 'Z':
                case 'a':
                case 'b':
                case 'c':
                case 'd':
                case 'e':
                case 'f':
                case 'g':
                case 'h':
                case 'i':
                case 'j':
                case 'k':
                case 'l':
                case 'm':
                case 'n':
                case 'o':
                case 'p':
                case 'q':
                case 'r':
                case 's':
                case 't':
                case 'u':
                case 'v':
                case 'w':
                case 'x':
                case 'y':
                case 'z':
                    {
                        string str = "";
                        while (index < length && IExpr[index] != ' ' && IExpr[index] != ';' && IExpr[index] != '=' && IExpr[index] != '*')
                        {
                            str += IExpr[index];
                            index++;
                        }
                        var vtItem = vtList.SingleOrDefault(x => x.value == str.ToUpper());
                        tok = vtItem?.token == null ? Token.TOK_UNQUOTED_STRING : vtItem.token;
                        if (tok == Token.TOK_UNQUOTED_STRING)
                        {
                            LastStr = str;
                        }
                    }
                    break;
                case ';':
                    tok = Token.TOK_SEMI;
                    index++;
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
