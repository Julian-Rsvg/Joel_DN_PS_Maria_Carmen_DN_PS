using System.ComponentModel.DataAnnotations;

namespace ManagerCollection.WebAPI.Models
{
    public class ProductModel
    {
        //public int Id { get; set; }
        [Required]        
        
        public string Name { get; set; }

        public int BrandId { get; set; }

        public int CategoryId{ get; set; }
    }
}
