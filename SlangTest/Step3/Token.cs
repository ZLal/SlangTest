
namespace SlangTest.Step3
{
    public enum Token
    {
        ILLEGAL_TOKEN = -1, // Not a Token
        TOK_PLUS = 1, // '+'
        TOK_MUL, // '*'
        TOK_DIV, // '/'
        TOK_SUB, // '-'
        TOK_OPAREN, // '('
        TOK_CPAREN, // ')'
        TOK_DOUBLE, // '('
        TOK_NULL, // End of string
        TOK_PRINT, // Print Statement
        TOK_PRINTLN, // PrintLine
        TOK_UNQUOTED_STRING,
        TOK_SEMI // ; 
    }
}
