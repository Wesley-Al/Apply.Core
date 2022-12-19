using System;
using System.Collections.Generic;
using System.Text;

namespace Intru.Library
{
    public class CategoryCardParameters
    {
        public List<long> CCCodList { get; set; }
        public long? CCCod { get; set; }
        public string CCName { get; set; }
        public string Color { get; set; }
        public bool? CCTypeFixed { get; set; }
        public long UsuCod { get; set; }
    }
}
