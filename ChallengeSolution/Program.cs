#region Code
List<Client> Clients = new();
FindClient();

void FindClient()
{
    Console.WriteLine("Hey! Welcome to the system!");
    Console.WriteLine("Please, enter your code:");

    string? code = Console.ReadLine();
    Client? client = null;

    foreach (Client c in Clients)
    {
        if (c.Code == code)
        {
            client = c;
            break;
        }
    }

    if (client == null)
    {
        Console.WriteLine("Sorry, we couldn't find your code. Would like to register? Type Y or N");
        string? answer = Console.ReadLine();

        if (answer != null && answer.ToUpper() == "Y")
        {
            Console.WriteLine("Please, enter your name:");
            string? clientName = Console.ReadLine();

            Console.WriteLine("Please, enter your code:");
            string? clientCode = Console.ReadLine();

            Console.WriteLine("Fisical Person (PF) or Juridic Person? (PJ)");
            string? clientType = Console.ReadLine();

            if (clientType != null && clientType.ToUpper() == "PF")
                client = new FisicalPerson(clientCode, clientName);
            else
                client = new JuridicPerson(clientCode, clientName);

            Clients.Add(client);
            ShowMenu(client);
        } else
            FindClient();
    }
}

void ShowMenu(Client client)
{
    Console.WriteLine($"Hey {client.Name}!");
    Console.WriteLine("Please choose a option:");
    Console.WriteLine("1 - Show Balance");
    Console.WriteLine("2 - Withdraw");
    Console.WriteLine("3 - Deposit");
    Console.WriteLine("4 - Leave");

    string? menu = Console.ReadLine();

    switch (menu)
    {
        case "1":
            ShowBalance(client);
            break;
        case "2":
            WithDraw(client);
            break;
        case "3":
            Deposit(client);
            break;
        case "4":
            Console.WriteLine("Thanks for using our system! See you soon!");
            break;
        default:
            Console.WriteLine("Invalid option");
            ShowMenu(client);
            break;
    }   
}

void ShowBalance(Client client)
{
    Console.WriteLine("------------------------------------");
      
    foreach (Movimentation movimentation in client.Movimentations)
    {
        Console.WriteLine($"Type: {movimentation.Type} - Value: $ {movimentation.Value}");
    }

    Console.WriteLine($"Your balance is: $ {client.Balance}");
    Console.WriteLine("------------------------------------");

    ShowMenu(client);
}

void Deposit(Client client)
{
    Console.WriteLine("Please, enter the value to deposit:");
    string? stringValue = Console.ReadLine();

    decimal value = decimal.Parse(stringValue);
    client.Deposit(value);

    Console.WriteLine("Would you like to make another deposit? Type Y or N");
    string? answer = Console.ReadLine();

    if (answer != null && answer.ToUpper() == "Y")
    {
        Deposit(client);
    }
    else
    {
        ShowMenu(client);
    }
}

void WithDraw(Client client)
{
    Console.WriteLine("Please, enter the value to withdraw:");
    decimal value = decimal.Parse(Console.ReadLine());

    client.Withdraw(value);
    Console.WriteLine("Would you like to make another withdraw? Type Y or N");
    string? answer = Console.ReadLine();

    if (answer != null && answer.ToUpper() == "Y")
    {
        WithDraw(client);
    } else
    {
        ShowMenu(client);
    }
}
#endregion
