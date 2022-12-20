using System.ComponentModel.DataAnnotations;

namespace ManagerCollection.WebAPI.Models
{
    public class CategoryModel
    {
        [Required]
        public string Name { get; set; }
    }
}
