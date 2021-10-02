using Intru.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Intru.Services
{
    public interface ICategoryService
    {        
        public bool CadastraCategoria(CategoryCard category);
        public List<CategoryCard> GetAllByUsuCod(long usuCod);
        public CategoryCard GetByCCName(long usuCod, string ccName);
        public CategoryCard GetByCCCod(long ccCod);
        public void DeleteAll (List<CategoryCard> categoryCards);
        public void Delete(CategoryCard categoryCard);
        void Save();
    }
}
