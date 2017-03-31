namespace PrimusFlex.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MorDItems")]
    public class MorDItem : Item
    {
        public int Count { get; set; }

        public Site Size { get; set; }

        public HandSide HandSide { get; set; }

        public MorDType MorDType { get; set; }

        public int KitchenId { get; set; }

        public int ItemId { get; set; }

        // Navigation properties

        public virtual Item Item { get; set; }

        public virtual KitchenRecord Kitchen { get; set; }

    }
}
