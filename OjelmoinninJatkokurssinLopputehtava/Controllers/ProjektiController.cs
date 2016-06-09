using OhjelmoinninJatkokurssinLopputehtava.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OhjelmoinninJatkokurssinLopputehtava.Controllers
{
    public class ProjektiController : Controller
    {
        // GET: Projekti
        public ActionResult Index()
        {
            var entities = new ProjektitEntities();
            var model = entities.Projektit.ToList();
            entities.Dispose();
            return View(model);
        }

        public ActionResult Henkilotunnit(int projekti_id)
        {
            ProjektitEntities entities = new ProjektitEntities();
            var model = entities.Tunnit.Where(t => t.Projekti_id == projekti_id).ToList();
            

            //projektin nimi näkymää varten
            var nimi = (from pr in entities.Projektit
                        where pr.Projekti_id == projekti_id
                        select pr.Nimi).ToList().FirstOrDefault();
            ViewBag.ProjektiNimi = nimi;

            // nimilista näkymää varten
            Dictionary<int, string> names = new Dictionary<int, string>();
            var ht = entities.Henkilot.ToList();
            foreach(var h in ht)
            {
                names.Add(h.Henkilo_id, h.Etunimi + " " + h.Sukunimi);
            }
            ViewBag.Nimilista = names;

            entities.Dispose();

            return View(model);
        }
    }
}