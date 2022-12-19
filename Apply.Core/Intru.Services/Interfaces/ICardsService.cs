using Intru.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Intru.Services
{
    public interface ICardsService
    {
        public bool DeleteAll(long codWallet);
        public bool DeleteByCod(long codCard);
        public bool CadastraRegistro(CardsParameters cards);

        public List<Cards> GetAllByCCCod(long CCCod);
    }
}
