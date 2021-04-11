using Esourcing.UI.ViewModel;
using ESourcing.Core.Common;
using ESourcing.Core.ResultModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Esourcing.UI.Clients
{
    public class ProductClient
    {
        public HttpClient _client { get; }

        public ProductClient(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri(CommonInfo.BaseAddress);
        }

        public async Task<Result<List<ProductViewModel>>> GetProducts()
        {
            var response = await _client.GetAsync("/Product");
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ProductViewModel>>(responseData);
                if (result.Any())
                    return new Result<List<ProductViewModel>>(true, ResultConstant.RecordFound, result.ToList());
                return new Result<List<ProductViewModel>>(false, ResultConstant.RecordNotFound);
            }
            return new Result<List<ProductViewModel>>(false, ResultConstant.RecordNotFound);
        }
    }
}
