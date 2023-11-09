internal class Client
{
    public string Code { get; private set; }
    public string Name { get; private set; }
    public decimal Balance { get; private set; }
    public List<Movimentation> Movimentations { get; set; }

    public Client()
    {
        Movimentations = new List<Movimentation>();
    }

    public Client(string Code, string Name) :this()
    {
        this.Code = Code;
        this.Name = Name;
    }
    
    private void AddMovimentation(MovimentationTypes type, decimal value)
    {
        Movimentations.Add(new Movimentation(type, value));
    }

    public void Withdraw(decimal value)
    {
        if (Balance > value)
        {
            decimal balanceMinusFee = DiscountFee(value);

            AddMovimentation(MovimentationTypes.WITHDRAW, balanceMinusFee);
            Balance -= value;

            Console.WriteLine($"Withdraw made with success! Balance: $ {Balance}");
        } else
        {
            Console.WriteLine("Sorry, you don't have enough balance to make this withdraw.");
        }
    }

    internal void Deposit(decimal value)
    {
        if (value >= 10)
        {
            AddMovimentation(MovimentationTypes.DEPOSIT, value);

            decimal balanceMinusFee = DiscountFee(value);
            Balance += balanceMinusFee;

            Console.WriteLine($"Deposit made with success! Balance: $ {Balance}");
        } else
        {
           Console.WriteLine("Sorry, the minimum value to deposit is $ 10.");
        }
    }

    public virtual decimal DiscountFee(decimal value)
    {
        return value;
    }
}
