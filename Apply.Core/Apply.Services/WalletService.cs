﻿using Intru.Library;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Intru.Services
{
    public class WalletService : IWalletService
    {
        private Context Context;

        public WalletService(Context context)
        {
            this.Context = context;            
        }

        public Wallet GetWalletByUsuCod(long usuCod)
        {
            try
            {
                return Context.UsuarioWallet
                    .Include(x => x.CodWallet)
                    .Include(x => x.CodUsuario)
                    .Where(x => x.CodUsuario.CodUsuario == usuCod)
                    .Select(x => x.CodWallet)
                    .FirstOrDefault();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> InsertData(WalletParameters wallet)
        {
            if (wallet != null)
            {
                wallet.CodBank = 1;

                Bank bank = Context.Banks.Where(x => x.CodBank == 1).FirstOrDefault();

                var Wallet = Context.Usuario.Include(x => x.WalletNavigation)
                    .Where(x => x.CodUsuario == wallet.CodUsuario)
                    .FirstOrDefault()
                    .WalletNavigation;

                var codWallet = Wallet.CodWallet;

                foreach (var item in wallet.Cards)
                {
                    item.CodWallet = codWallet;
                    item.BankNavigation = bank;
                    item.TypeCard = "C";
                }

                foreach (var item in wallet.Payments)
                {
                    item.CodWallet = codWallet;
                    item.BankNavigation = bank;
                    item.TypeCard = "P";
                }

                foreach (var item in wallet.FlowClosed)
                {
                    item.CodWallet = codWallet;
                    item.BankNavigation = bank;
                    item.TypeCard = "F";
                }

                List<Cards> Cards = new List<Cards>();

                Cards.AddRange(wallet.Cards);
                Cards.AddRange(wallet.FlowClosed);
                Cards.AddRange(wallet.Payments);

                Context.Card.AddRange(Cards);

                await Context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public WalletParameters GetByUsuCod(long codUsuario, string dataJoined = "")
        {

            try
            {
                Wallet QueryWallet = new Wallet();
                WalletParameters parameters = new WalletParameters();

                parameters.TimeString = new List<string>();
                parameters.Cards = new List<Cards>();

                var queryData = string.IsNullOrEmpty(dataJoined) ? Array.Empty<string>() : dataJoined.Split(",");

                QueryWallet = Context.Usuario.Include(x => x.WalletNavigation).ThenInclude(x => x.BankNavigation)
                  .Where(x => x.CodUsuario == codUsuario)
                  .FirstOrDefault()
                  .WalletNavigation;

                if (queryData.Length > 0 && (!queryData.Contains("All")) && queryData.Length < 12)
                {
                    var wallet = new
                    {
                        Payments = new List<Cards>(),
                        Cards = new List<Cards>(),
                        FlowClosed = new List<Cards>()
                    };

                    foreach (var item in queryData)
                    {
                        wallet.Payments.AddRange(Context.Card.Where(x => x.CodWallet == QueryWallet.CodWallet && x.TypeCard == "P" && x.TimeString.IndexOf(item) > -1)
                        .ToList().OrderBy(x => x.Description));

                        wallet.Cards.AddRange(Context.Card.Where(x => x.CodWallet == QueryWallet.CodWallet && x.TypeCard == "C" && x.TimeString.IndexOf(item) > -1)
                        .ToList().OrderBy(x => x.TimeString));

                        wallet.FlowClosed.AddRange(Context.Card.Where(x => x.CodWallet == QueryWallet.CodWallet && x.TypeCard == "F" && x.TimeString.IndexOf(item) > -1)
                        .ToList().OrderBy(x => x.TimeString));
                    }

                    var group = wallet.Cards.GroupBy(x => new { x.TimeString });

                    foreach (var item in group)
                    {
                        parameters.TimeString.Add(item.Key.TimeString);
                    }

                    parameters.Cards = wallet.Cards;
                    parameters.Payments = wallet.Payments;
                    parameters.FlowClosed = wallet.FlowClosed;

                }
                else
                {
                    var wallet = new
                    {
                       Payments = Context.Card.Where(x => x.CodWallet == QueryWallet.CodWallet && x.TypeCard == "P")
                        .ToList(),

                       Cards = Context.Card.Where(x => x.CodWallet == QueryWallet.CodWallet && x.TypeCard == "C")
                        .ToList().GroupBy(x => new { x.TimeString }),

                       FlowClosed = Context.Card.Where(x => x.CodWallet == QueryWallet.CodWallet && x.TypeCard == "F")
                        .ToList()
                    };

                    foreach (var item in wallet.Cards)
                    {
                        parameters.TimeString.Add(item.Key.TimeString);

                        foreach (var card in item.ToList())
                        {
                            parameters.Cards.Add(card);
                        }
                    }

                    parameters.Payments = wallet.Payments;

                    parameters.FlowClosed = wallet.FlowClosed;
                }

                return parameters;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
