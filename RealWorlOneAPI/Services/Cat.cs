using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RealWorlOneAPI.Services {
    public class Cat : ICat {
        private const string URL = "https://cataas.com/cat";
        public byte[] Get() {
            HttpClient client = new HttpClient();
            try {
                HttpResponseMessage response = client.GetAsync(URL).Result;
                byte[] image = response.Content.ReadAsByteArrayAsync().Result;

                var bmp = new Bitmap(new MemoryStream(image));
                bmp.RotateFlip(RotateFlipType.Rotate180FlipNone);
                byte[] rotatedImage;
                using (var stream = new MemoryStream()) {
                    bmp.Save(stream, ImageFormat.Jpeg);
                    rotatedImage = stream.GetBuffer();
                }

                //return File(byteArray, "image/jpeg");
                return rotatedImage;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
}
