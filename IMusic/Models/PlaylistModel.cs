using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMusic.Models
{
	public class PlaylistModel
	{
        [Key]
        public string PK_sPlaylistId { get; set; }
        public string sPlaylistName { get; set; }

        [ForeignKey("User")]
        public string FK_sUserId { get; set; }
        public DateTime dCreatedDate { get; set; }
        public string sImageUrl { get; set; }
        public PlaylistModel()
		{
		}
	}
}

