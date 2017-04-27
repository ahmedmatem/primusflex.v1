namespace PrimusFlex.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using PrimusFlex.Data.Common;
    using PrimusFlex.Data.Models;
    using PrimusFlex.Web.ViewModels;

    [Authorize]
    public class SiteController : BaseController
    {
        private readonly IDbRepository<Site> sites;

        public SiteController()
        {
            this.sites = new DbRepository<Site>(this.context);
        }

        // GET: Site
        public ActionResult Index()
        {
            return View();
        }

        // POST: Site/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SiteViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            return View();
        }

        // ASYNC POST: Site/CreateSiteAsync
        [HttpPost]
        public ActionResult CreateSiteAsync(SiteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { status = "Error", message = "All fields are required." });
            }

            Site site = new Site()
            {
                Name = model.Name,
                Address = model.Address,
                PostCode = model.PostCode
            };
            sites.Add(site);
            sites.Save();

            return Json(new { status = "OK", message = string.Format("Site {0} was successfully added", model.Name) });
        }
    }
}