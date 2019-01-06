using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Sample_Istio_Photo.Dtos;
using Sample_Istio_Photo.Repositories;

namespace Sample_Istio_Photo.AutoMapperProfiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Photo, PhotoDto>()
                .ForMember(dest => dest.Reviews, opt => opt.MapFrom<ReviewConverter, string>(src=>src.Id));
            CreateMap<Task<IList<Photo>>, Task<IList<PhotoDto>>>();
            CreateMap<Urls, UrlsDto>();
        }
    }
}