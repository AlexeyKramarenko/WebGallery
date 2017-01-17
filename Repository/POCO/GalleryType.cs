using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.POCO
{
    public  class GalleryType
    {
        [Key]
        public int GalleryID { get; set; }
        public string GalleryName { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
