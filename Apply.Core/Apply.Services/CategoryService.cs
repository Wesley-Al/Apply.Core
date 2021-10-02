using Intru.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Intru.Services
{
    public class CategoryService : ICategoryService
    {
        private Context _Context;
        public CategoryService(Context context)
        {
            this._Context = context;
        }

        public bool CadastraCategoria(CategoryCard category)
        {
            try
            {
                _Context.CategoryCard.Add(category);
                _Context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CategoryCard> GetAllByUsuCod(long usuCod)
        {
            try
            {
                List<CategoryCard> categoryCards = _Context.CategoryCard
                    .Include(x => x.UsuarioNavigation)
                    .Where(x => x.UsuarioNavigation.CodUsuario == usuCod)
                    .ToList();

                return categoryCards;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public CategoryCard GetByCCName(long usuCod, string ccName)
        {
            try
            {
                return _Context.CategoryCard.Include(x => x.UsuarioNavigation)
                    .Where(x => x.CCName.Equals(ccName) && x.UsuarioNavigation.CodUsuario == usuCod)
                    .FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public CategoryCard GetByCCCod(long ccCod)
        {
            try
            {
                return _Context.CategoryCard.Where(x => x.CCCod == ccCod).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void DeleteAll(List<CategoryCard> categoryCards)
        {
            try
            {
                _Context.CategoryCard.RemoveRange(categoryCards);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Delete(CategoryCard categoryCard)
        {
            try
            {
                _Context.CategoryCard.Remove(categoryCard);
            }
            catch (Exception)
            {
                throw;
            }
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
    }
}
