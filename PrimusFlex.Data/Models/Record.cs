namespace PrimusFlex.Data.Models
{
    using System;

    using PrimusFlex.Data.Common;

    public abstract class Record : BaseModel<int>
    {
        public DateTime Date { get; set; }

        public string Note { get; set; }

        public CompanyType CompanyType { get; set; }

        public string FitterId { get; set; }

        public int SiteId { get; set; }

        // Navigation properties

        public virtual ApplicationUser Fitter { get; set; }

        public virtual Site Site { get; set; }
    }
}
