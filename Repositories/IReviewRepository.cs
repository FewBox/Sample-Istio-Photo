using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample_Istio_Photo.Repositories
{
    public interface IReviewRepository
    {
        Task<IList<Review>> FindAll();
    }
}