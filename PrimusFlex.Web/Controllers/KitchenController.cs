namespace PrimusFlex.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using PrimusFlex.Data.Common;
    using PrimusFlex.Data.Models;
    using PrimusFlex.Web.Common;
    using PrimusFlex.Web.Common.DAL;
    using PrimusFlex.Web.ViewModels;

    [Authorize]
    public class KitchenController : BaseController
    {
        private readonly IDbRepository<Kitchen> kitchens;
        private readonly IDbRepository<Site> sites;

        public KitchenController()
        {
            this.kitchens = new DbRepository<Kitchen>(this.context);
            this.sites = new DbRepository<Site>(this.context);
        }

        // GET: Kitchen
        public ActionResult Index()
        {
            string fitterId = User.Identity.GetUserId();
            ICollection<KitchenViewModel> kitchens = this.kitchens
                                            .All()
                                            .Where(k => k.FitterId == fitterId)
                                            .OrderByDescending(k => k.Date)
                                            .Select(k => new KitchenViewModel()
                                            {
                                                Id = k.Id,
                                                Date = k.Date,
                                                SiteName = k.Site.Name,
                                                PlotNumber = k.PlotNumber,
                                                Company = k.CompanyType.ToString(),
                                                Shape = k.WorktopShape.ToString(),
                                                ImageCount = k.KitchenImages.Count,
                                                HasMorDItem = (k.MorDItems.Count > 0),
                                                Note = k.Note
                                            })
                                            .ToList();

            return View(kitchens);
        }

        // GET: Kitchen/Create
        public ActionResult Create()
        {
            KitchenCreateViewModel model = new KitchenCreateViewModel();
            var sites = new SiteData(this.sites).GetAllSitesAsSelectListItems();

            // setting some default values
            model.Date = DateTime.Now.ToString("dd/MM/yyyy");
            model.SiteNames = sites;

            return View(model);
        }

        // POST: Kitchen/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (KitchenCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // get all sites for site drop down list
                var sites = new SiteData(this.sites).GetAllSitesAsSelectListItems();

                // setting some default values
                model.Date = DateTime.Now.ToShortDateString();
                model.SiteNames = sites;

                return View(model);
            }

            // create new kitchen in database
            Kitchen kitchen = new Kitchen()
            {
                PlotNumber = model.PlotNumber,
                WorktopShape = model.Shape,
                Date = model.Date.DDMMYYtoDate('/'),
                Note = model.Note,
                CompanyType = model.Company,
                FitterId = User.Identity.GetUserId(),
                SiteId = model.SiteId
            };

            this.kitchens.Add(kitchen);
            this.kitchens.Save();

            return RedirectToAction("Index");
        }

        // GET: Kitchen/Edit/id
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var kitchen = this.kitchens.GetById(id);

            if(kitchen != null && kitchen.FitterId == User.Identity.GetUserId())
            {
                var model = new KitchenEditViewModel()
                {
                    Id = kitchen.Id,
                    Date = kitchen.Date,
                    SiteId = kitchen.Site.Id,
                    PlotNumber = kitchen.PlotNumber,
                    Company = kitchen.CompanyType,
                    Shape = kitchen.WorktopShape,
                    Note = kitchen.Note,
                    SiteName = kitchen.Site.Name
                };
                var sites = new SiteData(this.sites).GetAllSitesAsSelectListItems(model.SiteId.ToString());
                model.SiteNames = sites;

                return View(model);
            }

            return RedirectToAction("Index");
        }

        // POST: Kitchen/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(KitchenEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var editedKitchen = this.kitchens.GetById(model.Id);
            if(editedKitchen != null && editedKitchen.FitterId == User.Identity.GetUserId())
            {
                editedKitchen.Date = model.Date;
                editedKitchen.SiteId = model.SiteId;
                editedKitchen.PlotNumber = model.PlotNumber;
                editedKitchen.CompanyType = model.Company;
                editedKitchen.WorktopShape = model.Shape;
                editedKitchen.Note = model.Note;

                this.kitchens.Update(editedKitchen);
                this.kitchens.Save();
            }

            return RedirectToAction("Index");
        }
    }
}