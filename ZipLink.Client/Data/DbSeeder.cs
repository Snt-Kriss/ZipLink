using ZipLink.Data;
using ZipLink.Data.Models;

namespace ZipLink.Client.Data
{
    public static class DbSeeder
    {
        public static void SeedDefaultData(IApplicationBuilder applicationBuilder)
        {
            //CreateScope creates a new scope within application service provider. Scopes manage lifetime of an object
            using(var serviceScope= applicationBuilder.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!dbContext.Users.Any())
                {
                    dbContext.Users.AddRange(new User(){
                        FullName= "Crispus Munene",
                        Email="mwangikriss356@gmail.com"
                    });

                    dbContext.SaveChanges();
                }

                if (!dbContext.Urls.Any())
                {
                    dbContext.Urls.AddRange(new Url()
                    {
                        OriginalLink = "https://www.google.com",
                        ShortLink = "123",
                        NumberOfClicks = 1,
                        UserId = dbContext.Users.First().Id,
                        DateCreated= DateTime.Now
                    });

                    dbContext.SaveChanges();
                }
            }
        }
    }
}
