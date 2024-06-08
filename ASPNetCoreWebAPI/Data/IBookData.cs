using ASPNetCoreWebAPI.Entities;

namespace ASPNetCoreWebAPI.Data
{
    public interface IBookData
    {
        IEnumerable<Book> ListBooks();
        Task<IEnumerable<Book>> ListBooksAsync();
        Book ? GetBook(int id);
        Task<Book?> GetBookAsync(int id);
        Book UpdateBook(Book book);
        Book AddBook(Book book);

        IEnumerable<Book> Search(string keyword);
        Task<int> saveAsync<T>(T obj);
        Task<bool> DeleteAsync<T>(T obj);
        int Save();
  
    }
}
