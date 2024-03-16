Console.WriteLine("*** NUMERO PAR O IMPAR ***");
Console.WriteLine("--------------------------");
var numberString = string.Empty;
do
{
    Console.Write("Ingrese Número ENTERO o 'S' para salir: ");
    numberString = Console.ReadLine();

    if (numberString!.ToUpper() == "S")
    {
        continue;
    }

    int numberInt;

    if (int.TryParse(numberString, out numberInt ))
    {
        numberInt = int.Parse(numberString!);

        if (numberInt % 2 == 0)
        {
            Console.WriteLine($"{numberInt} es PAR");
        }
        else
        {
            Console.WriteLine($"{numberInt} es IMPAR");
        }
    }
    else
    {
        Console.WriteLine($"El valor ingresado {numberString} no es un número entero");
    }
}
while (numberString.ToUpper() != "S");

Console.WriteLine("--------------------------");
Console.WriteLine("***         FIN        ***");
Console.WriteLine("--------------------------");
