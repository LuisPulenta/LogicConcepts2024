using Shared;

Console.WriteLine("*** OPERACIONES ESPECIAL DE VECTOR ***");
Console.WriteLine("--------------------------------------");

var answer = string.Empty;
var options = new List<string> { "s", "n" };
do
{
    var n = ConsoleExtension.GetInt("Cuantas posiciones quieres en el Arreglo?: ");

    var numbers = new int[n];

    FillArray(numbers);

    Console.WriteLine("*** Array Sin Ordenar ***");
    ShowArray(numbers);
    Console.WriteLine();

    var numbersEven = GetNumbersEven(numbers);
    var numbersOdd = GetNumbersOdd(numbers);

    OrderArray(numbersEven, isDescending: true);
    OrderArray(numbersOdd);

    OrderArray(numbers,isDescending:true);
    Console.WriteLine("*** Array Ordenado ***");
    ShowArray(numbersEven);
    ShowArray(numbersOdd);
    Console.WriteLine();

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
}

//---------------------------------------------------------------------
void OrderArray(int[] numbers, bool isDescending = false)
{
    for (int i = 0; i < numbers.Length-1; i++)
    {
        for (int j = i+1; j<numbers.Length; j++)
        {
            if (isDescending)
            {
                if (numbers[i] < numbers[j])
                {
                    Change(ref numbers[i], ref numbers[j]);
                }
            }
            else
            {
                if (numbers[i] > numbers[j])
                {
                    Change(ref numbers[i], ref numbers[j]);
                }
            }            
        }
    }
}

//---------------------------------------------------------------------
static void Change(ref int number1, ref int number2)
{
    int aux = number1;
    number1 = number2;
    number2 = aux;
}

//---------------------------------------------------------------------
int[] GetNumbersEven(int[] numbers)
{
    var contEvens = 0;
    foreach (var number in numbers)
    {
        if (isEven(number))
        {
            contEvens++;
        }
    }

    int[] numbersEven = new int[contEvens];
    var i = 0;
    foreach (var number in numbers)
    {
        if (isEven(number))
        {
            numbersEven[i]=number;
            i++;
        }
    }
    return numbersEven;
}

//---------------------------------------------------------------------
bool isEven(int number)
{
    return number%2 == 0;
}

//---------------------------------------------------------------------
int[] GetNumbersOdd(int[] numbers)
{
    var contOdds = 0;
    foreach (var number in numbers)
    {
        if (isOdd(number))
        {
            contOdds++;
        }
    }

    int[] numbersOdd = new int[contOdds];
    var i = 0;
    foreach (var number in numbers)
    {
        if (isOdd(number))
        {
            numbersOdd[i] = number;
            i++;
        }
    }
    return numbersOdd;
}

//---------------------------------------------------------------------
bool isOdd(int number)
{
    return number % 2 != 0;
}