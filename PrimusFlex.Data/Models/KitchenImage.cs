namespace PrimusFlex.Data.Models
{
    public class KitchenImage : BaseImage
    {
        public string PublicId { get; set; }

        public string ResourceType { get; set; }

        public string ETag { get; set; }

        public string Signature { get; set; }

        public string SecureUrl { get; set; }

        public string Version { get; set; }

        public int KitchenId { get; set; }

        // Navigation properties

        public virtual Kitchen Kitchen { get; set; }
    }
}
