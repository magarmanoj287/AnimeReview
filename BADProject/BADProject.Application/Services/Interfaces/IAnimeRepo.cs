using BADProject.Domain.Entities;

namespace BADProject.Infrastructure.Repositories
{
    public interface IAnimeRepo
    {
        Task<List<Anime>> GetAll();
        Task<List<Genre>> GetAllGenres();
        Task Toevoegen(Anime animes);
        Task<Anime> FindByAnimeId(int animeId);
        Task<IEnumerable<Reviews>> FindReviewByAnimeId(int animeId);
        Task AddReview(Reviews review);
        Task<Reviews> FindReviewById(int reviewId);
        Task DeleteReview(int reviewId);

    }
}
