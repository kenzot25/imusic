using IMusic.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMusic.Repositories
{
    public interface ISongRepository
    {
        Task<List<SongModel>> GetAllSongsAsync() ;
        Task AddSongAsync(SongModel song);
        Task<List<GenreModel>> GetGenresAsync();
    }
}
