using WebApi;
using WebApi.DBOperations;
using WebApi.Entities;

namespace TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {
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

        }
    }
}