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
        // GET api/values
        [HttpGet]
        public async Task<IList<PhotoDto>> Get()
        {
            return await this.Mapper.Map<Task<IList<Photo>>, Task<IList<PhotoDto>>>(this.UnsplashRepository.FindAll());
        }
    }
}