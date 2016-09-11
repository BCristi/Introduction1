using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class ComissionService
    {
        public void OnRetragereBancara(object source, BanckAccount obj)
        {
            Console.WriteLine("Comission service: s-a retras suma!");
            obj.Suma -= obj.Suma * 5/100;
        }
    }
}
