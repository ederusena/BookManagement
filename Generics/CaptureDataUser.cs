using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagement.Generics
{
    public class CaptureDataUser
    {
        public static T GetData<T>(string message, Func<string, T> convert)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Clear();
                Console.Write(message);
                var input = Console.ReadLine();

                try
                {
                    var valor = convert(input!);
                    return valor;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}. Tente novamente.");
                }
            }
        }

    }
}