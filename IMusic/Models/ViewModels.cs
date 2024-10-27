using System;
namespace IMusic.Models
{
	public class ViewModels
	{
        public class RegisterViewModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public string FullName { get; set; }
        }

        public class LoginViewModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public bool RememberMe { get; set; }
        }

        public class HomeViewModel
        {
            public List<SongModel> TopSongs { get; set; }
            public List<SongModel> LatestTrends { get; set; }
        }

    }
}

