using ProductDTOClass;
namespace ProductApp.Models
{
    public class ProductApiController
    {
        private string httpConnect = "https://localhost:7245/api/";
        private HttpClient mClient;

        //initializer
        public ProductApiController()
        {
            mClient = new HttpClient();
            mClient.BaseAddress = new Uri(httpConnect);
            mClient.DefaultRequestHeaders.Add("Accept", "application/json");
            mClient.DefaultRequestHeaders.Add("User-Agent", "ProductApp");
        }
        
        public async Task<List<ProductDTO>> GetProducts()
        {
            List<ProductDTO> productItems = new List<ProductDTO>();
            var response = await mClient.GetAsync("ProductItems");
            if (response.IsSuccessStatusCode)
            {
                var read = response.Content.ReadFromJsonAsync<List<ProductDTO>>();
                read.Wait();
                if (read.Result != null)
                {
                    productItems = read.Result;
                }
                else
                {
                    productItems = new List<ProductDTO>();
                }
            }
            return productItems;
        }

        public async Task<ProductDTO> GetProduct(long? id)
        {
            ProductDTO productItem = new ProductDTO();
            var response = await mClient.GetAsync("ProductItems/" + id);
            if (response.IsSuccessStatusCode)
            {
                var read = response.Content.ReadFromJsonAsync<ProductDTO>();
                read.Wait();
                if (read.Result != null)
                {
                    productItem = read.Result;
                }
                else
                {
                    productItem = new ProductDTO();
                }
            }
            return productItem;
        }

        public async Task<bool> PostProductItem(ProductDTO productItem)
        {
            var response = await mClient.PostAsJsonAsync("ProductItems", productItem);
            if (response.IsSuccessStatusCode)
            {
                var read = response.Content.ReadFromJsonAsync<ProductDTO>();
                read.Wait();
                if (read.Result != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> PutProductItem(long id, ProductDTO productItem)
        {
            var response = await mClient.PutAsJsonAsync("ProductItems/" + id, productItem);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteProductItem(long id)
        {
            var response = await mClient.DeleteAsync("ProductItems/" + id);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

    }
}
