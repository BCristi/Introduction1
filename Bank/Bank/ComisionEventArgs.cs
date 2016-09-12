using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class ComisionEventArgs : EventArgs
    {
        public int SumaRetrasa { get; set; }
    }
}
