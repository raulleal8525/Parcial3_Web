using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Parcial3_Web.Filters
{
    public class AuthorizeUser : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // Verificar si el usuario está autenticado
            var usuarioAutenticado = context.HttpContext.Session.GetString("UsuarioAutenticado");
            var usuarioId = context.HttpContext.Session.GetInt32("UsuarioId");

            if (string.IsNullOrEmpty(usuarioAutenticado) || usuarioAutenticado != "true" || !usuarioId.HasValue)
            {
                // Si no está autenticado, redirigir al login
                context.Result = new RedirectToActionResult("Index", "Home", null);
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}