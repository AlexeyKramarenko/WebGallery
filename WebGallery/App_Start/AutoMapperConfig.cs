using AutoMapper;
using Repository.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebGallery.ViewModel;

namespace WebGallery.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<CreatePictureViewModel, Picture>()
                .ForMember("Name", opt => opt.MapFrom(a => a.Name))
                .ForMember("Description", opt => opt.MapFrom(a => a.Description))
                .ForMember("GalleryID", opt => opt.MapFrom(a => a.GalleryID));

            Mapper.CreateMap<Picture, PictureViewModel>();
            Mapper.CreateMap<Picture, GalleryPictureViewModel>();
        }
    }
}
