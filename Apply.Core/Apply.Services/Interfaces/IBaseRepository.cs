using System;
using System.Collections.Generic;
using System.Text;

namespace Intru.Services
{
    public partial interface IBaseRepository
    { }

        public partial interface IBaseRepository<T>
    {
        public void Save();
        public void Update(T entity);
        public void New(T entity);
        public void Delete(T entity);
        public void DeleteRange(IList<T> listEntity);
    }
}
