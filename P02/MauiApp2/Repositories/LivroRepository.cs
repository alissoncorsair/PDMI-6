using Microsoft.EntityFrameworkCore;
using P02.Models;
using SQLite;

namespace P02.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        private LivroRepository()
        {

        }


        private static LivroRepository Instance;

        public static LivroRepository getInstance()
        {
            if(Instance == null)
            {
                Instance = new LivroRepository();   
            }

            return Instance;
        }
        

        private SQLiteAsyncConnection _dbConnection;
        public async Task InitializeAsync()
        {
            await SetUpDb();
        }
        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath =
                Path.Combine(FileSystem.Current.AppDataDirectory, "db_atividades.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<Livro>();
            }
        }


        public async Task<List<Livro>> GetAll()
        {
            return await _dbConnection.Table<Livro>().ToListAsync();
        }

        public async Task<Livro> GetById(int id)
        {
            var livros = await _dbConnection.QueryAsync<Livro>($"Select * From {nameof(Livro)} where Id = {id} ");
            return livros.FirstOrDefault();
        }

        public async void Create(Livro livro)
        {
            await _dbConnection.InsertAsync(livro);
        }

        public async void Update(int id, Livro livro)
        {
            livro.Id = id;
            await _dbConnection.UpdateAsync(livro);
        }

        public async void Delete(int id)
        {
            var livro = await GetById(id);
            await _dbConnection.DeleteAsync(livro);
        }
    }
}
