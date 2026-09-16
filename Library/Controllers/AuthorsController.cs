using Library.BackendData.Models;
using Library.DBInfrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    /// <summary>
    /// Gestioneaza cererile HTTP pentru entitatea Author
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IRepository<Author> _repository;

        /// <summary>
        /// Injecteaza repository ul configurat special pentru autori
        /// </summary>
        /// <param name="repository">Instanta generata automat prin Dependency Injection</param>
        public AuthorsController(IRepository<Author> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Returneaza lista completa a autorilor
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _repository.GetAllAsync();
            return Ok(authors);
        }

        /// <summary>
        /// Cauta un autor specific folosind id ul
        /// </summary>
        /// <param name="id">Identificatorul unic al autorului</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            var author = await _repository.GetByIdAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        /// <summary>
        /// Salveaza un autor nou in baza de date
        /// </summary>
        /// <param name="author">Datele autorului primite din cerere sub forma de JSON</param>
        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromBody] Author author)
        {
            await _repository.AddAsync(author);
            // Returneaza codul 201 si un link de unde poate fi accesat noul autor
            return CreatedAtAction(nameof(GetAuthorById), new { id = author.Id }, author);
        }
    }
}