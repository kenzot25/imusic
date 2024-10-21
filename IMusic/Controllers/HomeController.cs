using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IMusic.Models;
using Microsoft.AspNetCore.Authorization;
using Firebase.Auth;
using Firebase.Storage;
using System.Security.Claims;

namespace IMusic.Controllers;

[Authorize]
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
