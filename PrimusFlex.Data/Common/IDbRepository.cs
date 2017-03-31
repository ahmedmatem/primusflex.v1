using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimusFlex.Data.Common
{
    using System.Linq;

    public interface IDbRepository<T> : IDbRepository<T, int>
        where T : BaseModel<int>
    {

    }

    public interface IDbRepository<T, in TKey>
        where T : BaseModel<TKey>
    {
        IQueryable<T> All();

        IQueryable<T> AllWithDeleted();

        T GetById(TKey id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void HardDelete(T entity);

        void Save();

    }
}
