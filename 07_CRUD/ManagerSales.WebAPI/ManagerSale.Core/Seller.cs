using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSale.Core
{
    public class Seller
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(30)]
        public string Password { get; set; }

        public List<SaleProduct> Sales { get; set; }

        public Seller()
        {
            Sales = new List<SaleProduct>();
        }
    }
}
