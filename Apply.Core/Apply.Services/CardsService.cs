using System;
using System.Linq;
using Apply.Library;

namespace Apply.Services
{
    public class CardsService : ICardsService
    {
        private readonly Context Context;

        public CardsService(Context context)
        {
            Context = context;
        }

        public bool DeleteAll(long codWallet)
        {
            try
            {
                Context.Card.RemoveRange(Context.Card                    
                    .Where(x => x.CodWallet == codWallet)
                    .ToArray());                

                return Context.SaveChanges() > 0;
            }catch(Exception error)
            {
                throw;
            }
        }
    }
}
