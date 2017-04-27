namespace PrimusFlex.Data.Models
{
    public class KitchenImage : BaseImage
    {
        public int KitchenId { get; set; }

        // Navigation properties
        
        public virtual Kitchen Kitchen { get; set; }
    }
}
