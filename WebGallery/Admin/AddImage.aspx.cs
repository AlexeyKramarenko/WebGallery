using Ninject;
using Repository.DAL.Interfaces;
using Repository.POCO;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using WebGallery.ViewModel;
using Services.Interfaces;
using System.Drawing.Imaging;

namespace WebGallery.Admin
{
    public partial class AddImage : System.Web.UI.Page
    {
        [Inject]
        public IUnitOfWork DataBase { get; set; }
        [Inject]
        public IMappingService MappingService { get; set; }
        [Inject]
        public IPathService PathService { get; set; }

        public FileUpload FileUpload
        {
            get
            {
                return createPictureFormView.FindControl("fileUpload") as FileUpload;
            }
        }
        public int PostedFileLength
        {
            get
            {
                postedFileLength = FileUpload.PostedFile.ContentLength;
                return postedFileLength;
            }
        }

        int postedFileLength;

        public string Result = null;

        int MaxTargetLength = 300000;
        int MaxHostingFolderSize = 90000000;

        string relativeThumbPath = "~/Images/gallery/thumbs/";
        string relativeLargeImagePath = "~/Images/gallery/largeImages/";
        string[] formats = new string[] { "image/jpeg", "image/png", "image/bmp" };

        public CreatePictureViewModel InitPictureForm()
        {
            var model = new CreatePictureViewModel();
            model.GalleryTypes = DataBase.Images.GetGalleryTypes();
            model.GalleryID = 1;
            return model;
        }
        public void InsertImage(CreatePictureViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (FileUpload.HasFile)
                {
                    if (formats.Contains(FileUpload.PostedFile.ContentType))
                    {
                        try
                        {
                            string largeFileName = Guid.NewGuid().ToString() + "_" + FileUpload.FileName;
                            string thumbFileName = "thumb_" + largeFileName;
                            string largeImagePath = PathService.MapPath(relativeLargeImagePath) + largeFileName;
                            string thumbPath = PathService.MapPath(relativeThumbPath) + thumbFileName;
                            int uploadedFileLength = PostedFileLength;

                            FileUpload.SaveAs(largeImagePath);
                            ReleaseResources(FileUpload);

                            if (uploadedFileLength > MaxTargetLength)
                            {
                                largeFileName = "changed_" + largeFileName;

                                string pathForReducedImage = PathService.MapPath(relativeLargeImagePath) + largeFileName;
                                ReduceImageByteSize(postedFileLength, MaxTargetLength, largeImagePath, pathForReducedImage);

                                largeImagePath = pathForReducedImage;
                            }

                            CreateThumbnailImage(largeImagePath, thumbPath, 5);

                            #region Save object in database 
                            Picture picture = MappingService.Map<CreatePictureViewModel, Picture>(model);
                            picture.ThumbnailImagePath = relativeThumbPath + thumbFileName;


                            picture.ImagePath = relativeLargeImagePath + largeFileName;

                            DataBase.Images.InsertPicture(picture);
                            DataBase.Save();
                            #endregion

                            NotificationAboutSuccessfullUpload();

                        }

                        catch (Exception ex)
                        {
                            //Result = "ERROR: " + ex.Message.ToString() + " " + ex.InnerException;
                            Result = "Возникла непредвиденная ошибка";
                        }
                    }
                    else
                    {
                        Result = "Недопуcтимый формат. Разрешается .jpeg, .png, .bmp";
                    }
                }
                else
                {
                    Result = "Вы не выбрали файл.";
                }
            }
        }



        #region JavaScript alerts

        void NotificationAboutSuccessfullUpload()
        {
            long currentDirSize = GetDirectorySize(Server.MapPath("~/Images/"));

            long photosAmount = (MaxHostingFolderSize - currentDirSize) / (MaxTargetLength * 2);

            string js = "images.showNotificationAboutSuccessfullUpload(" + photosAmount + ")";

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "success", js, true);
        }
        #endregion

        public void ReleaseResources(FileUpload uploadControl)
        {
            uploadControl.PostedFile.InputStream.Flush();
            uploadControl.PostedFile.InputStream.Close();
            uploadControl.FileContent.Dispose();
        }

        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            var label = createPictureFormView.FindControl("lblResult") as Label;
            label.ForeColor = Color.Red;
            label.Text = Result;
        }

        public long GetDirectorySize(string parentDirectory)
        {
            return new DirectoryInfo(parentDirectory).GetFiles("*.*", SearchOption.AllDirectories).Sum(file => file.Length);
        }

        void ReduceImageByteSize(int currentLength, int targetLength, string largeImagePath, string pathForReducedImage)
        {
            if (currentLength > targetLength)
            {
                int ratio = currentLength / targetLength;

                CreateThumbnailImage(largeImagePath, pathForReducedImage, ratio);
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                File.Delete(largeImagePath);
            }
        }
        private void CreateThumbnailImage(string filePath, string thumbPath, int decreasedRatio)
        {
            string extension = Path.GetExtension(filePath);

            ImageFormat imgFormat = null;

            switch (extension.ToLower())
            {
                case ".jpg":
                    imgFormat = ImageFormat.Jpeg;
                    break;

                case ".png":
                    imgFormat = ImageFormat.Png;
                    break;

                case ".bmp":
                    imgFormat = ImageFormat.Bmp;
                    break;
            }

            var bmp = new Bitmap(filePath);

            var myEncoderParameters = new EncoderParameters(1);
            var myEncoderParameter = new EncoderParameter(Encoder.Quality, 100L / decreasedRatio);
            myEncoderParameters.Param[0] = myEncoderParameter;

            ImageCodecInfo jgpEncoder = GetEncoder(imgFormat);
            bmp.Save(thumbPath, jgpEncoder, myEncoderParameters);
        }


        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }
}