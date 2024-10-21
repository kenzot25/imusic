using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace IMusic.Models
{
    public class UserModel : IdentityUser
    {
        public override string Id
        {
            get => PK_sUserId;
            set => PK_sUserId = value;
        }


        [Key]
        public string PK_sUserId { get; set; }
        public string sHoTen { get; set; }
        public string? sAvatar { get; set; }
        public string? sBio { get; set; }
    }
}

