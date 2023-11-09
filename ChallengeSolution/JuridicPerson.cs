internal class JuridicPerson : Client
{
    public JuridicPerson(string Code, string Name) : base(Code, Name)
    {
    }

    public override decimal DiscountFee(decimal value)
    {
        return value - 2;
    }
}