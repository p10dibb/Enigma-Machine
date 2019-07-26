using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enigma
{
    class Program
    {
        static void Main(string[] args)
        {

            Machine m = new Machine();
            m.SetPlugs("Ab CD");

            string a = m.encrypt_Rings("AA");
            Console.WriteLine("AA="+a);

            Console.WriteLine(a+"==" + m.decrypt_Rings(a));


        }
    }
}
