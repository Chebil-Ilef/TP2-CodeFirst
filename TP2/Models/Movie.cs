using System.ComponentModel.DataAnnotations;

namespace TP2.Models
{

    public class Movie
    {
        public int Id { get; set; }

        

        public string? Name { get; set; }
        public Movie()
        {
        }

        // Foreign key for the Genre
        public Guid GenreId { get; set; }

        // Navigation property
        public virtual Genre Genre { get; set; }
    }
}
