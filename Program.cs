using VintageGameLibrary.Components;
using VintageGameLibrary.Models;
using VintageGameLibrary.Models.Enums;
using VintageGameLibrary.Data;
using VintageGameLibrary.Services;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace VintageGameLibrary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            connectionString ??= builder.Configuration.GetConnectionString("VintageGameLibraryDB")!;

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddDbContext<LibraryContext>(options =>
                options.UseMySQL(connectionString)
            );
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<UserService>();

            var app = builder.Build();
            var scope = app.Services.CreateScope();
            context = scope.ServiceProvider.GetRequiredService<LibraryContext>();

            PopulateDB(3000);
            RunApp(app);
        }

        public static void RunApp(WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error", createScopeForErrors: true);
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
        public static string connectionString = null!;

        public static void PopulateDB(int size = 20)
        {
            context ??= new LibraryContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var user1 = new User
            {
                Username = "Admin",
                IsAdmin = true
            };

            var user2 = new User
            {
                Username = "User",
            };

            context.Users.Add(user1);
            context.Users.Add(user2);

            for (int i = 0; i < size; i++)
            {
                var rng = new Random();
                var game = new Game
                {
                    Name = "Game " + (i + 1),
                    Genre = Genres[rng.Next(Genres.Length)],
                    Platform = Platforms[rng.Next(Platforms.Length)],
                    Publisher = Publishers[rng.Next(Publishers.Length)],
                    Developer = "Developer " + rng.Next(50),
                    ReleaseYear = rng.Next(1980, 2000),
                    Barcode = rng.Next(100000000, 999999999),
                    MediaType = (Media)rng.Next(Enum.GetValues(typeof(Media)).Length),
                    Packaging = (Packaging)rng.Next(Enum.GetValues(typeof(Packaging)).Length),
                    Shelf = Alphabet[rng.Next(26)].ToString() + rng.Next(9),
                };
                Debug.WriteLine(i);
                context.Games.Add(game);
            }
            context.SaveChanges();
        }
        public static LibraryContext? context = null;
        private static readonly string[] Genres =
        [
            "Action",
            "Adventure",
            "Role-Playing",
            "Simulation",
            "Strategy",
            "Sports",
            "Puzzle",
        ];
        private static readonly string[] Platforms =
        [
            "PC",
            "PlayStation",
            "XBox",
            "GameCube",
            "GameBoy",
            "Super Nintendo",
            "Playstation Portatble",
        ];
        private static readonly string[] Publishers =
        [
            "Nintendo",
            "Sega",
            "Sony",
            "Microsoft",
        ];
        private static readonly string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    }
}
