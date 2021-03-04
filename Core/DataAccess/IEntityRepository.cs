using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //generic constraint --->  where T:class , Class means it is a referance type, not the general class we know.
    //where T:class,IEntity ---> It is only a "IEntity" or an object that implements "IEntity".
    //new(): it should be like "new Product()". 
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
