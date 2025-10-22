using RaktarApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RaktarApp.Repos
{
    internal class WarehouseCsvRepo
    {

        private List<WarehouseCsv> _warehouses = new List<WarehouseCsv>();
        private List<SchemaError> _schemaErrors = new List<SchemaError>();


        public WarehouseCsvRepo() { }

        public WarehouseCsvRepo(List<WarehouseCsv> warehouses)
        {
            _warehouses = warehouses;
        }

        public List<WarehouseCsv> Warehouses => _warehouses;

        public void FromLine(string line, int lineNumber)
        {
            var parts = line.Split(';').ToArray();
            bool isValidLine = true;

            if (parts.Length != 7)
            {
                _schemaErrors.Add(new SchemaError("Oszlopok száma hibás. 7 oszlop szükséges.", lineNumber));
                isValidLine = false;
            }

            if (isValidLine)
            {
                
                if (!int.TryParse(parts[0].Trim(), out int id))
                {
                    _schemaErrors.Add(new SchemaError($"Nem szám: '{parts[0]}' az 'Id' oszlopban. Érvényes egész szám szükséges.", lineNumber));
                    isValidLine = false;
                }

                
                if (string.IsNullOrWhiteSpace(parts[1]))
                {
                    _schemaErrors.Add(new SchemaError("A 'Name' oszlop nem lehet üres vagy csak szóköz.", lineNumber));
                    isValidLine = false;
                }

                
                if (string.IsNullOrWhiteSpace(parts[2]))
                {
                    _schemaErrors.Add(new SchemaError("A 'Country' oszlop nem lehet üres vagy csak szóköz.", lineNumber));
                    isValidLine = false;
                }

                
                if (string.IsNullOrWhiteSpace(parts[3]))
                {
                    _schemaErrors.Add(new SchemaError("A 'Region' oszlop nem lehet üres vagy csak szóköz.", lineNumber));
                    isValidLine = false;
                }

                
                if (!int.TryParse(parts[4].Trim(), out int postCode))
                {
                    _schemaErrors.Add(new SchemaError($"Nem szám: '{parts[4]}' az 'PostCode' oszlopban. Érvényes egész szám szükséges.", lineNumber));
                    isValidLine = false;
                }

                
                if (string.IsNullOrWhiteSpace(parts[5]))
                {
                    _schemaErrors.Add(new SchemaError("A 'City' oszlop nem lehet üres vagy csak szóköz.", lineNumber));
                    isValidLine = false;
                }

                
                if (string.IsNullOrWhiteSpace(parts[6]))
                {
                    _schemaErrors.Add(new SchemaError("Az 'Address' oszlop nem lehet üres vagy csak szóköz.", lineNumber));
                    isValidLine = false;
                }
            }

            if (isValidLine)
            {
                AddCsvFromLine(parts);
            }
        }

        void AddCsvFromLine(string[] parts)
        {
            
            _warehouses.Add(new WarehouseCsv(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5], parts[6]));
        }

        public string GetSchemaErrorReport()
        {
            string errorString = "";

            if (_schemaErrors.Count != 0)
            {
                Console.WriteLine("Hibák (" + _schemaErrors.Count + ")");
                foreach (SchemaError error in _schemaErrors)
                {
                    errorString += "\n" + error.LineNumber + ". sor: " + error.Message;
                }
            }
            return errorString;
        }
    }
}
