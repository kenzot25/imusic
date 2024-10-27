using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace IMusic.Services
{
    public class FirebaseStorageService
    {
        private readonly string _apiKey;
        private readonly string _bucket;
        private readonly string _authEmail;
        private readonly string _authPassword;

        public FirebaseStorageService(string apiKey, string bucket, string authEmail, string authPassword)
        {
            _apiKey = apiKey;
            _bucket = bucket;
            _authEmail = authEmail;
            _authPassword = authPassword;
        }

        public async Task<string> UploadFileAsync(IFormFile file, string userId)
        {
            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                stream.Position = 0; // Reset stream position

                var auth = new FirebaseAuthProvider(new FirebaseConfig(_apiKey));
                var signIn = await auth.SignInWithEmailAndPasswordAsync(_authEmail, _authPassword);

                var task = new FirebaseStorage(
                    _bucket,
                    new FirebaseStorageOptions
                    {
                        AuthTokenAsyncFactory = () => Task.FromResult(signIn.FirebaseToken),
                        ThrowOnCancel = true
                    })
                    .Child("songs")
                    .Child(file.FileName + "-" + userId + "-" + Guid.NewGuid())
                    .PutAsync(stream);

                try
                {
                    return await task; // Return the download URL
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error uploading file to Firebase: {ex.Message}");
                    return string.Empty;
                }
            }
        }
    }
}
