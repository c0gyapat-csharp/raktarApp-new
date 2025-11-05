using RaktarApp.Common;
using RaktarApp.Models;
using RaktarApp.Repos;

Console.Write("Kérem a fájl elérésit útját: ");

string baseDirectory = AppContext.BaseDirectory;
string fileName = Console.ReadLine() ?? string.Empty;
string filePath = Path.Combine(baseDirectory, "..\\..\\..\\TestData", fileName);

ApplicationHelpers appHelpers = new ApplicationHelpers();
WarehouseCsvRepo csvRepo = new WarehouseCsvRepo();
WarehouseDtoRepo dtoRepo = new WarehouseDtoRepo();
WarehouseRepo warehouseRepo = new WarehouseRepo();

if (!appHelpers.FileExists(filePath))
{
    return;
}

csvRepo.CsvReader(filePath);

Console.WriteLine(csvRepo.GetSchemaErrorReport());

Console.WriteLine("Sikeresen beolvasott rekordok száma: " + csvRepo.Warehouses.Count);

csvRepo.Warehouses.ForEach(warehouseCsv =>
{
    try
    {
        dtoRepo.CsvToDto(warehouseCsv);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
});


dtoRepo.Warehouses.ForEach(warehouseDto =>
{
    warehouseRepo.AddDtoWarehouse(warehouseDto);
});

Console.WriteLine("Sikeresen validált rekordok száma: " + dtoRepo.Warehouses.Count);

try
{
    dtoRepo.SyncToDB();
    Console.WriteLine("Adatok sikeresen szinkronizálva az adatbázissal.");
} catch (Exception ex)
{
    Console.WriteLine("Hiba az adatok adatbázisba történő szinkronizálásakor: " + ex.Message);
    return;
}
