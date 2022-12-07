namespace ManagerCollection.WebAPI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int BrandId { get; set; }

        public int CategoryId{ get; set; }
    }
}
