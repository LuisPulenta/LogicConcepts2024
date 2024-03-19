using Shared;

Console.WriteLine("*** ENVIO DE MERCANCIAS ***");
Console.WriteLine("---------------------------");

var answer = string.Empty;
var options = new List<string> { "s", "n" };
var payMethods = new List<string> { "e", "t" };
do
{
    var weight = ConsoleExtension.GetFloat("Peso de la Mercancía......................: ");
                                           
    var value = ConsoleExtension.GetDecimal("Valor de la Mercancía.....................: ");

    var isMonday = string.Empty;

    var payMethod = string.Empty;

    var fare = CalculateFare(weight);
    var disccount = CalculateDisccount(fare,value);
    decimal promotion = 0;

    if (disccount == 0)
    {
        promotion=CalculatePromotion(fare, isMonday, payMethod,value);
    }

    do
    {
        isMonday = ConsoleExtension.GetValidOptions("Es Lunes [S]i [N]o........................: ", options);
    }
    while (!options.Any(x => x.Equals(isMonday, StringComparison.CurrentCultureIgnoreCase)));

    do
    {
        payMethod = ConsoleExtension.GetValidOptions("Tipo de Pago [E]fectivo [T]arjeta.........: ", payMethods);
    }
    while (!payMethods.Any(x => x.Equals(payMethod, StringComparison.CurrentCultureIgnoreCase)));


    Console.WriteLine("-----------------------------");

    Console.WriteLine($"Tarifa....................................: {fare,20:C2} ");
    Console.WriteLine($"Descuento.................................: {disccount,20:C2}");
    Console.WriteLine($"Promoción.................................: {promotion,20:C2}");
    Console.WriteLine($"Total a pagar.............................: {fare - disccount - promotion,20:C2}");
                       
    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]i, [N]o?: ", options);
    }
    while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
}
while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("--------------------------");
Console.WriteLine("***         FIN        ***");
Console.WriteLine("--------------------------");


//-------------------------------------------------
decimal CalculateFare(float weight)
{
    if (weight <= 100)
    {
        return 20000;
    }
    else if (weight <= 150)
    {
        return 25000;
    }
    else if (weight <= 200)
    {
        return 30000;
    }
    else
    {
        return ((int)weight-200)/10*2000 + 35000;
    }
}

//-------------------------------------------------
decimal CalculateDisccount(decimal fare, decimal value)
{
    if(value >= 300000 && value <= 600000)
    {
        return fare* 0.1m;
    }
    if (value > 600000 && value <= 1000000)
    {
        return fare * 0.2m;
    }
    if (value > 1000000)
    {
        return fare * 0.3m;
    }
    return 0;
}

//-------------------------------------------------
decimal CalculatePromotion(decimal fare, string isMonday, string payMethod, decimal value)
{
    if(isMonday.ToLower() == "s" && payMethod.ToLower() == "t")
    {
        return fare * 0.5m;
    }
    if (payMethod.ToLower() == "e" && value>1000000)
    {
        return fare * 0.4m;
    }
    return 0;
}