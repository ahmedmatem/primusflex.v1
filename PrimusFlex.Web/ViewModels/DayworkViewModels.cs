using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PrimusFlex.Data.Models;

namespace PrimusFlex.Web.ViewModels
{
    public class DayworkViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Note { get; set; }

        public string Description { get; set; }

        [Display(Name = "Company")]
        public CompanyType CompanyType { get; set; }

        [Display(Name = "Site name")]
        public string SiteName { get; set; }

        public int SiteId { get; set; }
    }

    public class DayworkCreateViewModel
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public string Note { get; set; }

        public string Description { get; set; }

        [Display(Name = "Company")]
        public CompanyType CompanyType { get; set; }

        [Display(Name = "Site name")]
        public int SiteId { get; set; }

        public IEnumerable<SelectListItem> SiteNames { get; set; }
    }

    public class DayworkEditViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Note { get; set; }

        public string Description { get; set; }

        [Display(Name = "Company")]
        public CompanyType CompanyType { get; set; }

        [Display(Name = "Site name")]
        public int SiteId { get; set; }

        public string SiteName { get; set; }

        public IEnumerable<SelectListItem> SiteNames { get; set; }
    }
}