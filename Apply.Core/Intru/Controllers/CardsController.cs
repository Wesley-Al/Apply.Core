using Intru.Library;
using Intru.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Intru.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardsController : ControllerBase
    {
        private ICardsService iCardsSVC;
        private IWalletService iWalletSVC;
        private ICategoryService iCategoryService;

        public CardsController(ICardsService cardsService,
                               IWalletService walletService,
                               ICategoryService iCategoryService)
        {
            this.iWalletSVC = walletService;
            this.iCardsSVC = cardsService;
            this.iCategoryService = iCategoryService;
        }

        [HttpPost("CadastrarCard")]
        public IActionResult CadastrarCard([FromBody] CardsParameters Card)
        {
            Retorno<bool> retorno = new Retorno<bool>();

            retorno.ErroMsg = "";
            retorno.Success = true;
            retorno.Objeto = true;

            try
            {
                iCardsSVC.CadastraRegistro(Card);

                return Ok(retorno);
            }
            catch (Exception error)
            {
                retorno.ErroMsg = error.InnerException.Message;
                retorno.Success = false;
                retorno.Objeto = false;

                return Ok(retorno);
            }
        }

        [HttpPost("GetByUsuCod")]
        public IActionResult GetByUsuCod(long usuCod, string dataJoined)
        {
            Retorno<WalletViewModel> retorno = new Retorno<WalletViewModel>();
            try
            {
                retorno.Success = true;
                retorno.Objeto = iWalletSVC.GetCardsByUsuCod(usuCod, dataJoined);

                return Ok(JsonConvert.SerializeObject(retorno));
            }
            catch (Exception error)
            {
                retorno.Success = false;
                retorno.Objeto = null;
                retorno.ErroMsg = error.Message;

                return Ok(retorno);
            }
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            Retorno<WalletViewModel> retorno = new Retorno<WalletViewModel>();
            try
            {
                retorno.Success = true;
                retorno.Objeto = iWalletSVC.GetCardsByUsuCod(1, "All");

                return Ok(JsonConvert.SerializeObject(retorno));
            }
            catch (Exception error)
            {
                retorno.Success = false;
                retorno.Objeto = null;
                retorno.ErroMsg = error.Message;

                return Ok(retorno);
            }
        }

        [HttpPost("DeleteAllCards")]
        public ActionResult DeleteAllCards([FromBody] long usuCod)
        {
            Retorno<List<string>> retorno = new Retorno<List<string>>()
            {
                Objeto = new List<string>(),
                ErroMsg = "",
                Success = true
            };

            try
            {
                long codWallet = iWalletSVC.GetWalletByUsuCod(usuCod).CodWallet;

                iCardsSVC.DeleteAll(codWallet);
                
                return Ok(retorno);

            }
            catch (Exception error)
            {
                retorno.Success = false;
                retorno.Objeto = null;
                retorno.ErroMsg = error.InnerException.Message;

                return Ok(retorno);
            }
        }

        [HttpPost("DeleteCards")]
        public ActionResult DeleteCards([FromBody] CardsParameters cards)
        {
            Retorno<List<string>> retorno = new Retorno<List<string>>()
            {
                Objeto = new List<string>(),
                ErroMsg = "",
                Success = true
            };

            try
            {
                foreach (var item in cards.CCCodList)
                {
                    iCardsSVC.DeleteByCod(item);
                }

                iCategoryService.Save();
                return Ok(retorno);

            }
            catch (Exception error)
            {
                retorno.Success = false;
                retorno.Objeto = null;
                retorno.ErroMsg = error.InnerException.Message;

                return Ok(retorno);
            }
        }
    }
}
