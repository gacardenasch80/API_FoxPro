using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedisoftCore.Entities
{
    public partial class Consecutivos
    {
        public string Tabla { get; set; }
        public decimal? Numero { get; set; }
        public string Año { get; set; }
        public string Comentario { get; set; }
    }
}
