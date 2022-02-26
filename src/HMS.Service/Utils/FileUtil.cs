using Firebase.Auth;
using Firebase.Storage;
using HMS.Service.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HMS.Service.Utils
{
    public static class FileUtil
    {
        public static async Task<string> GenerateFileAsync(string folderPath, IFormFile formFile, FileType fileType)
        {
            var fileName = $"{Guid.NewGuid()}-{formFile.FileName}";
            var filePath = Path.Combine(folderPath, fileName);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await formFile.CopyToAsync(fileStream);
            }

            FileStream stream = new FileStream(filePath, FileMode.Open);
            await FireBaseFileUploadAsync(stream, fileName, fileType);
            stream.Close();

            return fileName;
        }

        public static async Task DeleteFileAsync(string fileName, FileType fileType)
        {
            var path = Path.Combine(fileType == FileType.Image ? Constants.ImageFolderPath : Constants.VideoFolderPath, fileName);
            var fireBaseFile = await FireBaseGetFileAsync(fileName, fileType);
            if (File.Exists(path) && !string.IsNullOrWhiteSpace(fireBaseFile))
            {
                await FireBaseDeleteFileAsync(fileName, fileType);
                File.Delete(path);
            }
        }

        public static async Task<string> UpdateFileAsync(string fileName, string folderPath, IFormFile formFile, FileType fileType)
        {
            await DeleteFileAsync(fileName, fileType);
            var newFileName = await GenerateFileAsync(folderPath, formFile, fileType);

            return newFileName;
        }

        public static async Task<string> GetFileAsync(string fileName, FileType fileType)
        {
            var path = Path.Combine(fileType == FileType.Image ? Constants.ImageFolderPath : Constants.VideoFolderPath, fileName);
            var fireBaseFile = await FireBaseGetFileAsync(fileName, fileType);
            if (File.Exists(path) && !string.IsNullOrWhiteSpace(fireBaseFile))
            {
                return fireBaseFile;
            }

            return null;
        }

        #region FireBaseUtils

        private static async Task<string> FireBaseFileUploadAsync(FileStream stream, string fileName, FileType fileType)
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig(Constants.FireBaseApiKey));
            var a = await auth.SignInWithEmailAndPasswordAsync(Constants.FireBaseAuthEmail, Constants.FireBaseAuthPassword);

            var cancellation = new CancellationTokenSource();

            var task = new FirebaseStorage(
                Constants.FireBaseBucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true
                })
                .Child(fileType == FileType.Image ? "Images" : "Videos")
                .Child(fileName)
                .PutAsync(stream, cancellation.Token);

            try
            {
                string link = await task;
                return link;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception was thrown: {0}", ex);
                return "";
            }
        }

        private static async Task FireBaseDeleteFileAsync(string fileName, FileType fileType)
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig(Constants.FireBaseApiKey));
            var a = await auth.SignInWithEmailAndPasswordAsync(Constants.FireBaseAuthEmail, Constants.FireBaseAuthPassword);

            var cancellation = new CancellationTokenSource();

            var task = new FirebaseStorage(
                Constants.FireBaseBucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true
                })
                .Child(fileType == FileType.Image ? "Images" : "Videos")
                .Child(fileName)
                .DeleteAsync();
        }

        private static async Task<string> FireBaseGetFileAsync(string fileName, FileType fileType)
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig(Constants.FireBaseApiKey));
            var a = await auth.SignInWithEmailAndPasswordAsync(Constants.FireBaseAuthEmail, Constants.FireBaseAuthPassword);

            var cancellation = new CancellationTokenSource();

            var task = new FirebaseStorage(
                Constants.FireBaseBucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true
                })
                .Child(fileType == FileType.Image ? "Images" : "Videos")
                .Child(fileName)
                .GetDownloadUrlAsync();

            return await task;
        }

        #endregion
    }
}
