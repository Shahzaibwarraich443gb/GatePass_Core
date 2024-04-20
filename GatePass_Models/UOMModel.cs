using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatePass_Models
{
    public class UOMModel
    {
        [Key]
        public int unitId { get; set; }

        public string unitName { get; set; }
    }
}
