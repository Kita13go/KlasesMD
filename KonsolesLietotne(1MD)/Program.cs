using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlasesMD; // Izveidoju referenci uz KlasesMD projektu, lai izmantotu tajā definētās klases un interfeisus

namespace KonsolesLietotne_1MD_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:\\Temp\\data.txt"; //Man failu ceļš ir tāds pats
            var dm = new JSONDataManager(path);
            dm.createTestData(); // Man visas metodes ir ar mazo burtu sākumā, jo Jums pie interfeisa tā bija rakstīts e-studijās
            Console.WriteLine(dm.print());
            dm.save();   // bez parametra path
            dm.reset();
            Console.WriteLine(dm.print());
            dm.load();    // bez parametra path
            Console.WriteLine(dm.print());
            Console.ReadLine();
        }
    }
}
