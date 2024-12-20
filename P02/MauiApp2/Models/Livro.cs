using SQLite;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace P02.Models
{
    public class Livro : INotifyPropertyChanged
    {
        private int id;
        private string nome;
        private string autor;
        private string email;
        private string isbn;

        public Livro()
        {
        }

        public Livro(string nome, string autor, string email, string iSBN)
        {
            Nome = nome;
            Autor = autor;
            Email = email;
            ISBN = iSBN;
        }

        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get => id;
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged();
                }
            }
        }

        [Required]
        public string Nome
        {
            get => nome;
            set
            {
                if (nome != value)
                {
                    nome = value;
                    OnPropertyChanged();
                }
            }
        }

        [Required]
        public string Autor
        {
            get => autor;
            set
            {
                if (autor != value)
                {
                    autor = value;
                    OnPropertyChanged();
                }
            }
        }

        [Required]
        public string Email
        {
            get => email;
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged();
                }
            }
        }

        [Required]
        public string ISBN
        {
            get => isbn;
            set
            {
                if (isbn != value)
                {
                    isbn = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

