namespace PrimusFlex.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using PrimusFlex.Data.Models;

    public class MorDItemViewModel
    {
        public int Id { get; set; }

        public int? Count { get; set; }

        public string Width { get; set; }

        public string Height { get; set; }

        [Display(Name = "Hand side")]
        public HandSide? HandSide { get; set; }
        
        [Display(Name = "Type")]
        public MorDType MorDType { get; set; }

        [Required]
        [Display(Name = "Item" )]
        public int ItemId { get; set; }

        public Item Item { get; set; }

        public int KitchenId { get; set; }
    }

    public class KitchenWithMorDItemViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Site name")]
        public string SiteName { get; set; }

        [Display(Name = "Plot number")]
        public string PlotNumber { get; set; }

        public DateTime Date { get; set; }

        public CompanyType Company { get; set; }
    }
}