using System.ComponentModel.DataAnnotations;

namespace Library.BackendData.Models
{
    /// <summary>
    /// Reprezinta o carte in sistemul bibliotecii
    /// </summary>
    public class Book
    {
        public int Id { get; private set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; private set; }

        [Required]
        [PastOrCurrentYear]
        public int PublicationYear { get; private set; }

        [MaxLength(50)]
        public string Genre { get; private set; }

        [Required]
        [ValidIsbnAttribute]
        public string ISBN { get; private set; }

        public int AuthorId { get; private set; }
        public Author Author { get; private set; } = null!;

        /// <summary>
        /// Constructor privat utilizat de Entity Framework Core pentru reflexie
        /// </summary>
        private Book() { }

        /// <summary>
        /// Initializeaza o instanta noua a clasei Book cu datele necesare si cheia externa a autorului
        /// </summary>
        public Book(string title, int publicationYear, string genre, string isbn, int authorId)
        {
            Title = title;
            PublicationYear = publicationYear;
            Genre = genre;
            ISBN = isbn;
            AuthorId = authorId;
        }
    }
}