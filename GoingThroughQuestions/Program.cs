public class User
{
    string name;
    private string address;

    public string Address
    {
        get
        {
            return address;
        }
        set
        {
            address = value;
        }
    }
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }
}

class Test
{
    static void Main(string[] args)
    {
        User u = new User();

        u.Name = "Denis";
        u.Address = "Germany";

        Console.WriteLine("Name: " + u.Name);
        Console.WriteLine("Address: " + u.Address);
        Console.WriteLine("Press Enter Key...");
        Console.ReadLine();
    }
}
