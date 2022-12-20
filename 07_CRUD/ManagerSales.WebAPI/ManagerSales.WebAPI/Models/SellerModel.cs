using System.ComponentModel.DataAnnotations;

namespace ManagerSale.WebAPI.Models
{
    public class SellerModel
    {
        //public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
