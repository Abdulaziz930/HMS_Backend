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
        public static async Task FireBaseFileUploadAsync(FileStream stream, IFormFile formFile, FileType fileType)
        {
            var fileName = $"{Guid.NewGuid()}-{formFile.FileName}";

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
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception was thrown: {0}", ex);
            }
        }

        public static async Task FireBaseDeleteFileAsync(string fileName, FileType fileType)
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

        public static async Task<string> FireBaseGetFileAsync(string fileName, FileType fileType)
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
    }
}
