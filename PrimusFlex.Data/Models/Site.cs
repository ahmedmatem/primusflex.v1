﻿namespace PrimusFlex.Data.Models
{
    using PrimusFlex.Data.Common;
    using System.Collections.Generic;

    public class Site : BaseModel<int>
    {
        public Site()
        {
            this.Kitchens = new HashSet<Kitchen>();
        }

        public string PostCode { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        // Navigation properties

        public virtual ICollection<Kitchen> Kitchens { get; set; }

    }
}
