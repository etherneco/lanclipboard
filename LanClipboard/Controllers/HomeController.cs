using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        public void Die(string message)
        {
            Response.Write(message);
            Response.End();

        }

        public ActionResult Index()
        {
            Clipboard clipboard = new Clipboard(Server.MapPath("~/App_Data/clipboard.txt"));

            if (Request.HttpMethod.Equals("POST") && !Request.Form["text"].Equals(""))
            {
                clipboard.Add(Request.Form["text"]);

            }



            ViewBag.clipboard = clipboard.ClipData;
            return View();
        }


        public ActionResult Contact()
        {

            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}