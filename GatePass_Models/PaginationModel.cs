using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatePass_Models
{
    public class PaginationModel
    {
        public int pageNum { get; set; }
        public int itemsPerPage { get; set; }
        public int? lastId { get; set; }
    }
}
