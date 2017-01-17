using System.Collections.Generic;
using Repository.POCO;

namespace Repository.DAL.Interfaces
{
    public interface IImagesRepository
    {
        void DeletePicture(Picture pic);
        Picture GetPicture(int pictureId);
        IEnumerable<Picture> GetPicturesByGalleryID(int? galleryID);
        void InsertPicture(Picture pic);
        void UpdatePicture(Picture pic);
        List<GalleryType> GetGalleryTypes();
    }
}