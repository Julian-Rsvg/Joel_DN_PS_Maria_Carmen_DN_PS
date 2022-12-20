using System.ComponentModel.DataAnnotations;

namespace ManagerCollection.WebAPI.Models
{
    public class BrandModel
    {
        [Required()]
        [StringLength(80)]
        public string Name { get; set; }
    }
}
