using ApiSample.Models;

namespace ApiSample.Services
{
    public class FilmService
    {
        public List<Film> Liste { get; set; }
        public FilmService()
        {
            Liste = new List<Film>();
            Liste.Add(new Film
            {
                Id = 1,
                Titre = "Star Wars",
                Synopsis = "L'histoire d'un pirate et d'une boule de poil",
                AnneeSortie = 1977, Bonfilm = true, Genre = "Sci-fi",
                Realisateur = new Personne { Nom = "Lucas", Prenom = "George"}
            });
        }

        public void Add(Film film)
        {
            film.Id = Liste.Max(x => x.Id) + 1;
            Liste.Add(film);
        }

        public Film GetById(int id)
        {
            return Liste.FirstOrDefault(x => x.Id == id);
        }
    }
}
