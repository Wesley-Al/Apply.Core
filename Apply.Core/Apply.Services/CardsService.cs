using System;
using System.Collections.Generic;
using System.Linq;
using Intru.Library;
using Microsoft.EntityFrameworkCore;

namespace Intru.Services
{
    public class CardsService : ICardsService
    {
        private readonly Context Context;
        private IWalletService iWalletSVC;
        public CardsService(Context context, IWalletService walletService)
        {
            Context = context;
            this.iWalletSVC = walletService;
        }

        public bool DeleteAll(long codWallet)
        {
            try
            {
                Context.Card.RemoveRange(Context.Card                    
                    .Where(x => x.CodWallet == codWallet)
                    .ToArray());                

                return Context.SaveChanges() > 0;
            }catch(Exception)
            {
                throw;
            }
        }
        public bool CadastraRegistro(CardsParameters cards)
        {
            try
            {
                Wallet wallet = iWalletSVC.GetWalletByUsuCod(cards.UsuCod);

                CategoryCard category = Context.CategoryCard
                    .Include(x => x.UsuarioNavigation)
                    .Where(x => x.CCCod == cards.CCCod && x.UsuarioNavigation.CodUsuario == cards.UsuCod)
                    .FirstOrDefault();

                Cards card = new Cards() {
                    CategoryCardNavigation = category,
                    WalletNavigation = wallet,

                    TimeString = Convert.ToString((EnumMonth)(cards.Date?.Month != 0 ? cards.Date?.Month - 1 : cards.Date?.Month)),                    
                    CodBank = 0,
                    Time = cards.Date,
                    DateRegistro = DateTime.Now,
                    Title = cards.Title,
                    Type = cards.Type,
                    Amount = cards.Amount,
                    Description = cards.Description                   
                };                               

                Context.Card.Add(card);
                return Context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Cards> GetAllByCCCod(long CCCod)
        {
            try
            {
                return Context.Card
                    .Include(x => x.CategoryCardNavigation)
                    .Where(x => x.CategoryCardNavigation.CCCod == CCCod)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
