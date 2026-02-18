using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedisoftCore.Entities
{
    public partial class Faservicio
    {
        public string CTCLMACODI { get; set; }      // Character(2)
        public string FACLSECODI { get; set; }      // Character(2)
        public string FASUBCLCODI { get; set; }     // Character(2)
        public string FASERVCODI { get; set; }      // Character(8)
        public string FASERVNOMB { get; set; }      // Character(254)
        public int? FASERVPROG { get; set; }        // Numeric(1)
        public int? FASERVCONS { get; set; }        // Numeric(1)
        public int? FASERVPART { get; set; }        // Numeric(1)
        public string FAFISECODI { get; set; }      // Character(1)
        public int? FASERVTIPO { get; set; }        // Numeric(1)
        public int? FASERVOBS { get; set; }         // Numeric(1)
        public int? FASERVPAQU { get; set; }        // Numeric(1)
        public string FAAGSECODI { get; set; }      // Character(2)
        public int? FASERVDUCI { get; set; }        // Numeric(2)
        public string FASERVADICI { get; set; }     // Character(1)
        public int? FASERVPRIV { get; set; }        // Numeric(1)
        public bool? FASERVINTE { get; set; }       // Logical(1)
        public int? FASERVENFE { get; set; }        // Numeric(1)
        public int? FASERVFREC { get; set; }        // Numeric(1)
        public int? FASERVTRAN { get; set; }        // Numeric(1)
        public int? FAESVAC { get; set; }           // Numeric(1)
        public int? FASERVTRAP { get; set; }        // Numeric(1)
        public int? FASERVTRAS { get; set; }        // Numeric(1)
        public int? FASERVRX { get; set; }          // Numeric(1)
        public int? FAESTERAPI { get; set; }        // Numeric(1)
        public string FASERVESTA { get; set; }      // Character(1)
        public int? FASERV2175 { get; set; }        // Numeric(1)
        public int? FAINCAPCID { get; set; }        // Numeric(1)
    }


}
