using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Encriptador
{
    public class Encrip
    {
        /*codificar*/
        public string Encodi(string text)
        {
            byte[] enc = Encoding.Unicode.GetBytes(text);
            var resul = Convert.ToBase64String(enc);
            Console.WriteLine(resul);
            return resul;
        }
        /*decodificar */
        public string Descrip(string tex)
        {
            byte[] encod = Convert.FromBase64String(tex);
            var resul = Encoding.Unicode.GetString(encod);
            Console.WriteLine(resul);
            return null;
        }


        // Función para cifrar una cadena.
        public string Cifrar(string cadena)
        {
            byte[] llave = UTF32Encoding.UTF8.GetBytes("prueba"); //Arreglo donde guardaremos la llave para el cifrado 3DES.
            byte[] arreglo = UTF8Encoding.UTF8.GetBytes(cadena); //Arreglo donde guardaremos la cadena descifrada.
                                                                 // Ciframos utilizando el Algoritmo MD5.

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            llave = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes("cadenadecifrado"));
            md5.Clear();
            //Ciframos utilizando el Algoritmo 3DES.
            TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider();
            tripledes.Key = llave;
            tripledes.Mode = CipherMode.ECB;
            tripledes.Padding = PaddingMode.PKCS7;
            ICryptoTransform convertir = tripledes.CreateEncryptor(); // Iniciamos la conversión de la cadena
            byte[] resultado = convertir.TransformFinalBlock(arreglo, 0, arreglo.Length); //Arreglo de bytes donde guardaremos la cadena cifrada.
            tripledes.Clear();
            return Convert.ToBase64String(resultado, 0, resultado.Length); // Convertimos la cadena y la regresamos.
        }


        // Función para descifrar una cadena.
        public string Descifrar(string cadena)
        {
            byte[] llave = UTF32Encoding.UTF8.GetBytes("prueba");
            byte[] arreglo = Convert.FromBase64String(cadena); // Arreglo donde guardaremos la cadena descovertida.
            // Ciframos utilizando el Algoritmo MD5.
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            llave = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes("cadenadecifrado"));
            md5.Clear();
            //Ciframos utilizando el Algoritmo 3DES.
            TripleDESCryptoServiceProvider tripledes = new TripleDESCryptoServiceProvider();
            tripledes.Key = llave;
            tripledes.Mode = CipherMode.ECB;
            tripledes.Padding = PaddingMode.PKCS7;
            ICryptoTransform convertir = tripledes.CreateDecryptor();
            byte[] resultado = convertir.TransformFinalBlock(arreglo, 0, arreglo.Length);
            tripledes.Clear();
            string cadena_descifrada = UTF8Encoding.UTF8.GetString(resultado); // Obtenemos la cadena
            return cadena_descifrada; // Devolvemos la cadena
        }


        /*encriptar con clave*/

    }
}
