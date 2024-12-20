using Microsoft.EntityFrameworkCore;
using P02.Models;
using SQLite;

namespace P02.Repositories
{
    public interface ILivroRepository
    {
        Task InitializeAsync();
        Task<List<Livro>> GetAll();
        Task<Livro> GetById(int id);
        void Create(Livro livro);
        void Update(int id, Livro livro);
        void Delete(int id);
    }
}
