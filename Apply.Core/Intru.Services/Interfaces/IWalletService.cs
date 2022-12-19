using Intru.Library;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Intru.Services
{
    public interface IWalletService
    {
        Task<bool> InsertData(WalletParameters wallet);
        public Wallet GetWalletByUsuCod(long usuCod);
        public WalletParameters GetByUsuCod(long codUsuario, string dataJoined = "");
        public WalletViewModel GetCardsByUsuCod(long codUsuario, string dataJoined = "");
    }
}
