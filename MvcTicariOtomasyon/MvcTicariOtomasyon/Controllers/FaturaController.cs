using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTicariOtomasyon.Models.Siniflar;
namespace MvcTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var liste = c.Faturalars.ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Faturalar d)
        {
            c.Faturalars.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturalars.Find(id);
            return View("FaturaGetir", fatura);
        }

        public ActionResult FaturaGuncelle(Faturalar b)
        {
            var fatura = c.Faturalars.Find(b.Faturaid);
            fatura.FaturaSeriNo = b.FaturaSeriNo;
            fatura.FaturaSıraNo = b.FaturaSıraNo;
            fatura.VergiDairesi = b.VergiDairesi;
            fatura.Tarih = b.Tarih;
            fatura.Saat = b.Saat;
            fatura.TeslimEden = b.TeslimEden;
            fatura.TeslimAlan = b.TeslimAlan;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.Faturaid == id).ToList();
            var dgr = c.Faturalars.Where(x => x.Faturaid == id).Select(y => y.FaturaSeriNo + "-" + y.FaturaSıraNo).FirstOrDefault();
            ViewBag.ftr = dgr;
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem d)
        {
            c.FaturaKalems.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}