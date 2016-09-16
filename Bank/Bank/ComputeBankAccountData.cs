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
 
        public void AfisareSold()
        {
            BanckAccount obj = ObjectFromListBasedOnIBAN();
            Console.WriteLine("Suma din cont este: {0}", obj.Suma);
        }

        public void AfisarePrimeleTreiSumeMaiMari()
        {
            var query = _account.OrderByDescending(x => x.Suma);
            Console.WriteLine("Primele cele mai mari trei sume sunt: ");
            int count = 0;
            foreach (var item in query)
            {
                if (count > 2) break;
                Console.WriteLine(item.Suma);
                count++;
            }
        }

        public void DeleteContByNameOrIBAN()
        {
            Console.WriteLine("Introduceti metoda prin care doriti sa stergeti contul: 1-Nume sau 2-IBAN");
            var option = Convert.ToInt32(Console.ReadLine());


            switch (option)
            {
                case 1:
                    {
                        Console.Write("Introduceti numele care doriti sa fie sters: ");
                        string name = Console.ReadLine();
                        if (_account.Exists(x => x.NumeUser == name))
                        {
                            _account.RemoveAll(x => x.NumeUser == name);
                            Console.WriteLine("Contul/urile a/au fost sters/e!");
                        }
                        else
                        {
                            Console.WriteLine("Contul cu numele cautat nu exista!");
                        }
                        break;
                    }
                case 2:
                    {
                        Console.Write("Introduceti IBANul care doriti sa fie sters: ");
                        int iBAN = Convert.ToInt32(Console.ReadLine());
                        if(_account.Exists(x => x.IBAN == iBAN))
                        {
                            _account.RemoveAll(x => x.IBAN == iBAN);
                            Console.WriteLine("Contul/urile a/au fost sters/e!");
                        }
                        else
                        {
                            Console.WriteLine("Contul cu IBANul cautat nu exista!");
                        }
                        
                        break;
                    }

                default:
                    Console.WriteLine("Optiunea introdusa nu este corecta. Alegeti intre 1 sau 2!");
                    break;
            }
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
