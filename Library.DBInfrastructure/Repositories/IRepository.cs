namespace Library.DBInfrastructure.Repositories
{
    /// <summary>
    /// Interfata generica pentru operatiunile CRUD de baza
    /// </summary>
    /// <typeparam name="T">Modelul de date folosit (ex: Book sau Author)</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Extrage toate inregistrarile din tabel
        /// </summary>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Cauta o singura inregistrare dupa id
        /// </summary>
        /// <param name="id">Id ul inregistrarii cautate</param>
        Task<T?> GetByIdAsync(int id);

        /// <summary>
        /// Adauga o inregistrare noua in baza de date
        /// </summary>
        /// <param name="entity">Obiectul care va fi salvat</param>
        Task AddAsync(T entity);

        /// <summary>
        /// Actualizeaza datele unei inregistrari existente
        /// </summary>
        /// <param name="entity">Obiectul cu noile modificari</param>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Sterge o inregistrare existenta din tabel
        /// </summary>
        /// <param name="id">Id ul inregistrarii care va fi stearsa</param>
        Task DeleteAsync(int id);
    }
}