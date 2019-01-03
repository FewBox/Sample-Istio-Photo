using System.Collections.Generic;

namespace Sample_Istio_Photo.Dtos
{
    public class PhotoDto
    {
        public string Id { get; set; }
        public UrlsDto Urls { get; set; }
        public IList<ReviewDto> Reviews { get; set; }
    }
}