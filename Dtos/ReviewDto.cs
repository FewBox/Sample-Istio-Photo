namespace Sample_Istio_Photo.Dtos
{
    /// <summary>
    /// Review Dto.
    /// </summary>
    public class ReviewDto
    {
        /// <summary>
        /// Review Content.
        /// </summary>
        public string Content {get;set;}
        /// <summary>
        /// Review Base64 image star.
        /// </summary>
        public string Base64SvgAvatar { get; set; }
    }
}