using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedisoftCore.QueryFilters
{
    public class AddispmedQueryFilter
    {
        public string Addispcons { get; set; }
        public string Geespecodi { get; set; }
        public string Gemedicodi { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
    }
}
