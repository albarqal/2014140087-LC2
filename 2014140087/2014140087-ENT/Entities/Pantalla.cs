using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140087_ENT
{
    public class Pantalla
    {
        public int PantallaId { get; set; }

        //ATM
        public int ATMId { get; set; }
        public ATM ATM { get; set; }

        //Retiro
        public int RetiroId { get; set; }
        public Retiro Retiro { get; set; }
    }
}
