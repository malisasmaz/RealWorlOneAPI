using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;

namespace RealWorlOneAPI.Services {
    public class Cat : ICat {
        private const string URL = "https://cataas.com/cat";

        public byte[] GetByRotate(int rotation) {
            HttpClient client = new HttpClient();
            try {
                HttpResponseMessage response = client.GetAsync(URL).Result;
                byte[] image = response.Content.ReadAsByteArrayAsync().Result;

                var bmp = new Bitmap(new MemoryStream(image));

                switch (rotation) {
                    case 90:
                        bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                    case 180:
                        bmp.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case 270:
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
        public byte[] Get() {
            return GetByRotate(180);
        }
    }
}
