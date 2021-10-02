using Intru.Library;
using Intru.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Intru.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardsController : ControllerBase
    {
        private ICardsService iCardsSVC;        

        public CardsController(ICardsService cardsService)
        {            
            this.iCardsSVC = cardsService;
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
    }
}
