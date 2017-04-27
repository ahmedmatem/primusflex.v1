namespace PrimusFlex.Web.Common.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using PrimusFlex.Data.Common;
    using PrimusFlex.Data.Models;

    public class ItemData
    {
        private IDbRepository<Item> items;

        public ItemData(IDbRepository<Item> items)
        {
            this.items = items;
        }

        public IEnumerable<SelectListItem> GetAllItemsAsSelectListItems()
        {
            return this.items.All()
                        .OrderBy(i => i.Name)
                        .Select(i => new SelectListItem()
                        {
                            Text = i.Name,
                            Value = i.Id.ToString()
                        })
                        .ToList();
        }
    }
}