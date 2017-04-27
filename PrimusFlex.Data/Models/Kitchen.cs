namespace PrimusFlex.Data.Models
{
    using System.Collections.Generic;

    public class Kitchen  : Record
    {
        public Kitchen()
        {
            this.MorDItems = new HashSet<MorDItem>();
            this.KitchenImages = new HashSet<KitchenImage>();
        }

        public string PlotNumber { get; set; }

        public WorktopShape WorktopShape { get; set; }

        // Navigation properties

        public virtual ICollection<MorDItem> MorDItems { get; set; }

        public virtual ICollection<KitchenImage> KitchenImages { get; set; }
    }
}
