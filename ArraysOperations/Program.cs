﻿using Shared;

Console.WriteLine("*** OPERACIONES EN ARRAYS ***");
Console.WriteLine("-----------------------------");

var answer = string.Empty;
var options = new List<string> { "s", "n" };
do
{
    var n = ConsoleExtension.GetInt("Cuantas posiciones quieres en el Arreglo?: ");

    var numbers = new int[n];

    FillArray(numbers);

    ShowArray(numbers);

    Console.WriteLine($"La sumatoria es {numbers.Sum(),10:N2}");
    Console.WriteLine($"El promedio es {numbers.Average(),11:N2}");

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

//---------------------------------------------------------------------
void FillArray(int[] numbers)
{
    var random = new Random();
    for (int i = 0; i < numbers.Length; i++)
    {
        numbers[i] = random.Next(0, 100);
    }
}

//---------------------------------------------------------------------
void ShowArray(int[] numbers)
{
    foreach (var number in numbers)
    {
        Console.Write($"{number,10:N0}");
    }
    Console.WriteLine();
}
