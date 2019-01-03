using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Sample_Istio_Photo.Dtos;
using Sample_Istio_Photo.Repositories;

namespace Sample_Istio_Photo.AutoMapperProfiles
{
    public class ReviewConverter : IMemberValueResolver<Photo, PhotoDto, string, IList<ReviewDto>>
    {
        private IMapper Mapper { get; set; }
        private IReviewRepository ReviewRepository { get; set; }
        public ReviewConverter(IMapper mapper, IReviewRepository reviewRepository)
        {
            this.Mapper = mapper;
            this.ReviewRepository = reviewRepository;
        }

        public IList<ReviewDto> Resolve(Photo source, PhotoDto destination, string sourceMember, IList<ReviewDto> destMember, ResolutionContext context)
        {
            return this.Mapper.Map<IList<Review>, IList<ReviewDto>>(this.ReviewRepository.FindAll().Result);
        }
    }
}