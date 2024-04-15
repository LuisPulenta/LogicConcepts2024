using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };
do
{
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.Clear();
    Console.WriteLine("*** CALENDARIO ***");
    Console.WriteLine("------------------");

    var year = ConsoleExtension.GetInt("Ingrese AÑO: ");
        
    Console.BackgroundColor=ConsoleColor.Black;
    Console.ForegroundColor=ConsoleColor.Yellow;
    Console.Clear();

    ShowCalendar(year);

    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;

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
void ShowCalendar(int year)
{
    Console.WriteLine($"*** AÑO: {year} ***");
    Console.WriteLine();
    List<string> months = ["ENERO", "FEBRERO", "MARZO", "ABRIL", "MAYO","JUNIO","JULIO","AGOSTO","SETIEMBRE","OCTUBRE","NOVIEMBRE","DICIEMBRE"];

    for (int month = 1; month <= 12; month++)
    {
        Console.WriteLine($"{months.ElementAt(month-1)}");
        Console.WriteLine("Dom\tLun\tMar\tMie\tJue\tVie\tSab");
        Console.WriteLine();
        var daysPerMonth = GetDaysPerMonth(year, month);

        var zeller = Zeller(year, month);
        var daysCounter = 0;

        for (int i = 0; i < zeller; i++)
        {
            Console.Write("\t");
            daysCounter++;
        }

        for(int day = 1; day <= daysPerMonth; day++)
        {
            Console.Write($"{day}\t");
            daysCounter++;
            if(daysCounter == 7)
            {
                Console.WriteLine();
                daysCounter = 0;
            }
        }
        Console.WriteLine();
        Console.WriteLine();
    }
}

//--------------------------------------------------------------------------------------------
int GetDaysPerMonth(int year, int month)
{
    if (month == 2 && DateUtilities.IsLeapYear(year)) return 29;
    List<int> daysPerMonth = [31,28,31,30,31,30,31,31,30,31,30,31];
    return daysPerMonth[month-1];
}

//--------------------------------------------------------------------------------------------
// Devuelve 
// 0 = Domingo, 1 = Lunes, 2 = Martes, 3 = Miercoles, 
// 4 = Jueves, 5 = Viernes, 6 = Sábado 

int Zeller(int ano, int mes)
{
    int a = (14 - mes) / 12;
    int y = ano - a;
    int m = mes + 12 * a - 2;
    int dia = 1, d;

    d = (dia + y + y / 4 - y / 100 + y / 400 + (31 * m) / 12) % 7;

    return (d);
}
