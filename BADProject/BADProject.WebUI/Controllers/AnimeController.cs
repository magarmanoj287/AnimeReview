using BADProject.Application.Services.Interfaces;
using BADProject.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using BADProject.Domain.Entities;
using BADProject.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using SportStore.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace BADProject.WebUI.Controllers
{
    [Authorize(Policy = "CanManageCatalog")]
    public class AnimeController : Controller
    {
        private readonly IFileUploadService _fileUploadService;
        private readonly IAnimeService _animeService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AnimeController(IFileUploadService fileUploadService, IAnimeService animeService, UserManager<ApplicationUser> userManger)
        {
            _fileUploadService = fileUploadService;
            _animeService = animeService;
            _userManager = userManger;
        }

        public async Task<IActionResult> AddAnime()
        {
            List<Genre> genresList = await _animeService.GetAllGenres(); 
            AnimeViewModel viewModel = new AnimeViewModel
            {
                GenresList = genresList
            };
            return View("AddAnime", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAnime(AnimeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.GenresList = await _animeService.GetAllGenres();
                return View("AddAnime", model);
            }
            if (model.Image != null && model.Image.Length > 0)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.Image.FileName);
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", fileName);

                await _fileUploadService.UploadFile(model.Image.OpenReadStream(), filePath);

                model.ImageURL = fileName;
            }
            Anime animes = new Anime
            {
                Title = model.Title,
                Description = model.Description,
                Release_date = model.ReleaseDate,
                GenreId = model.GenreId,
                ImageURL = model.ImageURL
            };

            await _animeService.Toevoegen(animes);

            return RedirectToAction("AnimeList", "AnimeList");
        }

        [AllowAnonymous]
        public async Task<IActionResult> Review(int id)
        {
            Anime anime = await _animeService.FindByAnimeId(id);
            IEnumerable<Reviews> reviews = await _animeService.FindReviewByAnimeId(id);
            List<Genre> genresList = await _animeService.GetAllGenres();

            double averageRating = (double)(reviews.Any() ? reviews.Average(r => r.Rating) : 0);

            AnimeViewModel model = new AnimeViewModel
            {
                Id = anime.Id,
                Title = anime.Title,
                Description = anime.Description,
                ImageURL = anime.ImageURL,
                ReleaseDate = anime.Release_date,
                GenreName = anime.Genre.Name,
                Reviews = reviews.ToList(),
                AverageRating = (double)averageRating
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> AddReview(int animeId, int rating, string review)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Review", new { id = animeId });
            }

            string? userId = _userManager.GetUserId(User);
            if (string.IsNullOrEmpty(userId))
            {
                // Generate the return URL
                string returnUrl = Url.Action(nameof(AddReview), new { animeId = animeId, rating = rating, review = review });

                // Redirect to the login page with the return URL as a query parameter
                return RedirectToPage("/Account/Login", new { area = "Identity", ReturnUrl = returnUrl });
            }

            var user = await _userManager.FindByIdAsync(userId);
            Reviews newReview = new Reviews
            {
                Rating = rating,
                Review = review,
                AnimeId = animeId,
                UserId = userId,
                UserName = user.FirstName + "" + user.LastName, 
                DateTime = DateTime.Now
            };

            await _animeService.AddReview(newReview);
            return RedirectToAction("Review", new { id = animeId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteReview(int id, int animeId)
        {
            Reviews review = await _animeService.FindReviewById(id);
            if (review == null)
            {
                return RedirectToAction("Review", new { id = animeId });
            }

            string currentUserId = _userManager.GetUserId(User);
            if (review.UserId != currentUserId && !User.HasClaim("CanManageCatalog", "true"))
            {
                return Unauthorized();
            }

            await _animeService.DeleteReview(id);
            return RedirectToAction("Review", new { id = animeId });
        }


    }
}
