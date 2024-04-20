using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatePass_Models
{
    public class UserCompanyModel
    {
        [Key]
        public int UserCompanyId { get; set; }
        public int CompanyId { get; set;}
        public string userId { get; set; }
    }
}
