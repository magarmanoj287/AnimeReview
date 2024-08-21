using BADProject.Application.Services;
using BADProject.Application.Services.Interfaces;
using BADProject.Domain.Entities;
using BADProject.Infrastructure.Repositories;
using BADProject.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportStore.Infrastructure.Identity;
using System.Collections.Generic;

namespace BADProject.WebUI.Controllers
{
    public class AnimeListController : Controller
    {
        private readonly IFileUploadService _fileUploadService;
        private readonly IAnimeService _animeService;
        private readonly IAnimeListService _animeListService;
        private readonly UserManager<ApplicationUser> _userManager;
        public AnimeListController(IFileUploadService fileUploadService, IAnimeService animeService, IAnimeListService animeListService, UserManager<ApplicationUser> userManager)
        {
            _fileUploadService = fileUploadService;
            _animeService = animeService;
            _animeListService = animeListService;
            _userManager = userManager;
        }

        public async Task<IActionResult> AnimeList()
        {
            var userId = _userManager.GetUserId(User);

            List<Anime> animes = await _animeService.GetAllAnime();
            List<AnimeViewModel> viewModelList = new List<AnimeViewModel>();

            foreach (Anime anime in animes)
            {
                bool isInWatchList = await _animeListService.IsAnimeInWatchList(anime.Id, userId);  

                IEnumerable<Reviews> reviews = await _animeService.FindReviewByAnimeId(anime.Id);
                double averageRating = reviews.Any() ? reviews.Average(r => r.Rating) : 0;

                AnimeViewModel viewModel = new AnimeViewModel
                {
                    Id = anime.Id,
                    Title = anime.Title,
                    Description = anime.Description,
                    ImageURL = anime.ImageURL,
                    GenreName = anime.Genre.Name,
                    AverageRating = averageRating,
                    IsInWatchList = isInWatchList
                };
                viewModelList.Add(viewModel);
            }
            return View(viewModelList);
        }

        [Authorize(Policy = "CanManageCatalog")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _animeListService.DeleteProduct(id);
            return RedirectToAction("AnimeList", "AnimeList");
        }
        public async Task<IActionResult> Edit(int id)
        {
            Anime anime = await _animeListService.FindById(id);

            AnimeViewModel viewModel = new AnimeViewModel
            {
                Id = anime.Id,
                Title = anime.Title,
                Description = anime.Description,
                ReleaseDate = anime.Release_date,
                GenreId = anime.GenreId,
                ImageURL = anime.ImageURL,
                GenresList = await _animeService.GetAllGenres()
            };

            return View(viewModel);
        }

        [Authorize(Policy = "CanManageCatalog")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AnimeViewModel model)
        {

            if (model.Image == null || model.Image.Length == 0)
            {
                ModelState.Remove("Image");
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Anime anime = await _animeListService.FindById(id);
            if (anime == null)
            {
                return NotFound();
            }

            if (model.Image != null && model.Image.Length > 0)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.Image.FileName);
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", fileName);

                await _fileUploadService.UploadFile(model.Image.OpenReadStream(), filePath);
                anime.ImageURL = fileName;
            }

            anime.Title = model.Title;
            anime.Description = model.Description;
            anime.Release_date = model.ReleaseDate;
            anime.GenreId = model.GenreId;

            await _animeListService.UpdateAnime(anime);

            return RedirectToAction("AnimeList", "AnimeList");
        }

        public async Task<IActionResult> WatchLists()
        {
            string? userId = _userManager.GetUserId(User);
            IEnumerable<Anime> watchlistAnimes = await _animeListService.GetWatchListByUserId(userId);
            return View("WatchList", watchlistAnimes);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToWatchList(int id) 
        {
            string? userId = _userManager.GetUserId(User);
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToPage("/Account/Login", new { area = "Identity" });
            }
            if (!await _animeListService.IsAnimeInWatchList(id, userId))
            {
                await _animeListService.AddToWatchList(id, userId);
            }

            return RedirectToAction("WatchLists");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveFromWatchList(int id)
        {
            string? userId = _userManager.GetUserId(User);
            await _animeListService.RemoveFromWatchList(id, userId);
            return RedirectToAction("WatchLists");
        }
    }
}
