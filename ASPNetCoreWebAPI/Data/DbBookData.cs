using ASPNetCoreWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreWebAPI.Data
{
    public class DbBookData : IBookData
    {

        private readonly BookRepoContext _context;
        public DbBookData(BookRepoContext context)
        {
            _context = context;
        }

        public Book AddBook(Book book)
        {
            var newBook = _context.Add(book);
            return newBook.Entity;
        }

        public async Task<bool> DeleteAsync<T>(T book)
        {
            var entity = _context.Remove(book);
            entity.State = EntityState.Deleted;
            return (await _context.SaveChangesAsync() > 0);
        }

        public Book ? GetBook(int id)
        {
            var book = _context.Books.Find(id);
            return book;
        }

        public async Task<Book?> GetBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            return book;
        }

        public IEnumerable<Book> ListBooks()
        {
            var books = GetAll().ToList(); 
            return books;
        }

        public async Task<IEnumerable<Book>> ListBooksAsync()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> saveAsync<T>(T obj)
        {
            var addedEntity = _context.Add(obj);
            if(await _context.SaveChangesAsync() > -1)
            {
                return Convert.ToInt32(addedEntity.Property("Id").CurrentValue);
            }
            return -1;
        }

        public Book UpdateBook(Book book)
        {
            var entity = _context.Books.Attach(book);
            entity.State = EntityState.Modified;
            return book;
        }

        public IQueryable<Book> GetAll()
        {
            return _context.Books.AsQueryable();
        }

        public IEnumerable<Book> Search(string keyword)
        {
            keyword = keyword.ToLower();
            return GetAll().Where(b => 
            b.Author.ToLower() == keyword || 
            b.Publisher.ToLower() == keyword || 
            b.Title.ToLower() == keyword || 
            b.ISBN.ToLower() == keyword || 
            b.Description.ToLower() == keyword ||
            b.Author.ToLower().Contains(keyword) ||
            b.Publisher.ToLower().Contains(keyword) ||
            b.Title.ToLower().Contains(keyword) ||
            b.ISBN.ToLower().Contains(keyword) ||
            b.Description.ToLower().Contains(keyword));
        
        }

        public Task<IEnumerable<Book>> ListBooksAsync(string keyword)
        {
            throw new NotImplementedException();
        }


    }
}
