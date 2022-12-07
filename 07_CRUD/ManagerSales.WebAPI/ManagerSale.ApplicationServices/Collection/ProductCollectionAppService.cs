using ManagerSale.Core.CollectionFK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSale.ApplicationServices.Collection
{
    public class ProductCollectionAppService: IProductCollectionAppService
    {
        private IHttpClientFactory _clientFactory;
        public ProductCollectionAppService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<ManagerSale.Core.CollectionFK.Product> GetProduct(int id)
        {
            HttpClient client = _clientFactory.CreateClient("product");

            HttpResponseMessage response;
            string url = "products";

            response = await client.GetAsync($"{url}/{id}");

            ManagerSale.Core.CollectionFK.Product product;

            if (response.IsSuccessStatusCode)
            {
                product = Newtonsoft.Json.JsonConvert.DeserializeObject<ManagerSale.Core.CollectionFK.Product>(await response.Content.ReadAsStringAsync());
                return product;
            }
            else
            {
                return null;
            }
        }
    }
}
