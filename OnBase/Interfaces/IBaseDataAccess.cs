using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OnBase.Interfaces
{
    public interface IBaseDataAccess<T>
    {
        List<T> List();
        List<T> List(Expression<Func<T, bool>> filter);
        T Get(int id);
        T Get(Expression<Func<T, bool>> filter);
        void Insert(T entity);
        void Edit(T entity);
        void Remove(int id);
    }
}
