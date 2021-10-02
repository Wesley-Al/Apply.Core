using Intru.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Intru.Services
{
    public partial class BaseRepository : IBaseRepository
    {
        private Context _Context;
        public BaseRepository(Context context)
        {            
        }
    }
        public partial class BaseRepository<T> : IBaseRepository<T>
    {
        private Context _Context;
        public BaseRepository(Context context)
        {
            this._Context = context;
        }
        public void Save()
        {
            try
            {
                _Context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Update(T entity)
        {
            try
            {
                _Context.Update(entity);
                Save();
            }
            catch (Exception error)
            {
                throw;
            }
        }
        public void New(T entity)
        {
            try
            {
                _Context.Add(entity);
                Save();
            }
            catch (Exception error)
            {
                throw;
            }
        }
        public void Delete(T entity)
        {
            try
            {
                _Context.Remove(entity);
                Save();
            }
            catch (Exception error)
            {
                throw;
            }
        }
        public void DeleteRange(IList<T> listEntity)
        {
            try
            {
                _Context.RemoveRange(listEntity);
                Save();
            }
            catch (Exception error)
            {
                throw;
            }
        }
    }
}
