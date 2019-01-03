using System.Collections.Generic;
using Sample_Istio_Photo.Configs;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sample_Istio_Photo.Repositories
{
    public class UnsplashRepository : IUnsplashRepository
    {
        private UnsplashApiConfig UnsplashApiConfig{ get; set; }

        public UnsplashRepository(UnsplashApiConfig unsplashApiConfig)
        {
            this.UnsplashApiConfig = unsplashApiConfig;
        }
        public async Task<IList<Photo>> FindAll()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{this.UnsplashApiConfig.BaseUrl}/photos/?client_id={this.UnsplashApiConfig.AccessKey}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<IList<Photo>>();
            }
        }
    }
}