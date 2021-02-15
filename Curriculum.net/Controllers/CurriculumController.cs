using Microsoft.AspNetCore.Mvc;
using System;
using lib.bll;
using Models;
using Swashbuckle.AspNetCore.Annotations;
using lib.Retornos;
using lib.Filters;

namespace Curriculum.net.Controllers
{
    // ASSINANDO AS RESPOSTAS, 200 - OK, 400 - PARAMETROS OBRIGATÓRIOS FALTANTES, 
    [SwaggerResponse(statusCode: 201, "Curriculo criado com sucesso!", Type = typeof(Sucess))]
    [SwaggerResponse(statusCode: 400, "Parametros faltantes!", Type = typeof(ListError))]
    [SwaggerResponse(statusCode: 500, "Erro interno do servidor!", Type = typeof(ErroGenerico))]

    [Route("v1/api")] // configuração de ROTA, setei p prefixo da API para v1/api
    public class CurriculumController : Controller
    {
        bll_Curricullum bll;
        public CurriculumController()
        {
            bll = bll ?? new bll_Curricullum();

            if (bll == null)
                throw new Exception("Erro interno");
        }
        
        [HttpPost("inc")] // v1/api/inc - POST - cria um novo curriculo
        [FilterRequest]  // ASSINO A CHAMADA DO FILTRO NESSA ROTA
        public IActionResult Criar([FromBody] CurriculumModel adt)
        {
            return Created(new Sucess("Curriculo criado com sucesso!").Description, bll.bll_criaCurriculum(adt));
        }

        [HttpPost("HTMLCode")] // v1/api/HTMLCode - POST / retorna a view HTML do Curriculo
        [FilterRequest] // ASSINO A CHAMADA DO FILTRO NESSA ROTA
        public IActionResult ViewResult([FromBody] CurriculumModel adt)
        {
            return View(bll.bll_retornaHTMLCurricullum(adt));
        }
    }
}
