public class Solution
{
    public int RomanToInt(string s)
    {
        int result = 0;
        for(int i = 0; i < s.Length; i++)
        {
            if(s[i] == 'M')
            {
                result += 1000;
            }
            else if(s[i] == 'D')
            {
                result += 500;
            }
            else if(s[i] == 'C')
            {
                if(i+1 < s.Length)
                {
                    if(s[i+1] == 'M')
                    {
                        result += 900;
                        i++;
                    }
                    else if(s[i+1] == 'D')
                    {
                        result += 400;
                        i++;
                    }
                    else
                    {
                        result += 100;
                    }
                }
                else
                {
                    result += 100;
                }
            }
            else if(s[i] == 'L')
            {
                result += 50;
            }
            else if (s[i] == 'X')
            {
                if (i + 1 < s.Length)
                {
                    if (s[i + 1] == 'C')
                    {
                        result += 90;
                        i++;
                    }
                    else if (s[i + 1] == 'L')
                    {
                        result += 40;
                        i++;
                    }
                    else
                    {
                        result += 10;
                    }
                }
                else
                {
                    result += 10;
                }
            }
            else if(s[i] == 'V')
            {
                result += 5;
            }
            else if (s[i] == 'I')
            {
                if (i + 1 < s.Length)
                {
                    if (s[i + 1] == 'X')
                    {
                        result += 9;
                        i++;
                    }
                    else if (s[i + 1] == 'V')
                    {
                        result += 4;
                        i++;
                    }
                    else
                    {
                        result += 1;
                    }
                }
                else
                {
                    result += 1;
                }
            }
        }
        return result;
    }
}

public class BetterSolution
{
    public static void Solution(string num)
    {
        Dictionary<char, int> romanNums = new() { { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 1000 } };

        int result = 0;
        for (int i = num.Length - 1; i >= 0; i--)
        {
            if(i == 0)
            {
                result += romanNums[num[i]];
            }
            else if(romanNums[num[i]] > romanNums[num[i - 1]])
            {
                result += romanNums[num[i]] - romanNums[num[i - 1]];
                i--;
            }
            else
            {
                result += romanNums[num[i]];
            }
        }
        Console.WriteLine("Better solution: " + result);
    }
}

public class Test
{
    public static void Main()
    {
        Solution solution = new Solution();
        Console.WriteLine("My solution: " + solution.RomanToInt("MCMXCIV"));
        BetterSolution.Solution("MCMXCIV");
    }
}