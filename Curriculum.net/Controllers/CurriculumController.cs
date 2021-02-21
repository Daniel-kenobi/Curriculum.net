using Microsoft.AspNetCore.Mvc;
using System;
using lib.bll;
using Models;
using Swashbuckle.AspNetCore.Annotations;
using lib.Retornos;
using lib.Filters;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace Curriculum.net.Controllers
{
    // ASSINANDO AS RESPOSTAS, 200 - OK, 400 - PARAMETROS OBRIGATÓRIOS FALTANTES, 
    [SwaggerResponse(statusCode: 200, "Token gerado com sucesso!", Type = typeof(Token))]
    [SwaggerResponse(statusCode: 201, "Curriculo criado com sucesso!", Type = typeof(Sucess))]
    [SwaggerResponse(statusCode: 400, "Parametros faltantes!", Type = typeof(ListError))]
    [SwaggerResponse(statusCode: 401, "Usuário não autorizado!", Type = typeof(ErroGenerico))]
    [SwaggerResponse(statusCode: 500, "Erro interno do servidor!", Type = typeof(ErroGenerico))]

    [Route("v1/api")] // configuração de ROTA, setei p prefixo da API para v1/api
    public class CurriculumController : Controller
    {
        bll_Curricullum bll;
        public CurriculumController()
        {
            bll ??= new bll_Curricullum();

            if (bll == null)
                throw new Exception("Erro interno");
        }

        [HttpPost("inc")] // v1/api/inc - POST - cria um novo curriculo
        [FilterRequest]  // ASSINO A CHAMADA DO FILTRO NESSA ROTA
        [Authorize] // Requisito autorização por token
        public IActionResult Criar([FromBody] CurriculumModel adt)
        {
            try
            {
                bll.bll_criaCurriculum(adt);
                return Created(string.Empty, "Currículo criado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpPost("Token")]
        [FilterRequest]
        public IActionResult GetToken([FromBody] CurriculumModel adt)
        {
            try
            {
                var secret = Encoding.ASCII.GetBytes("aa790cbf9d02deb783286181e4c5dd5");
                var symetricSecurityKey = new SymmetricSecurityKey(secret);
                var securityTokenDescriptor = new SecurityTokenDescriptor
                {
                    /* DE FORMA RESUMIDA O CLAIM É UM ATRIBUTO, QUE TAMBÉM PODE SER HERDADO DA CLASSE PASSADA NO JSON
                     * PODE SER UM ATRIBUTO DO OBJETO, COMO NOME, EMAIL, E-mail, Telefone e etc */
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, adt.Nome)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(20),
                    SigningCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
                };
                var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
                var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);

                return Ok(new
                {
                    Token = token,
                    Description = "Token criado com sucesso"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex?.InnerException?.Message ?? ex.Message);
            }
        }

        [HttpPost("HTMLCode")] // v1/api/HTMLCode - POST / retorna a view HTML do Curriculo
        [FilterRequest] // ASSINO A CHAMADA DO FILTRO NESSA ROTA
        [Authorize] // Requisito autenticação por token novamente
        public IActionResult ViewResult([FromBody] CurriculumModel adt)
        {
            try
            {
                return View(bll.bll_retornaHTMLCurricullum(adt));
            }
            catch (Exception ex)
            {
                return BadRequest(ex?.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
