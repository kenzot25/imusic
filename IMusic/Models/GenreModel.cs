using System;
using System.ComponentModel.DataAnnotations;

namespace IMusic.Models
{
	public class GenreModel
	{
        [Key]
        public string PK_sGenreId { get; set; }
        public string sGenre { get; set; }

        public GenreModel()
		{
		}
	}
}

