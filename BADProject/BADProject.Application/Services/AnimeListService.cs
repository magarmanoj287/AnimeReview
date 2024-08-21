using BADProject.Application.Services.Interfaces;
using BADProject.Domain.Entities;
using BADProject.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BADProject.Application.Services
{

    public class AnimeListService : IAnimeListService
    {
        private readonly IAnimeListRepo _animeListRepo;

        public AnimeListService(IAnimeListRepo animeListRepo)
        {
            _animeListRepo = animeListRepo;
        }
        public async Task DeleteProduct(int id)
        {
            await _animeListRepo.DeleteProduct(id);
        }

        public async Task<Anime> FindByGenreId(int id)
        {
            return await _animeListRepo.FindByGenreId(id);
        }

        public async Task<Anime> FindById(int id)
        {
            return await _animeListRepo.FindById(id);
        }

        public async Task UpdateAnime(Anime anime)
        {
            await _animeListRepo.UpdateAnime(anime);
        }

        public async Task<IEnumerable<Anime>> GetWatchListByUserId(string userId)
        {
            return await _animeListRepo.GetWatchListByUserId(userId);
        }

        public async Task AddToWatchList(int animeId, string userId)
        {
            await _animeListRepo.AddToWatchList(animeId, userId);
        }

        public async Task<bool> IsAnimeInWatchList(int animeId, string userId)
        {
            return await _animeListRepo.IsAnimeInWatchList(animeId,userId);
        }

        public async Task RemoveFromWatchList(int animeId, string userId)
        {
             await _animeListRepo.RemoveFromWatchList(animeId, userId);
        }

    }
}
