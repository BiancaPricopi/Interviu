public class Solution
{
    private bool isOpenParentheses(char parentheses)
    {
        return (parentheses == '(' || parentheses == '[' || parentheses == '{');
    }
    private bool areParenthesisCoresponding(char open, char close)
    {
        return (open == '(' && close == ')') ||
            (open == '[' && close == ']') ||
            (open == '{' && close == '}');
    }
    public bool IsValid(string s)
    {
        Stack<char> openParentheses = new Stack<char>();
        foreach(char c in s)
        {
            if (isOpenParentheses(c))
            {
                openParentheses.Push(c);
            }
            else
            {
                if(openParentheses.Count == 0)
                {
                    return false;
                }
                char pair = openParentheses.Peek();
                openParentheses.Pop();
                if (!areParenthesisCoresponding(pair, c))
                {
                    return false;
                }
            }
        }
        return openParentheses.Count() == 0;
       
    }
}

public class Test
{
    public static void Main()
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.IsValid("(([]){})"));
    }
}