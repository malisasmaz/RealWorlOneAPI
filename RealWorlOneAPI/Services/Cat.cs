using RealWorlOneAPI.Models;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;

namespace RealWorlOneAPI.Services {
    public class Cat : ICat {
        private const string URL = "https://cataas.com/cat";

        /// <summary>
        /// Get cat image by rotation
        /// </summary>
        /// <param name="rotation"></param>
        /// <returns></returns>
        public byte[] GetByRotate(Rotate rotation) {
            HttpClient client = new HttpClient();
            try {
                HttpResponseMessage response = client.GetAsync(URL).Result;
                byte[] image = response.Content.ReadAsByteArrayAsync().Result;

                var bmp = new Bitmap(new MemoryStream(image));

                switch (rotation) {
                    case Rotate.Rotate90:
                        bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                    case Rotate.Rotate180:
                        bmp.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case Rotate.Rotate270:
                        bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                    default:
                        bmp.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                        break;
                }

                byte[] rotatedImage;
                using (var stream = new MemoryStream()) {
                    bmp.Save(stream, ImageFormat.Jpeg);
                    rotatedImage = stream.GetBuffer();
                }

                return rotatedImage;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Get cat image upside down
        /// </summary>
        /// <returns></returns>
        public byte[] Get() {
            return GetByRotate(Rotate.Rotate180);
        }
    }
}
