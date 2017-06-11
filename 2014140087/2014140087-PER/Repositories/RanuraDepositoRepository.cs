using _2014140087_ENT;
using _2014140087_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2014140087_PER.Repositories
{
    public class RanuraDepositoRepository : Repository<RanuraDeposito>, IRanuraDepositoRepository
    {
        
        public RanuraDepositoRepository(_2014140087DbContext context) : base(context)
        {

        }
        
        
        
        /*private readonly _2014140087DbContext _Context;

        public RanuraDepositoRepository(_2014140087DbContext context)
        {
            _Context = context;
        }

        private RanuraDepositoRepository()
        {

        }*/
    }
}
