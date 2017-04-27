namespace PrimusFlex.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class SiteViewModel
    {
        public int id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PostCode { get; set; }
    }
}