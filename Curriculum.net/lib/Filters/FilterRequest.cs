using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using lib.Retornos;
using Microsoft.AspNetCore.Mvc;

namespace lib.Filters
{
    public class FilterRequest : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // CRIO UM FILTRO QUE INTERCEPTA AS REQUEST PARA VALIDAR SE O VIEWMODEL É VALIDO OU NÃO
            // ESSA TÉCNICA EVITA REPETIÇÃO DE CÓDIGOS IF(ModelState.IsValid) EM TODAS AS FUNÇÕES DO CONTROLLER
            if (!context.ModelState.IsValid)
            {
                var ErrorList = new ListError(context.ModelState.SelectMany(SM => SM.Value.Errors).Select(s => s.ErrorMessage));
                context.Result =  new BadRequestObjectResult(ErrorList);
            }
        }
    }
}
