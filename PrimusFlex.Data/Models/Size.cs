namespace PrimusFlex.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [ComplexType]
    public class Size
    {
        [Column("Width")]
        public string Width { get; set; }

        [Column("Height")]
        public string Height { get; set; }
    }
}
