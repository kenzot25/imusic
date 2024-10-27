using IMusic.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMusic.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly ApplicationDbContext _context;

        public SongRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<SongModel>> GetAllSongsAsync()
        {
            return await _context.Songs.Include(s => s.User).Include(s => s.Genre).ToListAsync();
        }

        public async Task AddSongAsync(SongModel song)
        {
            _context.Songs.Add(song);
            await _context.SaveChangesAsync();
        }

        public async Task<List<GenreModel>> GetGenresAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<SongModel> GetSongByIdAsync(string songId)
        {
            return await _context.Songs
                                 .Include(s => s.Genre) 
                                 .Include(s => s.User)
                                 .Include(s => s.Playlist)
                                 .FirstOrDefaultAsync(s => s.PK_sSongId == songId);
        }

        public List<SongModel> GetRelatedSongsByGenre(string genreId, string currentSongId)
        {
            return _context.Songs
                .Where(s => s.FK_sGenreId == genreId && s.PK_sSongId != currentSongId)
                .Include(s => s.Genre) 
                .Include(s => s.User)
                .ToList();
        }
    }
}
