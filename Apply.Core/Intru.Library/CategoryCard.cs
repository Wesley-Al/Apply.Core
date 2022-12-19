using System;
using System.ComponentModel.DataAnnotations;

namespace Intru.Library
{
    public class CategoryCard
    {
        [Key]
        public long CCCod { get; set; }
        public string CCName { get; set; }
        public string Color { get; set; }
        public bool CCTypeFixed { get; set; }
        public DateTime CCDataCadatro { get; set; }
        public Usuario UsuarioNavigation { get; set; }
    }
}
