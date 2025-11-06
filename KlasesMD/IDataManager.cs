using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasesMD
{
    public interface IDataManager
    {
        // Metode, kura atgriež kā tekstu informāciju par visiem kolekcijās esošajiem elementiem.
        string print();
        // Metode, kura saglabā kolekciju datus uz diska un atgriež bool vērtību, vai saglabāšana izdevās.
        void save(); // void, jo neko neatgriež
        // Metode, kura ielādē kolekciju datus no diska un atgriež bool vērtību, vai ielāde izdevās.
        void load(); // void, jo neko neatgriež
        // Metode, kura izveido testēšanas datus kolekcijās un atgriež bool vērtību, vai izveide izdevās.
        void createTestData(); // void, jo neko neatgriež
        // Metode, kura iztīra visas kolekcijas un atgriež bool vērtību, vai iztīrīšana izdevās.
        void reset(); // void, jo neko neatgriež
    }
}
