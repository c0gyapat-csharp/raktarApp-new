using RaktarApp.Models;
using RaktarApp.Repos;

Console.WriteLine("File beolvasása:");
Console.WriteLine("---------------");

Console.Write("Kérem a fájl elérésit útját: ");
string filePath = Console.ReadLine() ?? string.Empty;

if (!File.Exists(filePath))
{
    Console.WriteLine("A megadott fájl nem létezik.");
    return;
}

int lineNumber = 1;

WarehouseCsvRepo repo = new WarehouseCsvRepo();

try
{
    foreach (var line in File.ReadAllLines(filePath).Skip(1))
    {
        lineNumber++;
        repo.FromLine(line, lineNumber);
    }
} catch (Exception ex)
{
    Console.WriteLine("Hiba a fájl beolvasása közben: " + ex.Message);
    return;
}

Console.WriteLine(repo.GetSchemaErrorReport());

Console.WriteLine("Sikeresen beolvasott rekordok száma: " + repo.Warehouses.Count);