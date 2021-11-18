using MovieProDemo.Models.Database;
using MovieProDemo.Models.TMDB;
using MovieProDemo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProDemo.Services
{
    public class TMDBDataMappingService : IDataMappingService
    {
        public ActorDetail MapActorDetail(ActorDetail actor)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> MapMovieDetailAsync(MovieDetail movie)
        {
            throw new NotImplementedException();
        }
    }
}
