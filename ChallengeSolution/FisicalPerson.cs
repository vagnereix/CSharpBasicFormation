internal class FisicalPerson : Client
{
    public FisicalPerson(string Code, string Name) : base(Code, Name)
    {
    }

    public override decimal DiscountFee(decimal value)
    {
        return value - 1;
    }
} 