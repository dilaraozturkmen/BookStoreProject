using WebApi;
using WebApi.DBOperations;

namespace TestSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        { context.Books.AddRange(
                    new Book
                    {
                        Id = 1,
                        Title = "Lean Startup",
                        GenreId = 1, // personal growth
                        PageCount= 200,
                        PublishDate = new DateTime(2001,06,12),
                        AuthorId = 1


                    },
                    new Book
                    {
                        Id = 2,
                        Title = "Herland",
                        GenreId = 2, // science fiction
                        PageCount= 250,
                        PublishDate = new DateTime(2005,06,12),
                        AuthorId = 2


                    },
                    new Book
                    {
                        Id = 3,
                        Title = "Dune",
                        GenreId = 2, // science fiction
                        PageCount= 500,
                        PublishDate = new DateTime(2008,06,12),
                        AuthorId = 3


                    });
            
        }


    }
}