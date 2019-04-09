using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace MVC_ReleaseDateSite {
    internal static class ImageHandler {

        private const string ImagePathFromRoot = @"/images/userUploads";

        public static bool IsImageValid(IFormFile file) {
            try {
                if (file != null) {
                    string extension = Path.GetExtension(file.FileName);
                    if (extension != ".png" && extension != ".jpg" && extension != ".jpeg")
                        throw new FileLoadException("Only png and jpg allowed");
                    return true;
                }
            }
            catch (FileNotFoundException ex) {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        public static string SaveImage(IHostingEnvironment he, IFormFile file) {
            string filePath = Path.Combine(he.WebRootPath, ImagePathFromRoot);
            string fileName = Path.GetFileName(file.FileName);
            string fullPath = Path.Combine(filePath, fileName);
            string extension = Path.GetExtension(fullPath);
            using (FileStream stream = new FileStream(fullPath, FileMode.Create)) {
                file.CopyTo(stream);
            }
            string newFileName = GenerateFileName(extension);
            string newFilePath = Path.Combine(filePath, newFileName);
            File.Move(fullPath, newFilePath);
            return Path.Combine(ImagePathFromRoot, newFileName);
        }

        private static string GenerateFileName(string extension) {
            return Guid.NewGuid() + extension;
        }
    }
}
