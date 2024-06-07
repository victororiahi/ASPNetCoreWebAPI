using ASPNetCoreWebAPI.Entities;

namespace ASPNetCoreWebAPI.Data
{
    public class BookData : IBookData
    {
        public Book AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync<T>(T obj)
        {
            throw new NotImplementedException();
        }

        public Book GetBook(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetBookAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> ListBooks()
        {
            return new List<Book>
            {
                new Book()
                {
                    Publisher = "Eliada",
                    Author = "Victor Oriahi",
                    Description = "A tale of my sporting journey",
                    Id = 1,
                    ISBN = "1999",
                    Title = "A Thousand Times on the Same Road",
                },

                 new Book()
                {
                    Publisher = "Macmillan",
                    Author = "Maia Obeya",
                    Description = "Adventures of a Princess in the Wild",
                    Id = 2,
                    ISBN = "2011",
                    Title = "The Princess and the Frog",
                },

                 new Book()
                {
                    Publisher = "Lantern",
                    Author = "Nancy Ayaraekpe",
                    Description = "Cook Menu",
                    Id = 3,
                    ISBN = "2001",
                    Title = "Cooking with Fancy Nancy",
                },

                 new Book()
                {
                    Publisher = "Spectrum",
                    Author = "Michael Jackson",
                    Description = "Auto Biography of my life",
                    Id = 4,
                    ISBN = "0011",
                    Title = "This is it!",
                },

            };
            //throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> ListBooksAsync()
        {
            throw new NotImplementedException();
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        public Task<int> saveAsync<T>(T obj)
        {
            throw new NotImplementedException();
        }

        public Book UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
