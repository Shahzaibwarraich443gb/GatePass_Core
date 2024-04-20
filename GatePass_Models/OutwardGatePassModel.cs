using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatePass_Models
{
    public class dispatchItems
    {
        [Key]
        public int dispatchItemId { get; set; }


        [ForeignKey("OutwardGatePassModeldispatchId")]
        public int OutwardGatePassModeldispatchId { get; set; }

        public string itemName { get; set; }
        public float quantity { get; set; }
        public float sizeValue { get; set; }
        public int uom { get; set; }

        [NotMapped]
        public string? uomName { get; set; }
        public float productArea { get; set; }
    }
    public class OutwardGatePassModel
    {
        [Key]
        public int dispatchId { get; set; }
        public string dispatchCode { get; set; }
        public string salesOrderNo { get; set; }
        public string hoistingBy { get; set; }
        [NotMapped]
        public string hoistingByName { get; set; }
        public string fromDept { get; set; }
        public string toDept { get; set; }
        public string salesPerson { get; set; }
        public string custName { get; set; }
        public string custAddress { get; set; }
        public string custContactNo { get; set; }
        public float carriage { get; set; }
        public float hoisting { get; set; }
        public float shifting { get; set; }
        public float loading { get; set; }
        public string? deliveryNote { get; set; }
        public DateTime addedOn { get; set; } = DateTime.Now.ToUniversalTime();

        public List<dispatchItems> dispatchItems { get; set; }
    }

    public class getOutwardGatePassById
    {
        public int dispatchId { get; set; }
    }
}
