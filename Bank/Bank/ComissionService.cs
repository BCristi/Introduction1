using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class ComissionService
    {
        public void OnRetragereBancara(object source, ComisionEventArgs sumaRetrasa)
        {
            
            sumaRetrasa.SumaRetrasa -= sumaRetrasa.SumaRetrasa* 95/100;
            Console.WriteLine("S-a retinut comisionul de 5% din suma retrasa in valuare de: {0}", sumaRetrasa.SumaRetrasa);
        }
    }
}
