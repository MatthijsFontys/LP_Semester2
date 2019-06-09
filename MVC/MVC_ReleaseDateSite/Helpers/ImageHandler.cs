using Microsoft.AspNetCore.Http;
using MVC_ReleaseDateSite.Interfaces;
using System;
using System.IO;
using System.Text;

namespace MVC_ReleaseDateSite {
    internal static class ImageHandler {

        private const string ImagePathFromRoot = @"images/userUploads";

        public static bool IsImageValid(IFormFile file) {
            if (file != null) {
                string extension = Path.GetExtension(file.FileName);
                if (! IsFileExtensionValid(extension))
                    throw new BadImageFormatException(ExceptionMessages.InvalidImageType(extension));

                double MaxFileSizeInBytes = Math.Pow(10, 6); // 1 Mega byte
                if (file.Length > MaxFileSizeInBytes)
                    throw new FileLoadException(ExceptionMessages.FileSizeTooBig);

                return true;
            }
            return false;

        }
        public static string SaveImage(string rootpath, IFormFile file) {
            string filePath = Path.Combine(rootpath, ImagePathFromRoot);
            string fileName = Path.GetFileName(file.FileName);
            string fullPath = Path.Combine(filePath, fileName);
            string extension = Path.GetExtension(fullPath);
            using (FileStream stream = new FileStream(fullPath, FileMode.Create)) {
                file.CopyTo(stream);
            }
            string newFileName = GenerateRandomFileName(extension);
            string newFilePath = Path.Combine(filePath, newFileName);
            File.Move(fullPath, newFilePath);
            return Path.Combine("/", ImagePathFromRoot, newFileName);
        }

        private static string GenerateRandomFileName(string extension) {
            return Guid.NewGuid() + extension;
        }

        private static string CreateFileName(string releaseName, string releaseCategory, DateTime releaseDate, string extension) {
            return releaseName + "_" + releaseCategory + "_" + releaseDate + extension;
        }

        private static bool IsFileExtensionValid(string extension) {
            string[] validFileExtentions = new string[] {".png", ".jpg", ".jpeg"};
            foreach (string fileFormat in validFileExtentions) {
                if (extension == fileFormat)
                    return true;
            }
            return false;
        }
    }
}
