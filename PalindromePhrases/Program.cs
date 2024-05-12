using Shared;
using System.Runtime.Intrinsics.X86;

Console.WriteLine("*** FRASES PALINDROMAS ***");
Console.WriteLine("--------------------------");

var answer = string.Empty;
var options = new List<string> { "s", "n" };
do
{
    var phrase = ConsoleExtension.GetString("Ingrese la palabra o frase: ");

    var isPalindrome = IsPalindrome(phrase);

    Console.WriteLine($"La frase '{phrase}' {(isPalindrome ? "SI" : "NO")} ES palíndroma");

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
bool IsPalindrome(string phrase)
{
    
    phrase = PreparePhrase(phrase);
    var n = phrase.Length;


    for (int i = 0;i< n / 2; i++)
    {
        if (phrase[i] != phrase[n - i - 1])
        {
            return false;
        };
    }
    return true;
}

//---------------------------------------------------------------------
string PreparePhrase(string phrase)
{
    phrase = phrase.ToLower();
    string newPhrase = string.Empty;
    var exceptions = new List<char> { ' ', ',', '.', ',', ';', '¿', '?', '!', '¡', ':', '-', '_', '"' };

    foreach (char c in phrase)
    {
        if(!exceptions.Contains(c))
        {
            newPhrase += c;
        }
    }
  
    newPhrase = newPhrase.Replace('á', 'a');
    newPhrase = newPhrase.Replace('é', 'e');
    newPhrase = newPhrase.Replace('í', 'i');
    newPhrase = newPhrase.Replace('ó', 'o');
    newPhrase = newPhrase.Replace('ú', 'u');

    return newPhrase;
}