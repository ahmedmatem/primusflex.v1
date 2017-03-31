namespace PrimusFlex.Data.Models
{
    using PrimusFlex.Data.Common;

    public abstract class BaseItem : BaseModel<int>
    {
        public string Name { get; set; }
    }
}
