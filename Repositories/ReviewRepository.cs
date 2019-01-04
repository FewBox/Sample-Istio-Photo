using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Sample_Istio_Photo.Configs;

namespace Sample_Istio_Photo.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private ReviewApiConfig ReviewApiConfig { get; set; }

        public ReviewRepository(ReviewApiConfig reviewApiConfig)
        {
            this.ReviewApiConfig = reviewApiConfig;
        }

        public async Task<IList<Review>> FindAll()
        {
            return new List<Review> { new Review { Content = "Review1" }, new Review{ Content = "Review2" } };
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{this.ReviewApiConfig.BaseUrl}/reviews");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<IList<Review>>();
            }
        }
    }
}