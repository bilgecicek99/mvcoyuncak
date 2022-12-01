using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using obenimdeoyuncagimvc.Models.Entity;


namespace obenimdeoyuncagimvc.Controllers
{
    public class sepetController : Controller
    {
        // GET: uye

        mvc_oyuncakEntities db = new mvc_oyuncakEntities();
        [HttpGet]
        public ActionResult Index()
        {
            var degerler = db.sepet.ToList();
            return View(degerler);

        }
        
        //[Route("/sepet/SepeteEkle/{barkodno}")]
        public ActionResult SepeteEkle(String barkodno)
        {

            var sepetDbInstance =  db.oyuncak.Find(barkodno);

            sepet x = new sepet();
            x.barkodno = sepetDbInstance.barkodno;
            x.oyuncakadi = sepetDbInstance.oyuncakadi;
            x.ureticifirma = sepetDbInstance.ureticifirma;
            x.oyuncakboyutu = sepetDbInstance.oyuncakboyutu;
            x.oyuncakyasgrubu = sepetDbInstance.oyuncakyasgrubu;
            x.teslimtarihi = "28.11.2022";
            x.iadetarihi = "28.11.2022";

            db.sepet.Add(x);
            db.SaveChanges();
            return View("Index");
        }
        [HttpPost]
        public ActionResult temizle(string barkodno)
        {
            var sepet = db.sepet.Find(barkodno);
            db.sepet.Remove(sepet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}