/// <summary>
/// An ATM machine starts with an initial amount of money. 
/// The money available in the ATM is provided as a dictionary where 
/// every key is the denomination and the associated value represents the amount available for that denomination.
/// 
/// For example, given the input:
///     { ( 1, 3 ), ( 5, 2 ), ( 10, 4 ) }
/// The ATM machine will contain:
///     - 3 bills of 1 RON
///     - 2 bills of 5 RON
///     - 4 bills of 10 RON
///     
/// The ATM Machine allows people to withdraw money multiple times, by calling the <see cref="Withdraw(int)"/>
/// </summary>

/*public class AtmMachine
{
    private Dictionary<int, int> _amounts;

    public AtmMachine(Dictionary<int, int> amounts)
    {
        this._amounts = amounts;
    }

    /// <summary>
    /// By using the <see cref="Withdraw(int)"/> method, people can attempt to withdraw money.
    /// If the amount is not available in the ATM, the person must receive an empty `List<Tuple<int, int>>`
    /// If the amount is available in the ATM, the person will receive a `List<Tuple<int, int>>` representing all the denominations and units they receive.
    /// For instance:
    ///     Given the ATM has an initial balance of 
    ///         { { 1, 10 }, { 5, 10 }, { 10, 10 } }
    ///     When attempting to withdraw 
    ///         27 RON
    ///     Then the method could return(*)
    ///         { (10, 2), (5, 1), (1, 2) }
    ///     Which means
    ///         - 2 bills of 10 RON
    ///         - 1 bill of 5 RON
    ///         - 2 bills of 1 RON
    /// 
    /// (*)Note: other variations are also acceptable. 
    /// </summary>
    public IDictionary<int, int> Withdraw(int amount)
    {
        IDictionary<int, int> result = new Dictionary<int, int>();
        //nu returnam nimic daca suma este invalida
        if (amount <= 0)
        {
            return result;
        }
        //sortam bancnotele descrescator
        List<int> list = this._amounts.Keys.ToList();
        list.Sort((a, b) => b.CompareTo(a));

        foreach (int item in list)
        {
            int bills = 0;
            //luam cat de multe bancnote posibile din cea mai mare bancnota
            while(item <= amount && this._amounts[item] > 0)
            {
                amount -= item;
                this._amounts[item]--;
                bills++;
            }
            result.Add(new KeyValuePair<int, int>(item, bills));
        }
        //nu am avut fonduri suficiente
        if(amount > 0)
        {
            result.Clear();
        }
        return result;
    }
}*/
public class AtmMachine
{
    private Dictionary<int, int> _amounts;

    public AtmMachine(Dictionary<int, int> amounts)
    {
        this._amounts = amounts;
    }

    /// <summary>
    /// By using the <see cref="Withdraw(int)"/> method, people can attempt to withdraw money.
    /// If the amount is not available in the ATM, the person must receive an empty `List<Tuple<int, int>>`
    /// If the amount is available in the ATM, the person will receive a `List<Tuple<int, int>>` representing all the denominations and units they receive.
    /// For instance:
    ///     Given the ATM has an initial balance of 
    ///         { { 1, 10 }, { 5, 10 }, { 10, 10 } }
    ///     When attempting to withdraw 
    ///         27 RON
    ///     Then the method could return(*)
    ///         { (10, 2), (5, 1), (1, 2) }
    ///     Which means
    ///         - 2 bills of 10 RON
    ///         - 1 bill of 5 RON
    ///         - 2 bills of 1 RON
    /// 
    /// (*)Note: other variations are also acceptable. 
    /// </summary>
    public List<Tuple<int, int>> Withdraw(int amount)
    {
        List<Tuple<int, int>> finalWithdraw = new List<Tuple<int, int>>();

        //nu returnam nimic daca suma este invalida
        if (amount <= 0)
        {
            return finalWithdraw;
        }
        //sortam bancnotele descrescator
        List<int> list = this._amounts.Keys.ToList();
        list.Sort((a, b) => b.CompareTo(a));

        foreach (int item in list)
        {
            int bills = 0;
            //luam cat de multe bancnote posibile din cea mai mare bancnota
            while (item <= amount && _amounts[item] > 0)
            {
                amount -= item;
                _amounts[item]--;
                bills++;
            }
            if(bills > 0)
            {
                finalWithdraw.Add(new Tuple<int, int>(item, bills));
            }
            if(amount == 0)
            {
                return finalWithdraw;
            }
        }
        //nu am avut fonduri suficiente
        if (amount > 0)
        {
            //refacem _amounts
            foreach (Tuple<int, int> tuple in finalWithdraw)
            {
                _amounts[tuple.Item1] += tuple.Item2;
            }
            finalWithdraw.Clear();
        }
        return finalWithdraw;
    }
}

public class VersionComparer
{
    private int getNum(string token)
    {
        if (String.IsNullOrEmpty(token))
        {
            return 0;
        }
        else
        {
            return int.Parse(token);
        }
    }
    public int Compare(string versionOne, string versionTwo)
    {
        //despart versiunile in token-uri care reprezinta numere
        string[] versionOneTokens = versionOne.Split('.');
        string[] versionTwoTokens = versionTwo.Split('.');

        int num1;
        int num2;
        int i;
        for (i = 0; i < versionOneTokens.Length; i++)
        {
            num1 = getNum(versionOneTokens[i]);

            if (i < versionTwoTokens.Length)
            {
                num2 = getNum(versionTwoTokens[i]);

                if (num1 < num2)
                {
                    return -1;
                }
                else if (num1 > num2)
                {
                    return 1;
                }
            }
            else if (num1 > 0)
            {
                return 1;
            }
        }
        //trebuie sa verific si cazul in care versionTwo are mai multe token-uri decat versionOne
        if (i < versionTwoTokens.Length)
        {
            //exista posibilitatea ca token-urile sa fie zero
            for (int j = i; j < versionTwoTokens.Length; j++)
            {
                num2 = getNum(versionTwoTokens[j]);
                if (num2 > 0)
                {
                    return -1;
                }
            }
        }
        return 0;
    }
}
public class Test
{
    public static void Main()
    {
        /*AtmMachine atm = new AtmMachine(new Dictionary<int, int> { { 1, 5 }, { 5, 5 }, { 10, 5 } });
        List<Tuple<int, int>> dict =  atm.Withdraw(20);
        foreach (Tuple<int, int> tuple in dict)
        {
            Console.WriteLine("Key = {0}, Value = {1}", tuple.Item1, tuple.Item2);
        }*/

        VersionComparer compare = new VersionComparer();
        Console.WriteLine(compare.Compare("01.0.1", "1.1.0"));
        Console.WriteLine(compare.Compare("33.1", "33.0.5"));
        Console.WriteLine(compare.Compare("7.0105.84", "7.15.84"));

    }
}