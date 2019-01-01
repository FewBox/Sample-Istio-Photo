using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample_Istio_Photo.Dtos;

namespace Sample_Istio_Photo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<ReviewDto>> Get()
        {
            return new List<ReviewDto>{};
        }
    }
}