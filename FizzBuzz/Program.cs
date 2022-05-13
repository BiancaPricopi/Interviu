public class Solution
{
    public IList<string> FizzBuzz(int n)
    {
        IList<string> fizzBuzz = new List<string>();
        for (int i = 1; i <= n; i++)
        {
            if(i % 3 == 0)
            {
                if(i % 5 == 0)
                {
                    fizzBuzz.Add("FizzBuzz");
                }
                else
                {
                    fizzBuzz.Add("Fizz");
                }
            }
            else if(i % 5 == 0)
            {
                fizzBuzz.Add("Buzz");
            }
            else
            {
                fizzBuzz.Add(i.ToString());
            }
        }
        return fizzBuzz;
    }
}

public class Test
{
    public static void Main()
    {
        Solution solution = new Solution();

        IList<string> fizzBuzz = solution.FizzBuzz(15);
        foreach(string f in fizzBuzz)
        {
            Console.Write(f + " ");
        }
    }
}