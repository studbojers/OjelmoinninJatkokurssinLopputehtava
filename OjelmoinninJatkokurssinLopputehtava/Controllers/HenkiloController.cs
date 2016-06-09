using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OhjelmoinninJatkokurssinLopputehtava.Models;

namespace OhjelmoinninJatkokurssinLopputehtava.Controllers
{
    public class HenkiloController : Controller
    {
        // GET: Henkilo
        public ActionResult Index()
        {
            ProjektitEntities entities = new ProjektitEntities();
            var model = entities.Henkilot.ToList();
            entities.Dispose();

            return View(model);
        }

        public ActionResult Projektitunnit(int henkilo_id)
        {   
            ProjektitEntities entities = new ProjektitEntities();
            var model = entities.Tunnit.Where(t => t.Henkilo_id == henkilo_id).ToList();

            //projektin nimi näkymää varten
            var nimi = (from hl in entities.Henkilot
                        where hl.Henkilo_id == henkilo_id
                        select (hl.Etunimi + " " + hl.Sukunimi)).ToList().FirstOrDefault();
            ViewBag.Henkilonimi = nimi;

            // nimilista näkymää varten
            Dictionary<int, string> names = new Dictionary<int, string>();
            var pr = entities.Projektit.ToList();
            foreach (var p in pr)
            {
                names.Add(p.Projekti_id, p.Nimi);
            }
            ViewBag.Projektilista = names;

            entities.Dispose();

            return View(model);
        }


    }
}