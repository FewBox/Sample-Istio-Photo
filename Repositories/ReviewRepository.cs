using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FewBox.Core.Web.Dto;
using Microsoft.AspNetCore.Http;
using Sample_Istio_Photo.Configs;

namespace Sample_Istio_Photo.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private ReviewApiConfig ReviewApiConfig { get; set; }
        private IHttpContextAccessor HttpContextAccessor { get; set; }

        public ReviewRepository(ReviewApiConfig reviewApiConfig, IHttpContextAccessor httpContextAccessor)
        {
            this.ReviewApiConfig = reviewApiConfig;
            this.HttpContextAccessor = httpContextAccessor;
        }

        public async Task<IList<Review>> FindAll()
        {
            // return new List<Review> { new Review { Content = "Review1" }, new Review{ Content = "Review2" } };
            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(3);
                foreach(var header in this.HttpContextAccessor.HttpContext.Request.Headers)
                {
                    if(header.Key == "EndUser")
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value.ToString());
                    }
                    Console.WriteLine(header.Value.ToString());
                }
                PayloadMetaResponseDto<IList<Review>> responseData;
                try
                {
                    var response = await client.GetAsync($"{this.ReviewApiConfig.BaseUrl}/api/reviews");
                    response.EnsureSuccessStatusCode();
                    responseData = await response.Content.ReadAsAsync<PayloadMetaResponseDto<IList<Review>>>();
                    if(responseData.IsSuccessful)
                    {
                        return responseData.Payload;
                    }
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
