using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TP_Cine.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

  
        // POST: /Account/Login
        [HttpPost]
        public ActionResult Login(TP_Cine.Usuarios usuario, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                Entities conexion= new Entities();
                int c= conexion.Usuarios.SqlQuery("SELECT * FROM [20171C_TP].[dbo].[Usuarios] where [NombreUsuario]='"+usuario.NombreUsuario+"' and [Password]='"+usuario.Password+"'").Count();

                if (c>0)
                {  // encontro cuenta de usuario
                    Session["administrador"]=1;
                    return Redirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Usuario o password invalidos.");
                }
            }
            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return View(usuario);
        }
        public ActionResult LogOut()
        {
            Session["administrador"] = null;
            return RedirectToAction("Inicio", "Home");
        }
    }

}
