namespace PrimusFlex.WebApi.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using PrimusFlex.Data.Models;

    public class KitchenViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public string SiteName { get; set; }
        
        public string PlotNumber { get; set; }

        public string Company { get; set; }

        public string Shape { get; set; }
        
        public int ImageCount { get; set; }
        
        public bool HasMorDItem { get; set; }

        public string Note { get; set; }

        public string invalidKitchenError { get; set; }
    }

    public class KitchenCreateViewModel
    {
        [Required]
        public string Date { get; set; }
        
        public int SiteId { get; set; }

        public IEnumerable<SelectListItem> SiteNames { get; set; }

        [Required]
        public string PlotNumber { get; set; }

        [Required]
        public CompanyType Company { get; set; }

        [Required]
        public WorktopShape Shape { get; set; }

        public string Note { get; set; }
    }

    public class KitchenEditViewModel
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }
        
        public int SiteId { get; set; }

        public string SiteName { get; set; }

        public IEnumerable<SelectListItem> SiteNames { get; set; }

        [Required]
        public string PlotNumber { get; set; }

        [Required]
        public CompanyType Company { get; set; }

        [Required]
        public WorktopShape Shape { get; set; }

        public string Note { get; set; }
    }

}