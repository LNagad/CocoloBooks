using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacionAdmin.Permisos
{
    public class permisosAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (CapaEntidad.Session.TipoUsuario < 2)
            {
                filterContext.Result = new RedirectResult("~/HomePage/Index");
            }
            else if (CapaEntidad.Session.TipoUsuario > 2 )
            {
                filterContext.Result = new RedirectResult("~/Home/Index");
            }

            base.OnActionExecuting(filterContext);
        }

    }
}