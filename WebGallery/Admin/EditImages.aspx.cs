using Ninject;
using Repository.DAL.Interfaces;
using Repository.POCO;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.ModelBinding;
using System.Web.UI.WebControls;
using WebGallery.ViewModel;

namespace WebGallery.Admin
{
    public partial class EditImages : System.Web.UI.Page
    {
        [Inject]
        public IUnitOfWork DataBase { get; set; }
        [Inject]
        public IMappingService MappingService { get; set; }

        public IEnumerable<PictureViewModel> GetAllPictures([QueryString] int galleryId)
        {
            List<Picture> pictures = DataBase.Images.GetPicturesByGalleryID(galleryId).ToList();
            List<PictureViewModel> picturesVM = pictures.Select(a => MappingService.Map<Picture, PictureViewModel>(a)).ToList();
            return picturesVM;
        }

        protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            if (GridView1.SelectedDataKey != null)
            {
                int PictureID = (int)GridView1.SelectedDataKey.Value;

                Picture pic = DataBase.Images.GetPicture(PictureID);

                if (pic != null)
                {
                    pic.Description = (e.NewValues["Description"] ?? "").ToString();
                    pic.Name = (e.NewValues["Name"] ?? "").ToString();

                    DataBase.Images.UpdatePicture(pic);
                    DataBase.Save();

                    GridView1.SelectedIndex = -1;
                    GridView1.DataBind();
                    DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
                    DetailsView1.Visible = false;
                }

            }
        }
        protected void DetailsView1_ItemDeleting(object sender, DetailsViewDeleteEventArgs e)
        {
            if (GridView1.SelectedDataKey != null)
            {
                int PictureID = (int)GridView1.SelectedDataKey.Value;

                Picture pic = DataBase.Images.GetPicture(PictureID);

                if (pic != null)
                {
                    var files = new string[] {
                        pic.ImagePath,
                        pic.ThumbnailImagePath
                    };

                    DeleteFiles(files);

                    DataBase.Images.DeletePicture(pic);
                    DataBase.Save();

                    GridView1.SelectedIndex = -1;
                    GridView1.DataBind();
                    DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
                    DetailsView1.Visible = false;
                }

            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DetailsView1.Visible = true;
            DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
            ShowItemInDetailsView();
        }

        protected void DetailsView1_ModeChanging(object sender, DetailsViewModeEventArgs e)
        {
            DetailsView1.ChangeMode(e.NewMode);

            if (e.NewMode == DetailsViewMode.Edit)
            {
                ShowItemInDetailsView();
            }
            if (e.CancelingEdit)
            {
                DetailsView1.ChangeMode(DetailsViewMode.ReadOnly);
                ShowItemInDetailsView();
            }
        }

        public void ShowItemInDetailsView()
        {
            int PictureID = (int)GridView1.SelectedDataKey.Value;
            Picture pic = DataBase.Images.GetPicture(PictureID);
            PictureViewModel pictureVM = MappingService.Map<Picture, PictureViewModel>(pic);
            DetailsView1.DataSource = new PictureViewModel[] { pictureVM };
            DetailsView1.DataBind();
        }

        public void DeleteFiles(string[] filePaths)
        {
            for (int i = 0; i < filePaths.Length; i++)
            {
                string path = Server.MapPath(filePaths[i]);

                if (File.Exists(path))
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    File.Delete(path);
                }
            }
        }



    }
}