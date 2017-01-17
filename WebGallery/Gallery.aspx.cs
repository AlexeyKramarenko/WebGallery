using Ninject;
using Repository.DAL.Interfaces;
using Repository.POCO;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.ModelBinding;
using System.Web.UI.WebControls;
using WebGallery.ViewModel;

namespace WebGallery
{
    public partial class Gallery : System.Web.UI.Page
    {
        [Inject]
        public IUnitOfWork Database { get; set; }

        [Inject]
        public IMappingService MappingService { get; set; }


        public List<GalleryPictureViewModel> GetPictures([RouteData] int? galleryId)
        {
            galleryId = (galleryId == null) ? 1 : galleryId;
            List<Picture> pics = Database.Images.GetPicturesByGalleryID(galleryId).ToList();
            List<GalleryPictureViewModel> picsVM = pics.Select(a => MappingService.Map<Picture, GalleryPictureViewModel>(a)).ToList();
            return picsVM;
        }


    }
}