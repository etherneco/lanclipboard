using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ElementController : Controller
    {
        // GET: Element
        public ActionResult Index()
        {
            return View();
        }

        // GET: Element
        public ActionResult Delete(int id)
        {

            Clipboard clipboard = new Clipboard(Server.MapPath("~/App_Data/clipboard.txt"));
            clipboard.Delete(id);

            Response.Redirect("/Home/Index");
            Response.End();
            

            return View();
        }
    }
}