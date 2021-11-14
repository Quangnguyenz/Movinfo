using Microsoft.Extensions.Options;
using MovieProDemo.Enums;
using MovieProDemo.Models.Settings;
using MovieProDemo.Models.TMDB;
using MovieProDemo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProDemo.Services
{
    public class TMDBMovieService : IRemoteMovieService
    {
        private readonly AppSettings _appSettings;

        public TMDBMovieService(IOptions<AppSettings> appSettings)
        {
            
            _appSettings = appSettings;
        }

        public Task<ActorDetail> ActorDetailAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MovieDetail> MovidDetailAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MovieSearch> SearchMovieAsync(MovieCategory cateory, int count)
        {
            throw new NotImplementedException();
        }
    }
}
