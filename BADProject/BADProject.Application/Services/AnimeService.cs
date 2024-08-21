using BADProject.Application.Services.Interfaces;
using BADProject.Domain.Entities;
using BADProject.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;


namespace BADProject.Application.Services
{
    public class AnimeService : IAnimeService
    {
        private readonly IAnimeRepo _animeRepository;

        public AnimeService(IAnimeRepo animeRepository)
        {
            _animeRepository = animeRepository;
        }

        public async Task<Anime> FindByAnimeId(int id)
        {
            return await _animeRepository.FindByAnimeId(id);
        }

        public async Task<IEnumerable<Reviews>> FindReviewByAnimeId(int id)
        {
            return await _animeRepository.FindReviewByAnimeId(id);
        }

        public async Task<List<Anime>> GetAllAnime()
        {
            return await _animeRepository.GetAll();
        }


        public async Task<List<Genre>> GetAllGenres()
        {
            return await _animeRepository.GetAllGenres();
        }

        public async Task Toevoegen(Anime animes)
        {
            await _animeRepository.Toevoegen(animes);
        }

        public async Task AddReview(Reviews reviews)
        {
            await _animeRepository.AddReview(reviews);
        }

        public async Task<Reviews> FindReviewById(int reviewId)
        {
            return await _animeRepository.FindReviewById(reviewId);
        }

        public async Task DeleteReview(int reviewId)
        {
            await _animeRepository.DeleteReview(reviewId);
        }
    }
}
