using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Publisher.API.Services
{
    public class BookService : IBookService
    {
        private IList<Book> _books;
        public BookService()
        {
            Initialize();
        }

        private void Initialize()
        {
            if (_books == null)
            {
                _books = new List<Book>();
                using (StreamReader r = new StreamReader("books.json"))
                {
                    string json = r.ReadToEnd();
                    List<Book> items = JsonConvert.DeserializeObject<List<Book>>(json);
                    foreach (var item in items)
                    {
                        _books.Add(item);
                    }
                }
            }
        }

        public IList<Book> GetAllBooks()
        {
            return _books;
        }

        public IList<Book> GetBooksByAuthor(string authorName)
        {
            var booksByAuthor = _books.Where(b => b.Author.ToUpper().Contains(authorName.ToUpper())).ToList();
            return booksByAuthor;
        }

        public bool CreateBook(Book newBook)
        {
            var existingBook = _books.Where(b => b.Name.ToUpper().Equals(newBook.Name.ToUpper())).FirstOrDefault();
            if (existingBook == null)
            {
                _books.Add(newBook);
                return true;
            }

            return false;
        }

        public bool DeleteBook(Guid bookId)
        {
            var existingBook = _books.Where(b => b.BookId == bookId).FirstOrDefault();
            if (existingBook != null)
            {
                _books.Remove(existingBook);
                return true;
            }
            return false;
        }

    }
}
