using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Siniflar;
namespace MvcTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Kategoris.ToList();
            return View(degerler);
        }
        
        [HttpGet]
        public ActionResult KategoriEkle()
        {    
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Kategori a)
        {
            c.Kategoris.Add(a);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var ktg = c.Kategoris.Find(id);
            c.Kategoris.Remove(ktg);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = c.Kategoris.Find(id);
            return View("KategoriGetir",kategori);
        }

        public ActionResult KategoriGuncelle(Kategori b)
        {
            var ktgr = c.Kategoris.Find(b.KategoriID);
            ktgr.KategoriAd = b.KategoriAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}