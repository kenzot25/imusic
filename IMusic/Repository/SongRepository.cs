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
    }
}
