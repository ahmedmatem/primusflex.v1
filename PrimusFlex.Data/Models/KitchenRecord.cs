namespace PrimusFlex.Data.Models
{
    using System.Collections.Generic;

    public class KitchenRecord  : Record
    {
        public KitchenRecord()
        {
            this.MorDItems = new HashSet<MorDItem>();
        }

        public string PlotNumber { get; set; }

        public WorktopShape WorktopShape { get; set; }

        // Navigation properties

        public virtual ICollection<MorDItem> MorDItems { get; set; }
    }
}
