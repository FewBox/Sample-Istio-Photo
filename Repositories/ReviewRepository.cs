using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FewBox.Core.Web.Dto;
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
            // return new List<Review> { new Review { Content = "Review1" }, new Review{ Content = "Review2" } };
            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(3);
                PayloadMetaResponseDto<IList<Review>> responseData;
                try
                {
                    var response = await client.GetAsync($"{this.ReviewApiConfig.BaseUrl}/reviews");
                    response.EnsureSuccessStatusCode();
                    responseData = await response.Content.ReadAsAsync<PayloadMetaResponseDto<IList<Review>>>();
                    if(responseData.IsSuccessful)
                    {
                        return responseData.Payload;
                    }
                }
                catch(Exception exception)
                {
                    Console.WriteLine($"{exception.Message}:{exception.StackTrace}");
                }
                return null;
            }
        }
    }
}