using Shared;

Console.WriteLine("*** ORDENAR 3 NUMEROS ***");
Console.WriteLine("-------------------------");

do
{
    var a = ConsoleExtension.GetInt("Ingrese primer número: ");
    var b = ConsoleExtension.GetInt("Ingrese segundo número: ");
    var c = ConsoleExtension.GetInt("Ingrese tercer número: ");

    if (a > b && a > c)
    {
        Console.WriteLine($"El número mayor es: {a}");
        if (b > c)
        {
            Console.WriteLine($"El número del medio es: {b}");
            Console.WriteLine($"El número menor es: {c}");
        }
        else
        {
            Console.WriteLine($"El número del medio es: {c}");
            Console.WriteLine($"El número menor es: {b}");
        }
    }

    else if (b > a && b > c)
    {
        Console.WriteLine($"El número mayor es: {b}");
        if (a > c)
        {
            Console.WriteLine($"El número del medio es: {a}");
            Console.WriteLine($"El número menor es: {c}");
        }
        else
        {
            Console.WriteLine($"El número del medio es: {c}");
            Console.WriteLine($"El número menor es: {a}");
        }
    }

    else
    {
        Console.WriteLine($"El número mayor es: {c}");
        if (a > b)
        {
            Console.WriteLine($"El número del medio es: {a}");
            Console.WriteLine($"El número menor es: {b}");
        }
        else
        {
            Console.WriteLine($"El número del medio es: {b}");
            Console.WriteLine($"El número menor es: {a}");
        }
    }
    Console.WriteLine("------------------------");
} while (true);