namespace PrimusFlex.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    using Microsoft.AspNet.Identity;

    using PrimusFlex.Data.Common;
    using PrimusFlex.Data.Models;
    using PrimusFlex.Web.Common.DAL;
    using PrimusFlex.Web.ViewModels;

    [Authorize]
    public class MorDItemController : BaseController
    {
        private IDbRepository<MorDItem> mordItems;
        private IDbRepository<Item> items;
        private IDbRepository<Kitchen> kitchens;

        public MorDItemController()
        {
            this.mordItems = new DbRepository<MorDItem>(this.context);
            this.items = new DbRepository<Item>(this.context);
            this.kitchens = new DbRepository<Kitchen>(this.context);
        }

        // GET: MorDItem/
        public ActionResult Index()
        {
            var fitterId = User.Identity.GetUserId();
            var kitchens = this.kitchens.All()
                                .Where(k => k.FitterId == fitterId && k.MorDItems.Count > 0)
                                .OrderByDescending(k => k.Date)
                                .Select(k => new KitchenWithMorDItemViewModel()
                                {
                                    Id = k.Id,
                                    SiteName = k.Site.Name,
                                    PlotNumber = k.PlotNumber,
                                    Date = k.Date,
                                    Company = k.CompanyType
                                })
                                .ToList();

            return View(kitchens);
        }

        // GET: MorDItem/ForKitchen/id
        public ActionResult ForKitchen(int id)
        {
            bool invalidKitchen = false;
            string fitterId = User.Identity.GetUserId();

            var kitchen = this.kitchens.GetById(id);

            string message = "";
            if (kitchen == null)
            {
                // invalid kitchen id
                message = "Unexistable kitchen. Wrong kitchen id!";
                invalidKitchen = true;
            }
            else if (kitchen.FitterId != fitterId)
            {
                // invalid attempt to reach foreign kitchen
                message = "Attempt to access foreign kitchen. It is forbiden.";
                invalidKitchen = true;
            }

            if(invalidKitchen)
            {
                TempData["Message"] = message;
                return RedirectToAction("Index");
            }

            // TODO: try GroupBy for damage or missing
            var model = kitchen.MorDItems
                                .Where(md => md.KitchenId == id)
                                .OrderBy(md => md.MorDType)
                                .ThenBy(md => md.ItemId)
                                .Select(md => new MorDItemViewModel()
                                {
                                    Id = md.Id,
                                    Count = md.Count,
                                    Width = md.Size.Width,
                                    Height = md.Size.Height,
                                    HandSide = md.HandSide,
                                    MorDType = md.MorDType,
                                    Item = md.Item
                                })
                                .ToList();

            ViewBag.KitchenId = id;
            ViewBag.SiteName = kitchen.Site.Name;
            ViewBag.PlotNumber = kitchen.PlotNumber;
            ViewBag.KitchenCompany = kitchen.CompanyType.ToString();

            return View(model);
        }

        // GET: MorDItem/Create/kitchenId
        public ActionResult Create(int id)
        {
            var kitchen = this.kitchens.GetById(id);
            
            ViewBag.SiteName = kitchen.Site.Name;
            ViewBag.PlotNumber = kitchen.PlotNumber;
            ViewBag.KitchenCompany = kitchen.CompanyType.ToString();

            MorDItemViewModel model = new MorDItemViewModel()
            {
                KitchenId = id,
                //HandSide = new HandSide(),
                //MorDType = new MorDType()
            };

            ViewBag.Items = new ItemData(this.items).GetAllItemsAsSelectListItems();

            return View(model);
        }

        // POST: MorDItem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MorDItemViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.HandSide = EnumHelper.GetSelectList(typeof(HandSide));
                ViewBag.MorDType = EnumHelper.GetSelectList(typeof(MorDType));
                ViewBag.Items = new ItemData(this.items).GetAllItemsAsSelectListItems();

                return View(model);
            }
            MorDItem mordItem = new MorDItem()
            {
                Count = model.Count,
                Size = new Size() { Width = model.Width, Height = model.Height },
                HandSide = model.HandSide,
                MorDType = model.MorDType,
                KitchenId = model.KitchenId,
                ItemId = model.ItemId
            };

            this.mordItems.Add(mordItem);
            this.mordItems.Save();

            return RedirectToAction("ForKitchen/" + model.KitchenId);
        }
    }
}