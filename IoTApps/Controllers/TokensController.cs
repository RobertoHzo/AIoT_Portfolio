using IoTApps.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IoTApps.Controllers
{
    public class TokensController : Controller
    {
        DBModel db = new DBModel();
        public ActionResult Index()
        {
            ViewBag.Sources = db.Sources.ToList();

            List<Token> tokenList = db.Tokens.ToList();
            ViewBag.Tokens = tokenList;

            return View();
        }

        public string Add(int source, string data)
        {
            string msg = "Error procesando la solicitud.";
            try
            {
                if(data != string.Empty && data != null)
                {
                    Token token = new Token()
                    {
                        Data = data,
                        Fecha = DateTime.Now,
                        IdSource = source
                    };
                    db.Tokens.Add(token);
                    db.SaveChanges();
                    msg = "Proceso Exitoso";
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        public  ActionResult Getdata()
        {

            List<Token> tokenList = db.Tokens.ToList();
            ViewBag.Tokens = tokenList;

            return View();
        }
    }
}