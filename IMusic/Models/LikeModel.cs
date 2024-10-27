using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMusic.Models
{
	public class LikeModel
	{
        [Key]
        public string PK_sLikeId { get; set; }

        [ForeignKey("User")]
        public string FK_sUserId { get; set; }

        [ForeignKey("Song")]
        public string FK_sSongId { get; set; }

        public LikeModel()
		{
		}
	}
}

