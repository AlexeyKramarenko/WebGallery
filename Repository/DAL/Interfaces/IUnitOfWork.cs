using Repository.DAL.Interfaces;
using Repository.Interfaces;

namespace Repository.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IImagesRepository Images { get; }
        IUserRepository Users { get; }

        void Dispose();
        void Dispose(bool disposing);
        int Save();
    }
}