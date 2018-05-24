using System.Web.Mvc;

namespace EDD2_JCSM_3104114.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Error()
        {
            ViewBag.Message = (string)Session["ErrorMessage"];
            Session.Remove("ErrorMessage");
            return View();
        }

        [AllowAnonymous]
        public ActionResult AccessDenied()
        {
            ViewBag.Message = "Acceso denegado.";
            return View();
        }

        // GET: Error
        public ActionResult ErrorInternal()
        {
            ViewBag.ErrorMessage = (string)Session["ErrorMessage"];
            Session.Remove("ErrorMessage");
            return View();
        }
    }
}