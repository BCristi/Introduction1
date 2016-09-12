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

        
        static public List<BanckAccount> GetAccounts()
        {
            return _account;
        }

        public void CreareCont()
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

        public void DepunereBancara()
        {
            var obj = ObjectFromListBasedOnIBAN();
            Console.Write("Introduceti suma:");

            obj.Suma += Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Depunere cu succes. Suma totala este:{0}", obj.Suma);
        }

        public void RetragereBancara()
        {
            var obj = ObjectFromListBasedOnIBAN();

            Console.Write("Introduceti suma pentru extragere:");
            int sumaRetrasa = Convert.ToInt32(Console.ReadLine());
            obj.Suma -= sumaRetrasa;

            Console.WriteLine("Retragere cu succes. Suma totala este:{0}", obj.Suma);
            
            OnSumaRetrasa(sumaRetrasa);
        }

        
        public event EventHandler<ComisionEventArgs> SumaRetrasa;


        protected void OnSumaRetrasa(int sumaRetrasa)
        {
            if (SumaRetrasa != null)
                SumaRetrasa(this, new ComisionEventArgs() { SumaRetrasa = sumaRetrasa });
        }
 


        //Utilities
        public static BanckAccount ObjectFromListBasedOnIBAN()
        {
            Console.Write("IBANul este:");
            int iBAN = Convert.ToInt32(Console.ReadLine());
            var obj = _account.Find(x => x.IBAN == iBAN);
            return obj;
        }
    }
}
