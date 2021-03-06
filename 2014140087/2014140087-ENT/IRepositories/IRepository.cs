﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _2014140087_ENT.IRepositories
{
    public interface IRepository<TEntity> where TEntity:class
    {

        IQueryable<TEntity> GetEntity();

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);


        TEntity Get(int? id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);


        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);







        //C REATES
        //void Add(TEntity entity);
        //void AddRange(IEnumerable<TEntity> entities);

        //R EADS
        //TEntity Get(int? Id);
        // IEnumerable<TEntity> GetAll();
        //IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        //U PDATES

        //void Update(TEntity entity);
        //void UpdateRange(IEnumerable<TEntity> entities);
        //D ELETES

        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
    }
}
