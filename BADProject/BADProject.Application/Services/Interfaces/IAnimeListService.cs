using BADProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BADProject.Application.Services.Interfaces
{
    public interface IAnimeListService
    {
        Task DeleteProduct(int id);
        Task<Anime> FindById(int id);
        Task<Anime> FindByGenreId(int id);
        Task UpdateAnime(Anime anime);

        Task<IEnumerable<Anime>> GetWatchListByUserId(string userId);

        Task AddToWatchList(int animeId, string userId);

        Task<bool> IsAnimeInWatchList(int animeId, string userId);

        Task RemoveFromWatchList(int animeId, string userId);
    }
}
