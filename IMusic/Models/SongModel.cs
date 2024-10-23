using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMusic.Models
{
	public class SongModel
	{
        [Key]
        public string PK_sSongId { get; set; }

        public string sSongName { get; set; }

        [ForeignKey("Genre")]
        public string? FK_sGenreId { get; set; }

        public string? sSongPath { get; set; }

        [ForeignKey("User")]
        public string? FK_sUserId { get; set; }
        public DateTime dUploadDate { get; set; }
        public int? iListened { get; set; }
        public string? FK_sPlaylistId { get; set; }

        public string? sImageUrl { get; set; }

        // Navigation Property
        public virtual GenreModel? Genre { get; set; }

        public SongModel()
		{
		}
	}
}

