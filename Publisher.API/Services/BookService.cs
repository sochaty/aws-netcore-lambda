using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Publisher.API.Services
{
    public class BookService : IBookService
    {
        private readonly IList<Book> _books;
        public BookService()
        {
            _books = new List<Book>();
            Initialize();
        }

        private void Initialize()
        {
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

        public IList<Book> GetAllBooks()
        {
            return _books;
        }

        public IList<Book> GetBooksByAuthor(string authorName)
        {
            var booksByAuthor = _books.Where(b => b.Author.ToUpper().Contains(authorName.ToUpper())).ToList();
            return booksByAuthor;
        }


    }
}
