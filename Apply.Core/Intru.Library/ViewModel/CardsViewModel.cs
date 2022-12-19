using System;
using System.Collections.Generic;
using System.Text;

namespace Intru.Library
{
    public class CardViewModel
    {
        public string Amount { get; set; }
        public string Title { get; set; }
        public string TimeString { get; set; }
        public string TypeCard { get; set; }
        public string Type { get; set; }
        public long CCCod { get; set; }
        public long CodCard { get; set; }
        public long UsuCod { get; set; }
        public DateTime? Date { get; set; }
        public bool CardFixed { get; set; }
    }
}
