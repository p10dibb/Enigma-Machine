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

            Machine m = new Machine("a","123","HAl","Ah bk mc xp qu sn iy ot wg jf");
           

            string a = "Hello World";
            Console.WriteLine(a);
            a = m.CharSwap_Plugs(a);
            Console.WriteLine(a);
            a = m.encrypt_Rings(a);
            Console.WriteLine(a);
            a = m.CharSwap_Plugs(a);
            Console.WriteLine(a);
            a = m.encrypt_Rings_back(a);
            Console.WriteLine(a);
            Console.WriteLine("--------");

            Console.WriteLine(a);
            a = m.encrypt_Rings(a);
            Console.WriteLine(a);
            a = m.CharSwap_Plugs(a);
            Console.WriteLine(a);
            a = m.encrypt_Rings_back(a);
            Console.WriteLine(a);
            a = m.CharSwap_Plugs(a);
            Console.WriteLine(a);









        }
    }
}
