﻿using _2014140087_ENT;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140087_PER.Entities
{
    public class DispensadorEfectivoConfiguration:EntityTypeConfiguration<DispensadorEfectivo>
    {
        public DispensadorEfectivoConfiguration()
        {
            ToTable("DispensadorEfectivo");

            HasKey(c => c.DispensadorEfectivoId);


        }
    }
}
