using MovieProDemo.Enums;
using MovieProDemo.Models.TMDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProDemo.Services.Interfaces
{
    public interface IRemoteMovieService
    {
        Task<MovieDetail> MovidDetailAsync(int id);
        Task<MovieSearch> SearchMovieAsync(MovieCategory cateory, int count);
        Task<ActorDetail> ActorDetailAsync(int id);
    }
}
