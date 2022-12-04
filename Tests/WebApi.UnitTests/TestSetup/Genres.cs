using WebApi;
using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this BookStoreDbContext context)
        {
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
        }
    }
}