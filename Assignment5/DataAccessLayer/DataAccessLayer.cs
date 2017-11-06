using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer
{
    public interface IRepository<T> : IDisposable
    {
        void Insert(T entity);

        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
    }

    class DataAccessLayer
    {
        static void Main(string[] args)
        {
        }
    }
}
