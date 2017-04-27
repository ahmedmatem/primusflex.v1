namespace PrimusFlex.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using PrimusFlex.Data.Common;

    [Table("MorDItems")]
    public class MorDItem : BaseModel<int>
    {
        public int? Count { get; set; }
        
        public Size Size { get; set; }

        public HandSide? HandSide { get; set; }

        public MorDType MorDType { get; set; }

        public int KitchenId { get; set; }

        public int ItemId { get; set; }

        // Navigation properties

        public virtual Item Item { get; set; }

        public virtual Kitchen Kitchen { get; set; }

    }
}
