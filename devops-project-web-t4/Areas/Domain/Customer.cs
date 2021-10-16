using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace devops_project_web_t4.Areas.Domain
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Firstname {get;set;}
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string BTW { get; set; }
        public string Tel { get; set; }
    }
}
