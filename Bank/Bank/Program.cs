using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            ComputeBankAccountData calcData = new ComputeBankAccountData();

            var menu = true;
            while (menu)
            {
                Console.WriteLine("Alegeti optiunea dorita:");
                Console.WriteLine();

                Console.WriteLine("1 - Citire nume banca din fisier");
                Console.WriteLine("2 - Creare cont");
                Console.WriteLine("3 - Depunere bancara");
                Console.WriteLine("4 - Retragere bancara");
                Console.WriteLine("5 - Afisare sold");
                Console.WriteLine("6 - Iesire");

                var optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        
                        //menu = false;
                        break;
                    case "2":
                        calcData.CreareCont();
                        //menu = false;
                        break;
                    case "3":
                        calcData.DepunereBancara();
                        //menu = false;
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        menu = false;
                        break;


                    default:
                        menu = false;
                        break;
                }
            }

        }
    }
}
