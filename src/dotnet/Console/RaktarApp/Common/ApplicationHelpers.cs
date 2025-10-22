using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaktarApp.Common
{
    internal class ApplicationHelpers
    {

        public bool FileExists(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("A megadott fájl nem létezik.");
                return false;
            }

            return true;
        }

    }
}
