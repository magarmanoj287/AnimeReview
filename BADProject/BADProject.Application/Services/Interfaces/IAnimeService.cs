using BADProject.Domain.Entities;

namespace BADProject.Application.Services.Interfaces
{
    public interface IAnimeService
    {
        Task<Anime> FindByAnimeId(int id);
        Task<IEnumerable<Reviews>> FindReviewByAnimeId(int id);
        Task<List<Anime>> GetAllAnime();
        Task<List<Genre>> GetAllGenres();
        Task Toevoegen(Anime animes);

        Task AddReview(Reviews review);
        Task<Reviews> FindReviewById(int reviewId);
        Task DeleteReview(int reviewId);
    }
}
