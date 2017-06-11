using _2014140087_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140087_PER.Entities
{
    public class TecladoConfiguration:EntityTypeConfiguration<Teclado>
    {
        public TecladoConfiguration()
        {
            ToTable("Teclado");
            HasKey(c => c.TecladoId);
        }
    }
}
