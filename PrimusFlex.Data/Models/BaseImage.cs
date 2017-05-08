namespace PrimusFlex.Data.Models
{
    using PrimusFlex.Data.Common;

    public abstract class BaseImage : BaseModel<int>
    {
        public string Url { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public string Format { get; set; }
    }
}
