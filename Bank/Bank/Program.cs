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
            // ComputeBankAccountData calcData1 = new ComputeBankAccountData();

            //List<BanckAccount> accounts = ComputeBankAccountData.GetAccounts();

            ComissionService comision = new ComissionService();
            calcData.SumaRetrasa += comision.OnRetragereBancara;

            var menu = true;
            while (menu)
            {
                Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++");


                Console.WriteLine("Alegeti optiunea dorita:");
                Console.WriteLine("------------------------------------------------------");

                Console.WriteLine("1 - Citire nume banca din fisier");
                Console.WriteLine("2 - Creare cont");
                Console.WriteLine("3 - Depunere bancara");
                Console.WriteLine("4 - Retragere bancara");
                Console.WriteLine("5 - Afisare sold");
                Console.WriteLine("6 - Afisare primele 3 conturi cu sumele cele mai mare");
                Console.WriteLine("7 - Stergere cont dupa nume sau IBAN");
                Console.WriteLine("0 - Iesire");
                Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                var optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        
                        //menu = false;
                        break;
                    case "2":
                        calcData.CreareCont();
                        Console.WriteLine();
                        //menu = false;
                        break;
                    case "3":
                        calcData.DepunereBancara();
                        Console.WriteLine();
                        //menu = false;
                        break;
                    case "4":
                        calcData.RetragereBancara();
                        Console.WriteLine();
                        break;
                    case "5":
                        calcData.AfisareSold();
                        break;
                    case "6":
                        calcData.AfisarePrimeleTreiSumeMaiMari();
                        break;
                    case "7":
                        calcData.DeleteContByNameOrIBAN();
                        break;

                    case "0":
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
