using System;

namespace Encriptador
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Encrip encrip = new Encrip();

           var resul= encrip.Cifrar("Planillas sepp");
            Console.WriteLine(resul);

            var res = encrip.Descifrar(resul);
            Console.WriteLine(res);

        }
    }
}
