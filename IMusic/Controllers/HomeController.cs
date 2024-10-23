using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IMusic.Models;
using Microsoft.AspNetCore.Authorization;
using IMusic.Repositories;
using static IMusic.Models.ViewModels;

namespace IMusic.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ISongRepository _songRepository;

    public HomeController(ISongRepository songRepository)
    {
        _songRepository = songRepository;
    }

    public async Task<IActionResult> Index()
    {
        // Fetch songs and trends for the homepage
        var songs = await _songRepository.GetAllSongsAsync();

        // Comment this if there are no songs yet
        if (songs == null || !songs.Any())
        {
            // Optional: return a placeholder view or message when there are no songs
            ViewBag.Message = "No songs available yet!";
            return View(new HomeViewModel());
        }

        var topSongs = songs.OrderByDescending(s => s.iListened).Take(6).ToList();
        var latestTrends = songs.OrderByDescending(s => s.dUploadDate).Take(2).ToList();

        var viewModel = new HomeViewModel
        {
            TopSongs = topSongs,
            LatestTrends = latestTrends
        };

        return View(viewModel);
    }

}
