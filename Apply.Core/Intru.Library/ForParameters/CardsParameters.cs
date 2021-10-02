using System;
using System.Collections.Generic;
using System.Text;

namespace Intru.Library
{
    public class CardsParameters
    {
        public string Amount { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public long CCCod { get; set; }
        public long UsuCod { get; set; }
        public DateTime? Date { get; set; }
    }
}
