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
            obj.Suma -= Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Retragere cu succes. Suma totala este:{0}", obj.Suma);

            //Cum mai trimit un parametru la event handler? precum suma care se doreste extrasa sau i-ul
            //Cat de ok este ca trimit obj tinand cont si 'this'?
            //Cat de ok este sa scad aia 5% acolo?
            int i = obj.IBAN;
            OnSumaRetrasa(obj, i);
        }

        public event EventHandler<BanckAccount> SumaRetrasa;


        protected void OnSumaRetrasa(BanckAccount obj, int i)
        {
            if (SumaRetrasa != null)
                SumaRetrasa(this, obj);
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
