using ManagerSale.Core.CollectionFK;
using ManagerSale.Sales.Dto;
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

        public async Task<ProdDto> GetProduct(int id)
        {
            HttpClient client = _clientFactory.CreateClient("product");

            HttpResponseMessage response;
            string url = "products";

            response = await client.GetAsync($"{url}/{id}");

            ProdDto productDto;

            if (response.IsSuccessStatusCode)
            {
                productDto = Newtonsoft.Json.JsonConvert.DeserializeObject<ProdDto>(await response.Content.ReadAsStringAsync());
                return productDto;
            }
            else
            {
                return null;
            }
        }
    }
}
