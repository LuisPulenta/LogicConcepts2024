using Shared;

Console.WriteLine("*** PARES E IMPARES ***");
Console.WriteLine("-----------------------");

var answer = string.Empty;
var options = new List<string> { "s", "n" };
do
{
    var n = ConsoleExtension.GetInt("Cuantas posiciones quieres en el Arreglo?: ");

    var numbers = new int[n];

    FillArray(numbers);

    var sum =GetSumEven(numbers);
    double prod = GetProdOdd(numbers);

    ShowArray(numbers);

    Console.WriteLine($"La sumatoria de los pares es {sum,10:N0}");
    Console.WriteLine($"La productoris de los impares es {prod,10:N0}");

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
    var random =new Random();
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


//---------------------------------------------------------------------
int GetSumEven(int[] numbers)
{
    var sum = 0;
    foreach (var number in numbers)
    {
        if (number %2 == 0) {
            sum += number;
        }
    }
    return sum;
}

//---------------------------------------------------------------------
double GetProdOdd(int[] numbers)
{
    double prod = 1;
    foreach (var number in numbers)
    {
        if (number % 2 != 0)
        {
            prod *= number;
        }
    }
    return prod;
}