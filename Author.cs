using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.BackendData.Models
{
    /// <summary>
    /// Reprezinta un autor in sistemul bibliotecii
    /// </summary>
    public class Author
    {
        public int Id { get; private set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; private set; }

        [MaxLength(50)]
        public string Nationality { get; private set; }

        public ICollection<Book> Books { get; private set; } = new List<Book>();

        /// <summary>
        /// Constructor privat utilizat de Entity Framework Core pentru reflexie
        /// </summary>
        private Author() { }

        /// <summary>
        /// Initializeaza o instanta noua a clasei Author cu datele de baza
        /// </summary>
        public Author(string name, string nationality)
        {
            Name = name;
            Nationality = nationality;
        }
    }
}