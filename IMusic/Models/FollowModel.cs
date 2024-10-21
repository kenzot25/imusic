using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMusic.Models
{
	public class FollowModel
	{
		[Key]
        public string PK_sFollowId { get; set; }

        [ForeignKey("Follow")]
        public string FK_sFollowerId { get; set; }

        [ForeignKey("Follow")]
        public string FK_sFollowedId { get; set; }

        public FollowModel()
		{
		}
	}
}

