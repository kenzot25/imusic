using IMusic.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext<UserModel>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<GenreModel> Genres { get; set; }
    public DbSet<PlaylistModel> Playlists { get; set; }
    public DbSet<SongModel> Songs { get; set; }
    public DbSet<FollowModel> Follows { get; set; }
    public DbSet<LikeModel> Likes { get; set; }
    public DbSet<UserModel> Users { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // Call the base method
        modelBuilder.Entity<GenreModel>().ToTable("tbl_Genre");
        modelBuilder.Entity<PlaylistModel>().ToTable("tbl_Playlist");
        modelBuilder.Entity<SongModel>().ToTable("tbl_Song");
        modelBuilder.Entity<FollowModel>().ToTable("tbl_Follow");
        modelBuilder.Entity<LikeModel>().ToTable("tbl_Like");
        modelBuilder.Entity<UserModel>().ToTable("tbl_User");
        modelBuilder.Entity<UserModel>()
           .HasKey(u => u.PK_sUserId);
    }
}
