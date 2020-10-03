using System.Collections.Generic;

namespace Publisher.API.Services
{
    public interface IBookService
    {
        IList<Book> GetAllBooks();
        IList<Book> GetBooksByAuthor(string authorName);
    }
}