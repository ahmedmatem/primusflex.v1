namespace PrimusFlex.Data.Models
{
    public class Image : BaseImage
    {
        public int KitchenId { get; set; }

        public int DayworkId { get; set; }

        // Navigation properties

        public virtual KitchenRecord Kitchen { get; set; }

        public virtual DayworkRecord Daywork { get; set; }
    }
}
