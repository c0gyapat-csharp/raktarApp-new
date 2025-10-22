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


WarehouseCsvRepo repo = new WarehouseCsvRepo();

repo.CsvReader(filePath);

Console.WriteLine(repo.GetSchemaErrorReport());

Console.WriteLine("Sikeresen beolvasott rekordok száma: " + repo.Warehouses.Count);