using CinemaApp.Business.Dtos;

namespace CinemaApp.Business.Services
{
    public interface IMovieService
    {
        bool AddMovie(MovieAddDto movieAddDto);
        int UpdateMovie(MovieUpdateDto movieUpdateDto);
        int MakeDiscount(int id);
        int DeleteMovie(int id);
        MovieDto GetMovie(int id);
        List<MovieDto> GetAllMovies();
    }
}
