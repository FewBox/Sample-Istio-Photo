using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Sample_Istio_Photo.Dtos;
using Sample_Istio_Photo.Repositories;
using FewBox.Core.Web.Dto;

namespace Sample_Istio_Photo.Controllers
{
    /// <summary>
    /// Photos controller.
    /// </summary> 
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private IUnsplashRepository UnsplashRepository{ get; set; }
        private IMapper Mapper { get; set; }
        
        public PhotosController(IMapper mapper, IUnsplashRepository unsplashRepository)
        {
            this.Mapper = mapper;
            this.UnsplashRepository = unsplashRepository;
        }
        /// <summary>
        /// Get all photos.
        /// </summary> 
        [HttpGet]
        //[ResponseCache(VaryByHeader = "User-Agent", Duration = 60)]
        public async Task<PayloadMetaResponseDto<IList<PhotoDto>>> Get()
        {
            var photos = await this.Mapper.Map<Task<IList<Photo>>, Task<IList<PhotoDto>>>(this.UnsplashRepository.FindAll());
            return new PayloadMetaResponseDto<IList<PhotoDto>>
            {
                Payload = photos
            };
        }
    }
}