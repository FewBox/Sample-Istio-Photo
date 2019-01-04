using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sample_Istio_Photo.Dtos;
using Sample_Istio_Photo.Repositories;

namespace Sample_Istio_Photo.Controllers
{
    /// <summary>
    /// Reviews controller.
    /// </summary> 
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private IReviewRepository ReviewRepository{ get; set; }
        private IMapper Mapper { get; set; }

        public ReviewsController(IMapper mapper, IReviewRepository reviewRepository)
        {
            this.Mapper = mapper;
            this.ReviewRepository = reviewRepository;
        }

        /// <summary>
        /// Get all reviews.
        /// </summary> 
        [HttpGet]
        public async Task<IList<ReviewDto>> Get()
        {
            return await this.Mapper.Map<Task<IList<Review>>, Task<IList<ReviewDto>>>(this.ReviewRepository.FindAll());
        }
    }
}