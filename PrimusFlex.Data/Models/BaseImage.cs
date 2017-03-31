namespace PrimusFlex.Data.Models
{
    using PrimusFlex.Data.Common;

    public abstract class BaseImage : BaseModel<int>
    {
        public string Url { get; set; }
    }
}
