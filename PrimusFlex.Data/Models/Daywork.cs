namespace PrimusFlex.Data.Models
{
    using System.Collections.Generic;

    public class Daywork : Record
    {
        public Daywork()
        {
            this.DayworkImages = new HashSet<DayworkImage>();
        }

        public string Description { get; set; }

        // Navigation properties

        public virtual ICollection<DayworkImage> DayworkImages { get; set; }
    }
}
