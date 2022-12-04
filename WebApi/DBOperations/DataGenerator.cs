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
                context.Authors.AddRange(
                    new Author{
                        id = 1,
                        Name = "Eric", 
                        Surname ="Ries ",
                        DateOfBirth = new DateTime(1978,03,05)

                    },
               
                
                    new Author{
                        id = 2,
                        Name = "Charlotte",
                        Surname ="Perkins Gilman",
                        DateOfBirth = new DateTime(1860,07,03)

                    },
               
                
                    new Author{
                        id = 3,
                        Name = "Frank ",
                        Surname ="Herbet",
                        DateOfBirth = new DateTime(1920,06,12)

                    }
                );
                

                context.Books.AddRange(
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


                    }
                    
                );
                context.SaveChanges();
            }
        }
    }

}