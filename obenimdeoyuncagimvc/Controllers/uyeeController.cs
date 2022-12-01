using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using obenimdeoyuncagimvc.Models.Entity;
using System.Net.Mail;

namespace obenimdeoyuncagimvc.Controllers
{
    public class uyeeController : Controller
    {
        // GET: uye
        mvc_oyuncakEntities db = new mvc_oyuncakEntities();
        public ActionResult Index()
        {
            var degerler = db.uye.ToList();   
            return View(degerler);
        }
        [HttpGet]
        public ActionResult yeniuye()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yeniuye(uye p1)
        {
            var count = db.uye.Count(u => u.tc == p1.tc);
            if (count > 0)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Böyle bir Kayıt var.');</script>");

            }
            else
            {
                db.uye.Add(p1);
                db.SaveChanges();
            }
            
            return RedirectToAction("Index");




        }
        [HttpPost]
        public ActionResult sil(string tc)
        {
            var uye = db.uye.Find(tc);
            
            db.uye.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}