using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace Restaurant.HelperClass
{
    public class FileUpload
    {
        public static bool UploadPhoto(HttpPostedFileBase file, string folder, string name)
        {
            if (file == null || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(folder))
            {
                return false;
            }
            try
            {
                string path = string.Empty;
                string x_large = string.Empty;
                if (file != null)
                {
                    path = Path.Combine(HttpContext.Current.Server.MapPath(folder), name);
                    file.SaveAs(path);


                    x_large = Path.Combine(HttpContext.Current.Server.MapPath(folder), "x_" + name);

                    using (Image img = Image.FromFile(path))
                    {
                        Image thumbNail = new Bitmap(270, 300, img.PixelFormat);
                        Graphics g = Graphics.FromImage(thumbNail);
                        g.CompositingQuality = CompositingQuality.HighQuality;
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        Rectangle rect = new Rectangle(0, 0, 270, 300);
                        g.DrawImage(img, rect);
                        thumbNail.Save(x_large, ImageFormat.Png);
                    }

                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.InputStream.CopyTo(ms);
                        byte[] array = ms.GetBuffer();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}