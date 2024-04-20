using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatePass_Models
{
    public class VehicleTypeModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int vehicleTypeId { get; set; }
        public string vehicleTypeName { get; set; }
    }

    public class VehicleTypeById
    {
        public int vehicleTypeId { get; set; }
    }
}
