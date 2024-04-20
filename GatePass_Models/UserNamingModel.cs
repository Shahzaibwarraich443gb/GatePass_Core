using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatePass_Models
{
    public class UserNamingModel
    {
        [Key]
        public int Id { get; set; }
        public string userId { get; set; }
        public string fullName { get; set; }
    }
}
