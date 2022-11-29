using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
             using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
           {
                if(context.Books.Any())
                {
                    return;
                }
                context.Genres.AddRange(
                    new Genre{
                        id = 1,
                        Name = "Personel Growth"
                    },
                    new Genre{
                        id = 2,
                        Name = "Science Fiction"
                    },
                    new Genre{
                        id = 3,
                        Name = "Roamence"
                    }
                );
                context.Books.AddRange(
                    new Book
                    {
                        Id = 1,
                        Title = "Lean Startup",
                        GenreId = 1, // personal growth
                        PageCount= 200,
                        PublishDate = new DateTime(2001,06,12)


                    },
                    new Book
                    {
                        Id = 2,
                        Title = "Herland",
                        GenreId = 2, // science fiction
                        PageCount= 250,
                        PublishDate = new DateTime(2005,06,12)


                    },
                    new Book
                    {
                        Id = 3,
                        Title = "Dune",
                        GenreId = 2, // science fiction
                        PageCount= 500,
                        PublishDate = new DateTime(2008,06,12)


                    }
                    
                );
                context.SaveChanges();
            }
        }
    }

}