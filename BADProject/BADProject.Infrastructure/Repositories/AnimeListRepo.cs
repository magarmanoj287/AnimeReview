using BADProject.Application.Services.Interfaces;
using BADProject.Domain.Entities;
using BADProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BADProject.Infrastructure.Repositories
{
    public class AnimeListRepo : IAnimeListRepo
    {
        private readonly ApplicationDbContext _context;

        public AnimeListRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task DeleteProduct(int id)
        {
            Anime anime = _context.Animes.Find(id);
            if (anime != null)
            {
                _context.Animes.Remove(anime);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Anime> FindById(int id)
        {
            return await _context.Animes.Include(a => a.Genre).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Anime> FindByGenreId(int genreID)
        {
            return await _context.Animes.FirstOrDefaultAsync(p => p.GenreId == genreID);
        }

        public async Task UpdateAnime(Anime anime)
        {
            _context.Animes.Update(anime);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Anime>> GetWatchListByUserId(string userId)
        {
            return await _context.Watchlists
                .Where(w => w.UserId == userId)
                .Select(w => w.Anime)
                .ToListAsync();
        }

        public async Task AddToWatchList(int animeId, string userId)
        {
            var watchlistEntry = new WatchList { UserId = userId, AnimeId = animeId };
            await _context.Watchlists.AddAsync(watchlistEntry);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsAnimeInWatchList(int animeId, string userId)
        {
            return await _context.Watchlists.AnyAsync(w => w.UserId == userId && w.AnimeId == animeId);
        }

        public async Task RemoveFromWatchList(int animeId, string userId)
        {
            var watchlistEntry = await _context.Watchlists.FirstOrDefaultAsync(wl => wl.UserId == userId && wl.AnimeId == animeId);

            if (watchlistEntry != null)
            {
                _context.Watchlists.Remove(watchlistEntry);
                await _context.SaveChangesAsync();
            }
        }

    }
}
