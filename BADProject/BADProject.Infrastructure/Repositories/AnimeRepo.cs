using BADProject.Domain.Entities;
using BADProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BADProject.Infrastructure.Repositories
{
    public class AnimeRepo : IAnimeRepo
    {
        private readonly ApplicationDbContext _context;  

        public AnimeRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Anime>> GetAll()
        {
            return await _context.Animes.Include(a => a.Genre).ToListAsync(); 
        }

        public async Task<List<Genre>> GetAllGenres() 
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task Toevoegen(Anime anime)
        {
            await _context.Animes.AddAsync(anime);
            await _context.SaveChangesAsync();
        }

        public async Task<Anime> FindByAnimeId(int animeId)
        {
            return await _context.Animes.FirstOrDefaultAsync(p => p.Id == animeId);
        }

        public async Task<IEnumerable<Reviews>> FindReviewByAnimeId(int animeId)
        {
            return await _context.Reviews.Where(r => r.AnimeId == animeId).ToListAsync();
        }

        public async Task AddReview(Reviews review)
        {
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();

        }

        public async Task<Reviews> FindReviewById(int reviewId)
        {
            return await _context.Reviews.FindAsync(reviewId);
        }

        public async Task DeleteReview(int reviewId)
        {
            var review = await _context.Reviews.FindAsync(reviewId);
            if (review != null)
            {
                _context.Reviews.Remove(review);
                await _context.SaveChangesAsync();
            }
        }

    }
}
