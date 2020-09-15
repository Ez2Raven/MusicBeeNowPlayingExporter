using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace MusicBeeExporter.Imaging
{
    public class ImageHelper
    {
        /// <summary>
        ///     Renders a base64 image and resize it to the required width and height in high quality.
        /// </summary>
        /// <param name="artworkBase64"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Bitmap ResizedArtworkImage(string artworkBase64, int width, int height)
        {
            //Convert Base64 to image.
            var imageBytes = Convert.FromBase64String(artworkBase64);

            Image artworkImage;
            using (var ms = new MemoryStream(imageBytes))
            {
                artworkImage = Image.FromStream(ms);
            }

            // now that the image is loaded in memory, we'll resize it.

            var destRect = new Rectangle(0, 0, width, height);
            var resizedArtworkImage = new Bitmap(width, height);

            resizedArtworkImage.SetResolution(artworkImage.HorizontalResolution, artworkImage.VerticalResolution);

            using (var graphics = Graphics.FromImage(resizedArtworkImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(artworkImage, destRect, 0, 0, artworkImage.Width, artworkImage.Height,
                        GraphicsUnit.Pixel, wrapMode);
                }
            }

            return resizedArtworkImage;
        }
    }
}