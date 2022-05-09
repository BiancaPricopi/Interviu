public class Solution
{
    public bool checkParanthesis(List<char> openBrackets, List<char> closeBrackets)
    {
        int length = closeBrackets.Count;
        foreach(char c in openBrackets)
        {
            if(length > 0)
            {
                if (c == '(')
                {
                    if (closeBrackets[--length] != ')')
                    {
                        return false;
                    }
                }
                else if(c == '[')
                {
                    if (closeBrackets[--length] != ']')
                    {
                        return false;
                    }
                }
                else
                {
                    if (closeBrackets[--length] != '}')
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }
        return true;
    }
    public bool IsValid(string s)
    {
        List<char> openBrackets = new List<char>();
        List<char> closeBrackets = new List<char>();

        foreach(char c in s)
        {
            if(c == '(' || c == '[' || c == '{')
            {
                openBrackets.Add(c);
            }
            else
            {
                closeBrackets.Add(c);
                if(!checkParanthesis(openBrackets, closeBrackets))
                {
                    return false;
                }
            }
        }
        
        return true;
    }
}

public class Test
{
    public static void Main()
    {
        Solution solution = new Solution();
        Console.WriteLine(solution.IsValid("{[()]}"));
    }
}