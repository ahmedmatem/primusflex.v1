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
    public class ItemController : BaseController
    {
        private readonly IDbRepository<Item> items;

        public ItemController()
        {
            this.items = new DbRepository<Item>(this.context);
        }

        // GET: Item
        public ActionResult Index()
        {
            IEnumerable<ItemViewModel> model = this.items
                                        .All()
                                        .OrderBy(i => i.Name)
                                        .Select(i => new ItemViewModel()
                                        {
                                            Name = i.Name,
                                            ShortName = i.ShortName
                                        })
                                        .ToList();

            return View(model);
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Item/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var item = new Item()
            {
                Name = model.Name,
                ShortName = model.ShortName
            };

            this.items.Add(item);
            this.items.Save();

            return RedirectToAction("Index");
        }

        // ASYNC POST: Item/CreateItemAsync
        [HttpPost]
        public ActionResult CreateItemAsync(ItemViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { status = "Error", message = "<Name> field is required." });
            }

            Item item = new Item()
            {
                Name = model.Name,
                ShortName = model.ShortName
            };
            items.Add(item);
            items.Save();

            return Json(new { status = "OK", message = string.Format("Item {0} was successfully added", model.Name) });
        }
    }
}