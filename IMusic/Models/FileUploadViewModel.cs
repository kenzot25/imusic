using System;
namespace IMusic.Models
{
	public class FileUploadViewModel
	{
        public IFormFile File { get; set; }
        public string Title { get; set; } // Song title
        public string Artist { get; set; } // Artist name
        public string GenreId { get; set; } // Genre ID
    }
}

