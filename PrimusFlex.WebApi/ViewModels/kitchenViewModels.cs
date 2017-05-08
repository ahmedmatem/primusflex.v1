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

        public string SiteAddress { get; set; }

        public string PlotNumber { get; set; }

        public string Company { get; set; }

        public string Shape { get; set; }
        
        public int ImageCount { get; set; }
        
        public bool HasMorDItem { get; set; }

        public string Note { get; set; }

        public string invalidKitchenError { get; set; }
    }

    public class MorDItemViewModel
    {
        public int MorDItemId { get; set; }

        public int? Count { get; set; }

        public Size Size { get; set; }

        public HandSide? HandSide { get; set; }

        public MorDType MorDType { get; set; }
    }

    public class KitchenDetailsViewModel : KitchenViewModel
    {
        public ICollection<MorDItemViewModel> MorDItems { get; set; }
    }

}