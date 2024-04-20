using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatePass_Models
{

    public class ItemsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int itemId { get; set; }

        [ForeignKey("InwardGatePassModelGatePassId")]
        public int InwardGatePassModelGatePassId { get; set; }
        public string itemName { get; set; }
        public int quantity { get; set; }
        public string? additionalSpecs { get; set; }
    }
    public class InwardGatePassModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GatePassId { get; set; }

        public string GatePassCode { get; set; }
        public int vehicleType { get; set; }
        [NotMapped]
        public string? vehicleTypeName { get; set; }
        public string vehicleMake { get; set; }
        public string licensePlateNo { get; set; }
        public string driverName { get; set; }
        public string department { get; set; }
        public string? partyName { get; set; }
        public DateTime addedOn { get; set; } = DateTime.Now.ToUniversalTime();
        public string addedBy { get; set; }
        [NotMapped]
        public string addedByName { get; set; }
        public List<ItemsModel>? itemDetails { get; set; }
    }

    public class InwardGatePassById
    {
        public int? GatePassId { get; set; }
        public int? GatePassCode { get; set; }
    }
}
