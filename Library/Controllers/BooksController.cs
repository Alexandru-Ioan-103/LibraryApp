using Library.BackendData.Models;
using Library.DBInfrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    /// <summary>
    /// Gestioneaza cererile HTTP pentru entitatea Book
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IRepository<Book> _repository;

        /// <summary>
        /// Injecteaza repository-ul configurat special pentru carti
        /// </summary>
        /// <param name="repository">Instanta generata automat prin Dependency Injection</param>
        public BooksController(IRepository<Book> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Returneaza lista completa a cartilor
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _repository.GetAllAsync();
            return Ok(books);
        }

        /// <summary>
        /// Cauta o carte specifica folosind id-ul
        /// </summary>
        /// <param name="id">Identificatorul unic al cartii</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _repository.GetByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        /// <summary>
        /// Salveaza o carte noua in baza de date
        /// </summary>
        /// <param name="book">Datele cartii primite din cerere sub forma de JSON</param>
        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            // Validarea ModelState se face automat datorita atributului [ApiController]
            await _repository.AddAsync(book);

            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        /// <summary>
        /// Actualizeaza datele unei carti existente
        /// </summary>
        /// <param name="id">Id-ul cartii care trebuie modificata</param>
        /// <param name="updatedBook">Obiectul continand noile date</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] Book updatedBook)
        {
            // Verificam daca id-ul din ruta se potriveste cu cel din corpul cererii
            if (id != updatedBook.Id)
            {
                return BadRequest("Id-ul din ruta nu corespunde cu cel din obiect");
            }

            var existingBook = await _repository.GetByIdAsync(id);
            if (existingBook == null)
            {
                return NotFound($"Cartea cu id {id} nu a fost gasita");
            }

            await _repository.UpdateAsync(updatedBook);

            return NoContent();
        }

        /// <summary>
        /// Sterge o carte din baza de date
        /// </summary>
        /// <param name="id">Id-ul cartii care trebuie stearsa</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var existingBook = await _repository.GetByIdAsync(id);
            if (existingBook == null)
            {
                return NotFound($"Cartea cu id {id} nu a fost gasita");
            }

            await _repository.DeleteAsync(id);

            return NoContent();
        }
    }
}