﻿using _2014140087_ENT;
using _2014140087_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140087_PER.Repositories
{
    public class CuentaRepository : Repository<Cuenta>, ICuentaRepository
    {

        public CuentaRepository(_2014140087DbContext context) : base( context){
            

        }

       /* private readonly _2014140087DbContext _Context;

        public CuentaRepository(_2014140087DbContext context)
        {
            _Context = context;
        }
        private CuentaRepository()
        {

        }*/
    }
}
