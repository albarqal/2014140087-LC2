using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140087_ENT
{
   public class Cuenta
    {
        public int NumeroCuenta { get; set; }
        public int Pin { get; set; }
        
        

        //Retiro
        public List<Retiro> Retiros { get; set; }

        public Cuenta()
        {
            Retiros = new List<Retiro>();
        }

    }
}
