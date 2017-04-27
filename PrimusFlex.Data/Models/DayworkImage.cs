using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimusFlex.Data.Models
{
    public class DayworkImage : BaseImage
    {
        public int DayworkId { get; set; }

        // Navigation properties
        
        public virtual Daywork Daywork { get; set; }
    }
}
