using Intru.Library;
using Intru.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Intru.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private ICategoryService iCategoryService;
        private ISecurityService iSecurityService;        
        private ICardsService iCardsService;
        public CategoryController(ICategoryService categoryService,
                                 ISecurityService securityService,                                 
                                 ICardsService  cardsService)
        {
            this.iCategoryService = categoryService;
            this.iSecurityService = securityService;            
            this.iCardsService = cardsService;
        }

        [HttpPost("CadastrarCategoria")]
        public IActionResult CadastrarCategoria([FromBody] CategoryCardParameters CategoryParameter)
        {
            Retorno<bool> retorno = new Retorno<bool>();

            retorno.ErroMsg = "";
            retorno.Success = true;
            retorno.Objeto = true;

            try
            {
                if (CategoryParameter.UsuCod != 0 && CategoryParameter != null)
                {
                    CategoryCard Category = new CategoryCard
                    {
                        CCDataCadatro = DateTime.Now,
                        CCName = CategoryParameter.CCName,
                        CCTypeFixed = (bool)CategoryParameter.CCTypeFixed,
                        UsuarioNavigation = iSecurityService.GetByCodUsuario(CategoryParameter.UsuCod)
                    };
                    iCategoryService.CadastraCategoria(Category);
                }

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

        [HttpPost("GetAllByUsuCod")]
        public IActionResult GetAllByUsuCod(long usuCod)
        {
            Retorno<List<CategoryCardParameters>> retorno = new Retorno<List<CategoryCardParameters>>();

            retorno.ErroMsg = "";
            retorno.Success = true;
            retorno.Objeto = new List<CategoryCardParameters>();

            try
            {
                List<CategoryCardParameters> category = new List<CategoryCardParameters>();

                category = iCategoryService.GetAllByUsuCod(usuCod).Select(x => new CategoryCardParameters
                {
                    CCCod = x.CCCod,
                    CCName = x.CCName,
                    CCTypeFixed = x.CCTypeFixed
                }).ToList();

                retorno.Objeto = category;

                return Ok(retorno);
            }
            catch (Exception error)
            {
                retorno.ErroMsg = error.InnerException.Message;
                retorno.Success = false;
                retorno.Objeto = null;

                return Ok(retorno);
            }
        }

        [HttpPost("DeleteAllCategorys")]
        public ActionResult DeleteAllCategorys([FromBody] long usuCod)
        {
            Retorno<List<string>> retorno = new Retorno<List<string>>()
            {
                Objeto = new List<string>(),
                ErroMsg = "",
                Success = true
            };

            try
            {
                List<CategoryCard> categoryCards = iCategoryService.GetAllByUsuCod(usuCod);

                foreach (var item in categoryCards)
                {
                    bool possuiCard = iCardsService.GetAllByCCCod(item.CCCod)?.Count() > 0;

                    if (!possuiCard)
                    {
                        iCategoryService.Delete(item);
                    }
                    else
                    {
                        retorno.Objeto.Add($"A Categoria {item.CCName} não pode ser deletada pois pode existir registros vinculaods a ela.");
                    }

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
        [HttpPost("DeleteCategorys")]
        public ActionResult DeleteCategorys([FromBody] CategoryCardParameters categorys)
        {
            Retorno<List<string>> retorno = new Retorno<List<string>>()
            {
                Objeto = new List<string>(),
                ErroMsg = "",
                Success = true
            };

            try
            {
                List<CategoryCard> categoryCards = iCategoryService.GetAllByUsuCod(categorys.UsuCod).Where(x => categorys.CCCodList.Contains(x.CCCod)).ToList();

                foreach (var item in categoryCards)
                {
                    bool possuiCard = iCardsService.GetAllByCCCod(item.CCCod)?.Count() > 0;

                    if (!possuiCard)
                    {
                        iCategoryService.Delete(item);
                    }
                    else
                    {
                        retorno.Objeto.Add($"A Categoria {item.CCName} não pode ser deletada pois pode existir registros vinculaods a ela.");
                    }

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
