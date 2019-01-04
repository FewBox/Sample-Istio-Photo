using System.Collections.Generic;

namespace Sample_Istio_Photo.Dtos
{
    /// <summary>
    /// Photo Dto.
    /// </summary> 
    public class PhotoDto
    {
        /// <summary>
        /// Id.
        /// </summary> 
        public string Id { get; set; }
        /// <summary>
        /// Url.
        /// </summary> 
        public UrlsDto Urls { get; set; }
        /// <summary>
        /// Reviews.
        /// </summary> 
        public IList<ReviewDto> Reviews { get; set; }
    }
}