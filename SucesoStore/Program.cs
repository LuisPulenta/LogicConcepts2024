using Shared;
using System.Runtime.Intrinsics.Arm;

Console.WriteLine("*** ALMACENES SUCESO ***");
Console.WriteLine("------------------------");

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    Console.WriteLine("*** DATOS DE ENTRADA ***");
    Console.WriteLine("------------------------");

    var CC = ConsoleExtension.GetDecimal     ("Costo de compra ($)...............................: ");

    var tpOptions = new List<string> { "p", "n" };
    var TP = string.Empty;
    do
    {
        TP = ConsoleExtension.GetValidOptions("Tipo de producto [P]erecedero, [N]o perecedero....: ", tpOptions);
    }
    while (!tpOptions.Any(x => x.Equals(TP, StringComparison.CurrentCultureIgnoreCase)));

    var tcOptions = new List<string> { "f", "a" };
    var TC = string.Empty;
    do
    {
        TC = ConsoleExtension.GetValidOptions("Tipo de conservación [F]río, [A]mbiente...........: ", tcOptions);
    }
    while (!tcOptions.Any(x => x.Equals(TC, StringComparison.CurrentCultureIgnoreCase)));
        
    var PC = ConsoleExtension.GetInt         ("Período de Conservación (días)....................: ");
    var PA = ConsoleExtension.GetInt         ("Período de Almacenamiento (días)..................: ");
    var VOL = ConsoleExtension.GetInt        ("Volumen (litros)..................................: ");

    var maOptions = new List<string> { "n", "c", "e","g" };
    var MA = string.Empty;
    do
    {
        MA = ConsoleExtension.GetValidOptions("Período Medio de Almacenamiento [N]evera, [C]ongelador, [E]stantería, [G]uacal....: ", maOptions);
    }
    while (!maOptions.Any(x => x.Equals(MA, StringComparison.CurrentCultureIgnoreCase)));

    Console.WriteLine("*** CALCULOS ***");
    Console.WriteLine("----------------");

    var PDP = GetPorcentajeDepreciacionDelProducto(PA);

    var CA = GetCostoAlmacenamiento(TP,CC,TC,PC,VOL);

    var CE = GetCostoExhibicion(TP,TC,MA,CA);

    var VR_P = GetValorProducto(CC, CA, CE, PDP);

    var VR_V = GetValorVenta(TP, VR_P);

    Console.WriteLine($"Costos de Almacenamiento................: {CA,20:C2} ");
    Console.WriteLine($"Porcentaje de Depreciación..............: {PDP,20:P2} ");
    Console.WriteLine($"Costos de Exhibición....................: {CE,20:C2} ");
    Console.WriteLine($"Valor del Producto......................: {VR_P,20:C2} ");
    Console.WriteLine($"Valor de Venta..........................: {VR_V,20:C2} ");

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

//--------------------------------------------------------------------------------------------
float GetPorcentajeDepreciacionDelProducto(int PA)
{
    if (PA < 30)
    {
        return 0.95f;
    }
    return 0.85f;
}

//--------------------------------------------------------------------------------------------
decimal GetCostoAlmacenamiento(string? TP, decimal CC, string? TC, int PC, int? VOL)
{
    if (TP!.Equals("p", StringComparison.CurrentCultureIgnoreCase))
    {
        if(TC!.Equals("f", StringComparison.CurrentCultureIgnoreCase))
        {
            if ( PC < 10)
            {
                return CC * 0.05m;
            }
            return CC * 0.1m;
        }
        else
        {
            if (PC < 20)
            {
                return CC * 0.03m;
            }
            if (PC > 20)
            {
                return CC * 0.1m;
            }
            return CC * 0.05m;
        }
    }

    if (VOL >= 50)
    {
        return CC * 0.1m;
    }
    return CC * 0.2m;
}

//--------------------------------------------------------------------------------------------
decimal GetCostoExhibicion(string? TP, string? TC, string? MA, decimal CA)
{
    if (TP!.Equals("p", StringComparison.CurrentCultureIgnoreCase))
    {
        if (TC!.Equals("f", StringComparison.CurrentCultureIgnoreCase))
        {
            if (MA!.Equals("n", StringComparison.CurrentCultureIgnoreCase))
            {
                return 2 * CA; ;
            }
            return CA; ;
        }
    }

    if (MA!.Equals("e", StringComparison.CurrentCultureIgnoreCase))
    {
        return 0.05m * CA; ;
    }
    return 0.07m * CA;
}


//--------------------------------------------------------------------------------------------
decimal GetValorProducto(decimal CC, decimal CA, decimal CE, float PDP)
{
    return (CC + CA + CE) * (decimal)PDP;
}

//--------------------------------------------------------------------------------------------
decimal GetValorVenta(string? TP, decimal VR_P)
{
    if (TP!.Equals("p", StringComparison.CurrentCultureIgnoreCase))
    {
        return VR_P * 1.4m;
    }
    return VR_P * 1.2m;
}