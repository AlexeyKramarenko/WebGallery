using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.POCO
{
    public class Picture
    {
        [Key]
        public int PictureID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public string ThumbnailImagePath { get; set; }

        public int GalleryID { get; set; }
        [ForeignKey("GalleryID")]
        public virtual GalleryType GalleryType { get; set; }

    }
}
