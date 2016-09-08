using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class ComputeBankAccountData
    {
        static ComputeBankAccountData()
        {
            _account = new List<BanckAccount>();
        }

        static List<BanckAccount> _account;

        public static List<BanckAccount> GetAccounts()
        {
            return _account;
        }

        public static void CreareCont()
        {
            Console.Write("Introduceti numele: ");
            var nume = Console.ReadLine();
            Console.WriteLine();
            
            //Add name and IBAN
            BanckAccount cont = new BanckAccount {
               NumeUser = nume,
               IBAN = _account.Count + 1
            };
            
            //add object to the list
            _account.Add(cont);

            Console.WriteLine("Cont creat cu succes cu numele {0}, IBAN {1}", _account.Last().NumeUser, _account.Last().IBAN);
            Console.WriteLine();

        }

        public static void DepunereBancara()
        {
            var obj = ObjectFromListBasedOnIBAN();
            Console.Write("Introduceti suma:");
            obj.Suma += Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Depunere cu succes. Suma totala este:{0}", obj.Suma);
        }

        public static void RetragereBancara()
        {
            var obj = ObjectFromListBasedOnIBAN();

            Console.Write("Introduceti suma pentru extragere:");
            obj.Suma -= Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Retragere cu succes. Suma totala este:{0}", obj.Suma);
        }

        
        public static BanckAccount ObjectFromListBasedOnIBAN()
        {
            Console.Write("IBANul este:");
            int iBAN = Convert.ToInt32(Console.ReadLine());
            var obj = _account.Find(x => x.IBAN == iBAN);
            return obj;
        }
    }
}
