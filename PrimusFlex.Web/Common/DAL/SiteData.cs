namespace PrimusFlex.Web.Common.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using PrimusFlex.Data.Common;
    using PrimusFlex.Data.Models;

    public class SiteData
    {
        private IDbRepository<Site> sites;

        public SiteData(IDbRepository<Site> sites)
        {
            this.sites = sites;
        }

        public IEnumerable<SelectListItem> GetAllSitesAsSelectListItems()
        {
            return sites.All()
                        .OrderByDescending(s => s.Name)
                        .Select(s => new SelectListItem()
                        {
                            Text = s.Name,
                            Value = s.Id.ToString()
                        })
                        .ToList();
        }

        public IEnumerable<SelectListItem> GetAllSitesAsSelectListItems(string selectedItem)
        {
            return sites.All()
                        .OrderByDescending(s => s.Name)
                        .Select(s => new SelectListItem()
                        {
                            Text = s.Name,
                            Value = s.Id.ToString(),
                            Selected = (s.Id.ToString().Equals(selectedItem))
                        })
                        .ToList();
        }
    }
}