using _2014140087_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140087_PER.Entities
{
    public class RetiroConfiguration:EntityTypeConfiguration<Retiro>
    {
        public RetiroConfiguration()
        {
            ToTable("Retiro");
            HasKey(c => c.RetiroId);
           
            //Cuenta
            HasMany(c => c.Cuentas)
                .WithMany(c => c.Retiros)
                .Map(m =>
                {
                    m.ToTable("CuentaRetiros");
                    m.MapLeftKey("CuentaId");
                    m.MapRightKey("RetiroId");
                });


        }
    }
}
