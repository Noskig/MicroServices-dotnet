using PlatformService.Models;

namespace PlatformService.Data
{
    //class more for testing
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using ( var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Platforms.AddRange(
                    new Platform() { Name ="Dot Net", Publisher="Microsoft", Cost="free"},
                    new Platform() { Name = "Sql Server Express", Publisher = "Microsoft", Cost = "free" },
                    new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "free" }
                    );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }

        }
    }
}
