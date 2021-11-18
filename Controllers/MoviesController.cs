using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MovieProDemo.Data;
using MovieProDemo.Models.Database;
using MovieProDemo.Models.Settings;
using MovieProDemo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProDemo.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppSettings _appSettings;
        private ApplicationDbContext _context;
        private readonly IImageService _imageService;
        private readonly IRemoteMovieService _tmdbMovieService;
        private readonly IDataMappingService _tmdbMappingService;
        public MoviesController(IOptions<AppSettings> appSettings, ApplicationDbContext context, IImageService imageService, IDataMappingService tmdbMappingService, IRemoteMovieService tmdbMovieService)
        {
            _appSettings = appSettings.Value;
            _context = context;
            _imageService = imageService;
            _tmdbMappingService = tmdbMappingService;
            _tmdbMovieService = tmdbMovieService;
        }

        public async Task<IActionResult> Import()
        {
            var movies = await _context.Movie.ToListAsync();
            return View(movies);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Import(int id)
        {
            //if we already have this movie, remind the user
            if(_context.Movie.Any(m => m.id == id))
            {
                var localMovie = await _context.Movie.FirstOrDefaultAsync(m => m.MovieId == id);
                return RedirectToAction("Details", "Movie", new { id = localMovie.id, local = true });
            }

            //step 1: Get the rae data from the API
            var movieDetail = await _tmdbMovieService.MovieDetailAsync(id);

            //step 2: run the data through the mapping procedure
            var movie = await _tmdbMappingService.MapMovieDetailAsync(movieDetail);

            //step 3: add the new movie
            _context.Add(movie);
            await _context.SaveChangesAsync();

            //step 4: Assign it to the default All Collection
            await AddToMovieCollection(movie.id, _appSettings.MovieProSettings.DefaultCollection.Name);

            return RedirectToAction("Import");
        }


        public async Task<IActionResult> Library()
        {
            var movies = await _context.Movie.ToListAsync();
            return View(movies);
        }


        private async Task AddToMovieCollection(int movieId, string collectionName)
        {
            var collection = await _context.Collection.FirstOrDefaultAsync(c => c.Name == collectionName);
            _context.Add(
                new MovieCollection()
                {
                    CollectionId = collection.Id,
                    MovieId = movieId
                }
           );
        }


        private async Task AddToMovieCollection(int movieId, int collectionId)
        {
            _context.Add(
                new MovieCollection()
                {
                    CollectionId = collectionId,
                    MovieId = movieId
                }
            );
            await _context.SaveChangesAsync();
        }
    }
}
