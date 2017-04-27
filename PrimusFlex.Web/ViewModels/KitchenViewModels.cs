namespace PrimusFlex.Web.ViewModels
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
        [DisplayName("Site name")]
        public string SiteName { get; set; }

        [DisplayName("Plot number")]
        public string PlotNumber { get; set; }

        public string Company { get; set; }

        public string Shape { get; set; }

        [DisplayName("Images")]
        public int ImageCount { get; set; }

        [DisplayName("Missing & Damages")]
        public bool HasMorDItem { get; set; }

        public string Note { get; set; }

        public string invalidKitchenError { get; set; }
    }

    public class KitchenCreateViewModel
    {
        [Required]
        public string Date { get; set; }

        [DisplayName("Site name")]
        public int SiteId { get; set; }

        public IEnumerable<SelectListItem> SiteNames { get; set; }

        [Required]
        [DisplayName("Plot number")]
        public string PlotNumber { get; set; }

        [Required]
        public CompanyType Company { get; set; }

        [Required]
        [DisplayName("Shape")]
        public WorktopShape Shape { get; set; }

        public string Note { get; set; }
    }

    public class KitchenEditViewModel
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [DisplayName("Site name")]
        public int SiteId { get; set; }

        public string SiteName { get; set; }

        public IEnumerable<SelectListItem> SiteNames { get; set; }

        [Required]
        [DisplayName("Plot number")]
        public string PlotNumber { get; set; }

        [Required]
        public CompanyType Company { get; set; }

        [Required]
        [DisplayName("Shape")]
        public WorktopShape Shape { get; set; }

        public string Note { get; set; }
    }

}