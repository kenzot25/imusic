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
        var topSongs = songs.OrderByDescending(s => s.iListened).Take(10).ToList();
        var latestTrends = songs.OrderByDescending(s => s.dUploadDate).Take(5).ToList();

        var viewModel = new HomeViewModel
        {
            TopSongs = topSongs,
            LatestTrends = latestTrends
        };

        return View(viewModel);
    }
}
