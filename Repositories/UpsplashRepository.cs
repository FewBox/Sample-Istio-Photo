using System;
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
                try
                {
                    client.Timeout = TimeSpan.FromSeconds(30);
                    string url = $"{this.UnsplashApiConfig.BaseUrl}/photos/?client_id={this.UnsplashApiConfig.AccessKey}";
                    Console.WriteLine(url);
                    var response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsAsync<IList<Photo>>();
                }
                catch(Exception exception)
                {
                    Console.WriteLine($"{exception.Message}");
                }
                return null;
            }
        }
    }
}