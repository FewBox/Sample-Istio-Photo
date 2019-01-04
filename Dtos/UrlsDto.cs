namespace Sample_Istio_Photo.Dtos
{
    /// <summary>
    /// Url collection.
    /// </summary>
    public class UrlsDto
    {
        /// <summary>
        /// Raw Url.
        /// </summary>
        public string Raw {get;set;}
        /// <summary>
        /// Full Url.
        /// </summary>        
        public string Full { get; set; }
        /// <summary>
        /// Regular Url.
        /// </summary> 
        public string Regular { get; set; }
        /// <summary>
        /// Small Url.
        /// </summary> 
        public string Small { get; set; }
        /// <summary>
        /// Thumb Url.
        /// </summary> 
        public string Thumb { get; set; }
    }
}