using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TP_Cine.Models.ModeloNegocio;

namespace TP_Cine.Controllers
{
    public class HomeController : Controller
    {
        CineNegocio CN = new CineNegocio(); //Lo creamos acá y lo usamos en todas las acciones

        //
        // GET: /Home/
        public ActionResult Inicio()
        {
            CN.listarPeliculasNegocio();

            return View(CN.listaPeliculasNegocio);
        }


        public ActionResult Login(string returnUrl)
        {
            //ViewBag.ReturnUrl = returnUrl; //Esto me tira ArgumentException si pongo mal los datos y lo vuelvo a intentar
            Session["url"] = returnUrl; //Con esto funciona
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
                    //return Redirect(returnUrl);  //Esto me tira ArgumentException si pongo mal los datos y lo vuelvo a intentar
                    return Redirect(Session["url"].ToString()); //Con esto funciona

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
