using Repository.DAL.Interfaces;
using Repository.POCO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DAL
{
    public class ImagesRepository : IImagesRepository
    {
        DBContext db;
        public ImagesRepository(DBContext db)
        {
            this.db = db;
        }

        public void InsertPicture(Picture pic)
        {
            db.Entry(pic).State = System.Data.Entity.EntityState.Added;
        }
        public Picture GetPicture(int pictureId)
        {
            return db.Pictures.Find(pictureId);
        }
        public void UpdatePicture(Picture pic)
        {
            db.Entry(pic).State = System.Data.Entity.EntityState.Modified;
        }

        public void DeletePicture(Picture pic)
        {
            db.Entry(pic).State = System.Data.Entity.EntityState.Deleted;
        }

        public IEnumerable<Picture> GetPicturesByGalleryID(int? galleryID)
        {
            return db.Pictures.Where(a => a.GalleryID == galleryID)
                              .OrderByDescending(a => a.PictureID);
        }
        public List<GalleryType> GetGalleryTypes()
        {
            return db.GalleryTypes.ToList();
        }
    }
}
