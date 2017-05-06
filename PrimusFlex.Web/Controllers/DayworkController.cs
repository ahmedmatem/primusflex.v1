namespace PrimusFlex.Web.Controllers
{
    using System;
    using System.Collections.Generic;
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
    public class DayworkController : BaseController
    {
        private readonly IDbRepository<Daywork> dayworks;
        private readonly IDbRepository<Site> sites;

        public DayworkController()
        {
            this.dayworks = new DbRepository<Daywork>(this.context);
            this.sites = new DbRepository<Site>(this.context);
        }

        // GET: Daywork
        public ActionResult Index()
        {
            string fitterId = User.Identity.GetUserId();
            var model = this.dayworks.All()
                            .Where(d => d.FitterId == fitterId)
                            .OrderByDescending(d => d.Date)
                            .Select(d => new DayworkViewModel()
                            {
                                Id = d.Id,
                                Date = d.Date,
                                Note = d.Note,
                                Description = d.Description,
                                CompanyType = d.CompanyType,
                                SiteId = d.SiteId,
                                SiteName = d.Site.Name
                            })
                            .ToList();


            return View(model);
        }

        // GET: Daywork/Create
        public ActionResult Create()
        {
            DayworkCreateViewModel model = new DayworkCreateViewModel();
            var sites = new SiteData(this.sites).GetAllSitesAsSelectListItems();

            // setting some default values
            model.Date = DateTime.Now.ToString("dd/MM/yyyy");
            model.SiteNames = sites;

            return View(model);
        }

        // POST: Daywork/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DayworkCreateViewModel model)
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

            // create new daywork in database
            Daywork daywork = new Daywork()
            {
                Date = model.Date.DDMMYYtoDate('/'),
                CompanyType = model.CompanyType,
                FitterId = User.Identity.GetUserId(),
                SiteId = model.SiteId,
                Description = model.Description,
                Note = model.Note
            };

            this.dayworks.Add(daywork);
            this.dayworks.Save();

            return RedirectToAction("Index");
        }

        // GET: Daywork/Edit/id
        public ActionResult Edit(int id)
        {
            var daywork = this.dayworks.GetById(id);

            if(daywork != null && daywork.FitterId == User.Identity.GetUserId())
            {
                var model = new DayworkEditViewModel()
                {
                    Id = daywork.Id,
                    Date = daywork.Date,
                    SiteId = daywork.Site.Id,
                    CompanyType = daywork.CompanyType,
                    Description = daywork.Description,
                    Note = daywork.Note,
                    SiteName = daywork.Site.Name
                };

                var sites = new SiteData(this.sites).GetAllSitesAsSelectListItems(model.SiteId.ToString());
                model.SiteNames = sites;

                return View(model);
            }

            return RedirectToAction("Index");
        }

        // POST: Daywork/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DayworkEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var editedDayeork = this.dayworks.GetById(model.Id);
            if (editedDayeork != null && editedDayeork.FitterId == User.Identity.GetUserId())
            {
                editedDayeork.Date = model.Date;
                editedDayeork.SiteId = model.SiteId;
                editedDayeork.Description = model.Description;
                editedDayeork.CompanyType = model.CompanyType;
                editedDayeork.Note = model.Note;

                this.dayworks.Update(editedDayeork);
                this.dayworks.Save();
            }

            return RedirectToAction("Index");
        }
    }    
}