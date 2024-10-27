using IMusic.Models;
using IMusic.Repositories;
using IMusic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IMusic.Controllers
{
    [Authorize]
    public class SongController : Controller
    {
        private readonly ISongRepository _songRepository;
        private readonly FirebaseStorageService _firebaseStorageService;

        public SongController(ISongRepository songRepository, FirebaseStorageService firebaseStorageService)
        {
            _songRepository = songRepository;
            _firebaseStorageService = firebaseStorageService;
        }

        // Index action to display the list of songs
        public async Task<IActionResult> Index()
        {
            var songs = await _songRepository.GetAllSongsAsync();
            return View(songs);
        }

        public async Task<IActionResult> Create()
        {
            var genres = await _songRepository.GetGenresAsync();
            if (genres == null || !genres.Any())
            {
                ViewBag.Error = "No genres found. Please add genres before uploading songs.";
                return View();
            }

            ViewBag.Genres = genres;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SongModel model, IFormFile file, IFormFile image)
        {
            // Validate song file
            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("file", "Please upload a valid song file.");
                ViewBag.Genres = await _songRepository.GetGenresAsync();
                return View(model);
            }

            // Validate image file
            if (image == null || image.Length == 0)
            {
                ModelState.AddModelError("image", "Please upload a valid song image.");
                ViewBag.Genres = await _songRepository.GetGenresAsync();
                return View(model);
            }

            // Upload the song file to Firebase Storage
            var songDownloadUrl = await _firebaseStorageService.UploadFileAsync(file, GetCurrentUserId());
            if (string.IsNullOrEmpty(songDownloadUrl))
            {
                ViewBag.Error = "Upload failed: Download URL for song file is empty.";
                ViewBag.Genres = await _songRepository.GetGenresAsync();
                return View(model);
            }

            // Upload the song image to Firebase Storage
            var imageDownloadUrl = await _firebaseStorageService.UploadFileAsync(image, GetCurrentUserId());
            if (string.IsNullOrEmpty(imageDownloadUrl))
            {
                ViewBag.Error = "Upload failed: Download URL for song image is empty.";
                ViewBag.Genres = await _songRepository.GetGenresAsync();
                return View(model);
            }

            // Populate the model
            model.sSongPath = songDownloadUrl;
            model.sImageUrl = imageDownloadUrl; // Set the image URL
            model.PK_sSongId = Guid.NewGuid().ToString();
            model.FK_sUserId = GetCurrentUserId();
            model.dUploadDate = DateTime.UtcNow;
            model.iListened = 0;

            // Save the song to the repository
            await _songRepository.AddSongAsync(model);
            return RedirectToAction("Index");
        }


        // Helper method to get the current user's ID
        private string GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var song = await _songRepository.GetSongByIdAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            ViewBag.RelatedSongs = _songRepository.GetRelatedSongsByGenre(song.FK_sGenreId, song.PK_sSongId);

            return View(song);
        }

    }
}
